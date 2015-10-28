using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;
using BasketballManagementSystem.manager;
using BasketballManagementSystem.baseClass.game;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using BasketballManagementSystem.bMForm.input;
using BMErrorLibrary;
using BasketballManagementSystem.bMForm.Transmission.compression;

namespace BasketballManagementSystem.bMForm.Transmission.tCP
{
    /// <summary>
    /// 別スレッドからClientHandlerを持つList<T>の操作
    /// </summary>
    /// <param name="ch"></param>
    public delegate void ListSetDelegate(ClientHandler ch);

    /// <summary>
    /// //別スレッドからメインスレッドのテキストボックスに書き込むデリゲート
    /// </summary>
    /// <param name="ch"></param>
    /// <param name="text"></param>
    public delegate void WriteTextDelegate(ClientHandler ch, string text);

    /// <summary>
    /// 別スレッドからログを書き込むデリゲート
    /// </summary>
    /// <param name="text"></param>
    public delegate void WriteLogDelegate(string text);

    public partial class TCPServer : Form
    {
        //受送信は必ずshift-jisと仮定している
        //他の文字の場合はここを変える事
        public Encoding EcUni = Encoding.GetEncoding("utf-16");
        public Encoding EcSjis = Encoding.GetEncoding("shift-jis");

        public Game SendGame = new Game();

        public string Password;

        public ClientHandler lastConnectClient;

        /// <summary>
        /// サーバーのリスナー設定
        /// </summary>
        private TcpListener Listener = null;

        /// <summary>
        /// サーバーのセカンドスレッドの設定
        /// </summary>
        private Thread threadServer = null;

        /// <summary>
        /// クライアントの参照を保持するListクラス
        /// </summary>
        private List<ClientHandler> lstClientHandler = new List<ClientHandler>();

        private FormInputPresenter instance;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="f"></param>
        public TCPServer(FormInputPresenter f)
        {
            InitializeComponent();
            instance = f;
        }


        /// <summary>
        /// サーバースタートボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, EventArgs e)
        {
            StartSock();
        }

        /// <summary>
        /// ソケット通信開始
        /// </summary>
        private void StartSock()
        {
            //サーバーが開始したら    
            if (ServerStart())
            {
                //ボタンのenableを変える
                StartButton.Enabled = false;
                StopButton.Enabled = true;
                PasswordTextBox.Enabled = false;
                //LEDインジケータ風の色を変える
                picIndicator.BackColor = Color.LightGreen;
            }
        }

        /// <summary>
        /// セカンドスレッドの作成とサーバーのスタート
        /// </summary>
        /// <returns></returns>
        private bool ServerStart()
        {
            //TcpListenerを使用してサーバーの接続の確立
            try
            {
                //ログの書き込み
                WriteLog("サーバを開始しました。");
                Password = PasswordTextBox.Text;

                //スレッドの作成と開始
                threadServer = new Thread(new ThreadStart(ServerListen));
                threadServer.Start();
                return (true);

            }
            catch (Exception ex)
            {
                //エラーが起きた
                WriteLog("サーバ接続エラー:" + ex.Message.ToString());
                BMError.ErrorMessageOutput(ex.Message.ToString(), true);
                Listener.Stop();
                picIndicator.BackColor = Color.Navy;
                return (false);
            }
        }


        /// <summary>
        /// セカンドスレッドで実行されるサーバーのListen
        /// </summary>
        private void ServerListen()
        {
            //TcpListenerを作成
            Listener = new TcpListener(IPAddress.Any, int.Parse(PortNumberTextBox.Text));
            Listener.Start();
            // クライアントの接続を受けるための永久ループ
            try
            {
                do
                {
                    // Listener.AcceptSocketは同期メソドで接続要求が有るまで
                    //値を返さずここで待機します
                    // 新しい接続要求ががあると接続を許可して
                    // 新しいソケットを返します
                    Socket socketForClient = Listener.AcceptSocket();

                    //クライアント毎の接続とフォームのインスタンスを渡す
                    ClientHandler handler = new ClientHandler(socketForClient, this, instance);

                    //ListクラスにClientHandlerのインスタンスを保持します                
                    this.BeginInvoke(new ListSetDelegate(this.AddNewClient)
                                                       , new object[] { handler });

                    //読み込みを開始
                    handler.StartRead();
                } while (true);
            }
            catch (System.Threading.ThreadAbortException ex)
            {
                //スレッドが閉じられた時に発生
                BMError.ErrorMessageOutput(ex.ToString(), false);
                return;
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                //スレッドが閉じられた時に発生
                BMError.ErrorMessageOutput(ex.ToString(), false);
                return;
            }
            catch (Exception ex)
            {
                //デリゲートでエラーを書き込む
                this.LogTextBox.BeginInvoke(new WriteLogDelegate(WriteLog)
                              , new object[] { "受信エラー　" + ex.ToString() });
                BMError.ErrorMessageOutput(ex.ToString(), true);
                return;
            }
        }


        /// <summary>
        /// 引数をテキストボックスに書き込みます
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="text"></param>
        public void WriteReadText(ClientHandler cl, string text)
        {
            //Listクラスが保持しているClientHandlerの中のSocketクラスの
            //Handleを比較し、クライアントを識別します。
            int no = 0;
            for (int i = 0; i < lstClientHandler.Count; i++)
            {
                if (lstClientHandler[i] == cl)
                {
                    //クライアントのハンドルが一致した
                    no = (int)lstClientHandler[i].ClientHandle;
                    break;
                }
            }
            //送られたメッセージをクライアントの情報と時間と共に書き込む
            this.ReadTextBox.AppendText("[" + no.ToString() + "さんからのメッセージ] "
                            + DateTime.Now.ToString()
                            + "\r\n" + text + "\r\n");

            //クライアントに送信するデータ
            Byte[] data = EcSjis.GetBytes("TEXT" + "[" + no.ToString() + "さんからのメッセージ] "
                            + DateTime.Now.ToString()
                            + text);

            NotifyAll(cl, data);
        }

        /// <summary>
        /// クライアント全てにデータを送信する
        /// </summary>
        /// <param name="cl">送らない送信先クライアント(全員に送る場合はnull)</param>
        /// <param name="data">送信するデータ</param>
        public void NotifyAll(ClientHandler cl, Byte[] data)
        {
            //送ってきた相手以外へ送信
            for (int i = 0; i < lstClientHandler.Count; i++)
            {
                if (lstClientHandler[i] != cl)
                {

                    try
                    {
                        lstClientHandler[i].SendData(data);

                    }
                    catch (Exception ex)
                    {
                        WriteLog(ex.Message);
                        BMError.ErrorMessageOutput(ex.ToString(), false);
                    }
                }
            }
        }


        /// <summary>
        /// 新しいClientHandlerクラスのインスタンスをListクラスに登録
        /// </summary>
        /// <param name="cl"></param>
        private void AddNewClient(ClientHandler cl)
        {
            lstClientHandler.Add(cl);
            lastConnectClient = cl;
            ResetClientListBox();
            WriteLog(cl.ClientHandle.ToString() + " さんが接続しました。");
        }

        /// <summary>
        /// 切断されたクライアントのClientHandleクラスのインスタンスをListクラスから削除
        /// </summary>
        /// <param name="cl"></param>
        public void DeleteClient(ClientHandler cl)
        {
            //Listクラスを総なめ
            for (int i = 0; i < lstClientHandler.Count; i++)
            {
                if (lstClientHandler[i] == cl)
                {
                    Invoke(new WriteLogDelegate(WriteLog)
                                           , new object[] { lstClientHandler[i].ClientHandle.ToString() + " さんが切断しました。" });

                    lstClientHandler.RemoveAt(i);
                    ResetClientListBox();

                    return;
                }
            }
        }


        /// <summary>
        /// クライアント表示のListBoxを新しく書き直す
        /// </summary>
        private void ResetClientListBox()
        {
            ClientListBox.Items.Clear();
            for (int i = 0; i < lstClientHandler.Count; i++)
            {
                ClientListBox.Items.Add(lstClientHandler[i].ClientHandle.ToString());
            }
        }

        /// <summary>
        /// ストップボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopButton_Click(object sender, EventArgs e)
        {
            StopSock();
        }
        /// <summary>
        /// xを押された時のフォームの終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopSock();
        }

        private void StopSock()
        {
            CloseServer();
            //ボタンのenableを変える
            StartButton.Enabled = true;
            StopButton.Enabled = false;
            PasswordTextBox.Enabled = true;
        }

        /// <summary>
        /// サーバーのクローズ
        /// </summary>
        private void CloseServer()
        {
            if (Listener != null)
            {
                Listener.Stop();
                Thread.Sleep(20);
                Listener = null;
            }

            //スレッドは必ず終了させること
            if (threadServer != null)
            {
                threadServer.Abort();
                threadServer = null;
            }
            //インディケータの色を変える            
            picIndicator.BackColor = Color.Navy;
            //ログを書き込む
            WriteLog("サーバーが閉じられました。");
        }


        /// <summary>
        /// 送信ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendButton_Click(object sender, EventArgs e)
        {

            ClientHandler clientHandler = null;

            //リストボックスでクライアントのハンドルが選択されていない。
            if (ClientListBox.SelectedItem == null)
                return;

            //ListBoxの選択された番号を取得
            int no = int.Parse(ClientListBox.SelectedItem.ToString());

            //List<T>からハンドルがキーに該当するclientHandlerを取得する
            clientHandler = lstClientHandler.Find(delegate(ClientHandler clitem)
            { return ((int)clitem.ClientHandle == no); });

            //sift-jisに変換して送る
            Byte[] data = EcSjis.GetBytes(WriteTextBox.Text);

            Byte[] header = EcSjis.GetBytes("TEXT");

            List<Byte> l = new List<byte>();

            l.AddRange(header);
            l.AddRange(data);

            Byte[] sendData = l.ToArray();

            try
            {
                clientHandler.SendData(sendData);
                WriteTextBox.Clear();
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
                BMError.ErrorMessageOutput(ex.ToString(), true);
            }
        }

        private void WriteClearButton_Click(object sender, EventArgs e)
        {
            WriteTextBox.Clear();
        }

        private void ReadClearButton_Click(object sender, EventArgs e)
        {
            ReadTextBox.Clear();
        }

        private void LogClearButton_Click(object sender, EventArgs e)
        {
            LogTextBox.Clear();
        }

        /// <summary>
        /// Logを書き込む
        /// </summary>
        /// <param name="strlog"></param>
        public void WriteLog(string strlog)
        {
            this.LogTextBox.AppendText(DateTime.Now.ToString() + "  "
                                        + strlog + "\r\n");
        }

        private void ServerSendTimer_Tick(object sender, EventArgs e)
        {
            BinaryFormatter b = new BinaryFormatter();
            MemoryStream m = new MemoryStream();

            b.Serialize(m, SendGame);
            byte[] byt = m.ToArray();
            byte[] header = EcSjis.GetBytes("GAME");

            //バイナリシリアライズしたゲームデータオブジェクトにヘッダーをくっつけて送信バイト配列を生成
            List<byte> temp = new List<byte>(byt.Length + header.Length);
            temp.AddRange(header);
            temp.AddRange(byt);

            byte[] sendData = temp.ToArray();

            m.Close();

            //データ圧縮
            sendData = Compressor.Compress(sendData);

            NotifyAll(null, sendData);
        }

    }

    /// <summary>
    /// 複数コネクション、非同期I/O クラス
    /// </summary>
    public class ClientHandler
    {
        /// <summary>
        /// 受信データ
        /// </summary>
        private byte[] buffer;

        private Socket socket;
        private NetworkStream networkStream;
        private AsyncCallback callbackRead;
        private AsyncCallback callbackWrite;

        /// <summary>
        /// FomServerの参照を保持する
        /// </summary>
        private TCPServer fomServer = null;

        //受送信は必ずshift-jisと仮定している
        //他の文字の場合はここを変える事
        private Encoding ecUni = Encoding.GetEncoding("utf-16");
        private Encoding ecSjis = Encoding.GetEncoding("shift-jis");

        private FormInputPresenter instance;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="socketForClient"></param>
        /// <param name="fomServer"></param>
        /// <param name="f"></param>
        public ClientHandler(Socket socketForClient, TCPServer fomServer, FormInputPresenter f)
        {
            //呼び出し側のSocketを保持
            socket = socketForClient;

            socket.SendBufferSize = 50000;

            //clientHandle = socket.Handle;

            //呼び出し側のフォームのインスタンスを保持
            this.fomServer = fomServer;

            //読み込み用のバッファ
            buffer = new byte[100000];

            //socketの読み書き用のstreamを作成します
            networkStream = new NetworkStream(socketForClient);

            //読み込み完了時にCLRから呼ばれるメソド
            callbackRead = new AsyncCallback(this.OnReadComplete);

            //書き込み完了時にCLRから呼ばれるメソド
            callbackWrite = new AsyncCallback(this.OnWriteComplete);

            instance = f;
        }


        /// <summary>
        /// Socketクラスのハンドルを返す
        /// </summary>
        public IntPtr ClientHandle
        {
            get { return socket.Handle; }
        }

        /// <summary>
        /// クライアントからの文字列読み出し開始
        /// </summary>
        public void StartRead()
        {
            networkStream.BeginRead(buffer, 0, buffer.Length, callbackRead, null);
        }


        /// <summary>
        /// networkStream.BeginReadの別スレッドから、読み込み完了時、又はクライアント切断時にコールバックされる
        /// </summary>
        /// <param name="ar"></param>
        private void OnReadComplete(IAsyncResult ar)
        {
            try
            {
                //受信文字をStreamから読み込みます
                if (networkStream == null)
                    return;

                //受信バイト数が返る        
                int bytesRead = networkStream.EndRead(ar);


                if (bytesRead > 0)　　 //受信文字が有った
                {
         
                    //受信部分だけ切り出す
                    Byte[] getByte1 = new byte[bytesRead];
                    for (int i = 0; i < bytesRead; i++)
                        getByte1[i] = buffer[i];

                    //解凍
                    Byte[] getByte = Compressor.Decompress(getByte1);

                    Byte[] temp = new byte[4];

                    //ヘッダー切り出し
                    Array.Copy(getByte, 0, temp, 0, 4);

                    string header = ecSjis.GetString(temp);
                    Byte[] body = new byte[getByte.Length - 4];
                    Array.Copy(getByte, 4, body, 0, getByte.Length - 4);

                    if (header == "TEXT")
                    {
                        byte[] uniBytes;
                        //'S-Jisからユニコードに変換
                        uniBytes = Encoding.Convert(ecSjis, ecUni, body);

                        //バイト配列から文字列に変換する
                        string getText = ecUni.GetString(uniBytes);

                        //メインスレッドのテキストボックスに書き込む
                        fomServer.Invoke(new WriteTextDelegate(fomServer.WriteReadText)
                                           , new object[] { this, getText });

                    }
                    else if (header == "GAME")
                    {
                        BinaryFormatter b = new BinaryFormatter();


                        MemoryStream m = new MemoryStream(body);
                        m.Seek(0, SeekOrigin.Begin);
                        Game g = (Game)b.Deserialize(m);
                        instance.LoadGame(g);

                        m.Close();

                        fomServer.SendGame = g;
                    }
                    else if (header == "PASS")
                    {
                        byte[] uniBytes;
                        //'S-Jisからユニコードに変換
                        uniBytes = Encoding.Convert(ecSjis, ecUni, body);

                        //バイト配列から文字列に変換する
                        string getText = ecUni.GetString(uniBytes);

                        if (getText != fomServer.Password)
                        {
                            SendPasswordHelper("NO");
                            fomServer.Invoke(new ListSetDelegate(fomServer.DeleteClient)
                                            , new object[] { fomServer.lastConnectClient });
                        }
                        else
                        {
                            SendPasswordHelper("OK");
                        }
                    }
                    //次の受信を待つ
                    networkStream.BeginRead(buffer, 0, buffer.Length, callbackRead, null);

                }
                else
                {
                    //終了ボタンが押され場合はここに落ちる
                    //クライアントのList<T>からの削除
                    fomServer.Invoke(new ListSetDelegate(fomServer.DeleteClient)
                                            , new object[] { this });

                    networkStream.Close();
                    socket.Close();
                    networkStream = null;
                    Thread.Sleep(20);//これを入れないとNullReferenceExceptionが起きる
                    socket = null;
                }

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                //スレッドが閉じられた時に発生
                BMError.ErrorMessageOutput(ex.ToString(), false);
                //何もしません;
                return;
            }
            catch (System.IO.IOException ex)
            {
                //スレッドが閉じられた時に発生
                BMError.ErrorMessageOutput(ex.ToString(), false);
                return;
            }
            catch (Exception ex)
            {
                //エラーログの書き込み
                fomServer.Invoke(new WriteLogDelegate(fomServer.WriteLog)
                , new object[] { "受信エラーが起こりました " + ex.ToString() });
                BMError.ErrorMessageOutput(ex.ToString(), true);
            }
        }

        private void SendPasswordHelper(string message)
        {
            //sift-jisに変換して送る
            Byte[] data = fomServer.EcSjis.GetBytes(message);

            Byte[] head = fomServer.EcSjis.GetBytes("PASS");

            List<Byte> l = new List<byte>();

            l.AddRange(head);
            l.AddRange(data);

            Byte[] sendData = l.ToArray();

            sendData = Compressor.Compress(sendData);

            try
            {
                fomServer.lastConnectClient.SendData(sendData);
            }
            catch (Exception ex)
            {
                BMError.ErrorMessageOutput(ex.ToString(), true);
            }
        }

        /// <summary>
        /// 別スレッドで送信し、送信が終了するとOnWriteCompleteがコールバックされる
        /// </summary>
        /// <param name="buffer"></param>
        public void SendData(byte[] buffer)
        {
            int offset = 0;

            //もしネットワークバッファのサイズを超えたデータを送ろうとしていたら分割送信処理
            if (buffer.Length > socket.SendBufferSize)
            {
                for (offset = 0; offset * 2 < buffer.Length; offset += socket.SendBufferSize)
                {
                    networkStream.BeginWrite(buffer, offset, socket.SendBufferSize, callbackWrite, null);
                }
            }

            networkStream.BeginWrite(buffer, offset, buffer.Length - offset, callbackWrite, null);

        }

        /// <summary>
        /// 文字列の書き込みが完了したときにメッセージを出力して読み取りを続ける
        /// </summary>
        /// <param name="ar"></param>
        private void OnWriteComplete(IAsyncResult ar)
        {
            networkStream.EndWrite(ar);
        }
    }
}