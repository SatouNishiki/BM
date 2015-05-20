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
using BasketballManagementSystem.Manager.SaveDataManager;
using BasketballManagementSystem.BaseClass.Game;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using BasketballManagementSystem.BMForm.Input;

namespace BasketballManagementSystem.BMForm.Transmission.TCP
{
    //別スレッドからClientHandlerを持つList<T>の操作
    public delegate void dlgsetList(ClientHandler ch);
    //別スレッドからメインスレッドのテキストボックスに書き込むデリゲート
    public delegate void dlgWriteText(ClientHandler ch, string text);
    //別スレッドからログを書き込むデリゲート
    public delegate void dlgWriteLog(string text);

    public partial class FomServer : Form
    {
        //受送信は必ずshift-jisと仮定している
        //他の文字の場合はここを変える事
        public Encoding ecUni = Encoding.GetEncoding("utf-16");
        public Encoding ecSjis = Encoding.GetEncoding("shift-jis");

        //サーバーのリスナー設定
        TcpListener Listener = null;

        //サーバーのセカンドスレッドの設定
        Thread threadServer = null;

        //クライアントの参照を保持するListクラス
        private List<ClientHandler> lstClientHandler = new List<ClientHandler>();

        private FormInput instance;

        //コンストラクタ
        public FomServer(FormInput f)
        {
            InitializeComponent();
            instance = f;
        }
        

        //サーバースタートボタン押下
        private void butStart_Click(object sender, EventArgs e)
        {
            StartSock();
        }

        //ソケット通信開始
        private void StartSock()
        {
            //サーバーが開始したら    
            if (ServerStart())
            {
                //ボタンのenableを変える
                butStart.Enabled = false;
                butStop.Enabled = true;
                //LEDインジケータ風の色を変える
                picIndicator.BackColor = Color.LightGreen;
            }
        }

        //** セカンドスレッドの作成とサーバーのスタート **
        private bool ServerStart()
        {
            //TcpListenerを使用してサーバーの接続の確立
            try
            {
                //ログの書き込み
                WriteLog("サーバを開始しました。");
                //スレッドの作成と開始
                threadServer = new Thread(new ThreadStart(ServerListen));
                threadServer.Start();
                return (true);

            }
            catch (Exception ex)
            {
                //エラーが起きた
                WriteLog("サーバ接続エラー:" + ex.Message.ToString());
                Listener.Stop();
                picIndicator.BackColor = Color.Navy;
                return (false);
            }
        }


        //** セカンドスレッドせで実行されるサーバーのListen **
        //サーバーのListen
        private void ServerListen()
        {
            //TcpListenerを作成
            Listener = new TcpListener(IPAddress.Any, int.Parse(textBoxPortNo.Text));
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
                    this.BeginInvoke(new dlgsetList(this.addNewClient)
                                                       , new object[] { handler });

                    //読み込みを開始
                    handler.StartRead();
                } while (true);
            }
            catch (System.Threading.ThreadAbortException)
            {
                //スレッドが閉じられた時に発生
                return;
            }
            catch (System.Net.Sockets.SocketException)
            {
                //スレッドが閉じられた時に発生
                return;
            }
            catch (Exception ex)
            {
                //デリゲートでエラーを書き込む
                this.textBoxLog.BeginInvoke(new dlgWriteLog(WriteLog)
                              , new object[] { "受信エラー　" + ex.ToString() });
                return;
            }
        }


        //**** 接続、切断、受信処理 ****
        //** 受信文字の表示 ***
        //受信があった時に呼ばれて
        //受信文字をテキストボックスに書き込みます
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
            this.textBoxRead.AppendText("[" + no.ToString() + "さんからのメッセージ] "
                            + DateTime.Now.ToString()
                            + "\r\n" + text + "\r\n");

            //クライアントに送信するデータ
            Byte[] data = ecSjis.GetBytes("TEXT" +"[" + no.ToString() + "さんからのメッセージ] "
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
                    //sift-jisに変換して送る
              /*      Byte[] data = ecSjis.GetBytes("[" + no.ToString() + "さんからのメッセージ] "
                            + DateTime.Now.ToString()
                            + text);
*/
                    try
                    {
                        lstClientHandler[i].SendData(data);

                    }
                    catch (Exception ex)
                    {
                        WriteLog(ex.Message);
                    }
                }
            }
        }


        //** ClientHandleクラスのListクラスへの登録 **
        //新しい接続が有った時Delegateから呼ばれて、
        //新しいClientHandlerクラスのインスタンスをListクラスに登録します。
        private void addNewClient(ClientHandler cl)
        {
            lstClientHandler.Add(cl);
            resetClientListBox();
            WriteLog(cl.ClientHandle.ToString() + " さんが接続しました。");
        }

        //** 切断が生じた時のClientHandleクラスのListクラスからの削除 **
        //切断があった時にDelegateから呼ばれて
        //切断されたクライアントのClientHandleクラスのインスタンスをを
        //Listクラスから削除します。
        public void deleteClient(ClientHandler cl)
        {
            //Listクラスを総なめ
            for (int i = 0; i < lstClientHandler.Count; i++)
            {
                if (lstClientHandler[i] == cl)
                {
                    WriteLog(lstClientHandler[i].ClientHandle.ToString() + " さんが切断しました。");
                    lstClientHandler.RemoveAt(i);
                    resetClientListBox();
                    return;
                }
            }
        }


        //** クライアント表示の更新 **
        //接続、切断が有った時にList<T>を総なめして
        //接続しているクライアント表示のListBoxwoを新しく書き直す
        private void resetClientListBox()
        {
            listBoxClient.Items.Clear();
            for (int i = 0; i < lstClientHandler.Count; i++)
            {
                listBoxClient.Items.Add(lstClientHandler[i].ClientHandle.ToString());
            }
        }

        //**************************************
        //サーバーの終了処理
        //**************************************

        //ストップボタン押下
        private void butStop_Click(object sender, EventArgs e)
        {
            StopSock();
        }
        //xを押された時のフォームの終了
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopSock();
        }

        private void StopSock()
        {
            CloseServer();
            //ボタンのenableを変える
            butStart.Enabled = true;
            butStop.Enabled = false;
        }

        //サーバーのクローズ
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


        //**** 送信　****
        //ListBoxでクライアントのハンドルを選択して
        //メッセージを送信する

        //送信ボタン押下
        private void butSend_Click(object sender, EventArgs e)
        {

            ClientHandler clientHandler = null;

            //リストボックスでクライアントのハンドルが選択されていない。
            if (listBoxClient.SelectedItem == null)
                return;

            //ListBoxの選択された番号を取得
            int no = int.Parse(listBoxClient.SelectedItem.ToString());

            //List<T>からハンドルがキーに該当するclientHandlerを取得する
            clientHandler = lstClientHandler.Find(delegate(ClientHandler clitem)
            { return ((int)clitem.ClientHandle == no); });

            //sift-jisに変換して送る
            Byte[] data = ecSjis.GetBytes(textBoxWrite.Text);

            Byte[] header = ecSjis.GetBytes("TEXT");

            List<Byte> l = new List<byte>();

            l.AddRange(header);
            l.AddRange(data);

            Byte[] sendData = l.ToArray();

            try
            {
        //        clientHandler.WriteString(data);
                clientHandler.SendData(sendData);
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
            }
        }


        // ***テキストボックスのクリア***
        //各テキストボックスのクリア
        private void butClsWrite_Click(object sender, EventArgs e)
        {
            textBoxWrite.Clear();
        }

        private void butClsRead_Click(object sender, EventArgs e)
        {
            textBoxRead.Clear();
        }

        private void butClsLog_Click(object sender, EventArgs e)
        {
            textBoxLog.Clear();
        }

        //Logを書き込む
        public void WriteLog(string strlog)
        {
            this.textBoxLog.AppendText(DateTime.Now.ToString() + "  "
                                        + strlog + "\r\n");
        }

    }

    //*********************************************
    //    複数コネクション、非同期I/O クラス
    //*********************************************
    public class ClientHandler
    {
        private byte[] buffer;    //受信データ
        private Socket socket;
        private NetworkStream networkStream;
        private AsyncCallback callbackRead;
        private AsyncCallback callbackWrite;

        //FomServerの参照を保持する 
        private FomServer fomServer = null;

        //受送信は必ずshift-jisと仮定している
        //他の文字の場合はここを変える事
        private Encoding ecUni = Encoding.GetEncoding("utf-16");
        private Encoding ecSjis = Encoding.GetEncoding("shift-jis");

        private FormInput instance;

        //クラスのコンストラクタ
        public ClientHandler(Socket socketForClient, FomServer _FomServer, FormInput f)
        {
            //呼び出し側のSocketを保持
            socket = socketForClient;

            socket.SendBufferSize = 50000;

            //clientHandle = socket.Handle;

            //呼び出し側のフォームのインスタンスを保持
            fomServer = _FomServer;

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


        //Socketクラスのハンドルを返します
        //これはインスタンスの識別に使用します
        public IntPtr ClientHandle
        {
            get { return socket.Handle; }
        }

        // クライアントからの文字列読み出し開始
        //別スレッドで行われ、読み込み終了時にcallbackReadがCLRによって
        //呼び出されます。
        public void StartRead()
        {
            networkStream.BeginRead(buffer, 0, buffer.Length, callbackRead, null);
        }


        //networkStream.BeginReadの別スレッドから、読み込み完了時
        //又はクライアント切断時にコールバックされます。
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
                    Byte[] getByte = new byte[bytesRead];
                    for (int i = 0; i < bytesRead; i++)
                        getByte[i] = buffer[i];

                    Byte[] temp = new byte[4];

                    //ヘッダー切り出し
                    Array.Copy(getByte, 0, temp, 0, 4);

                    string header = ecSjis.GetString(temp);
                    Byte[] body = new byte[bytesRead - 4];
                    Array.Copy(getByte, 4, body, 0, bytesRead - 4);

                    if (header == "TEXT")
                    {
                        byte[] uniBytes;
                        //'S-Jisからユニコードに変換
                        uniBytes = Encoding.Convert(ecSjis, ecUni, body);

                        //バイト配列から文字列に変換する
                        string strGetText = ecUni.GetString(uniBytes);
                        //受信文字を切り出す

                        //メインスレッドのテキストボックスに書き込む
                        fomServer.Invoke(new dlgWriteText(fomServer.WriteReadText)
                                           , new object[] { this, strGetText });

                    }
                    else if (header == "GAME")
                    {
                        BinaryFormatter b = new BinaryFormatter();
                        MemoryStream m = new MemoryStream(body);
                        m.Seek(0, SeekOrigin.Begin);
                        Game g = (Game)b.Deserialize(m);
                        instance.LoadProcess(g);
                        
                        m.Close();

                        fomServer.NotifyAll(null, getByte);
                    }
                    //次の受信を待つ
                    networkStream.BeginRead(buffer, 0, buffer.Length, callbackRead, null);

                }
                else
                {
                    //終了ボタンが押され場合はここに落ちる
                    //クライアントのList<T>からの削除
                    fomServer.Invoke(new dlgsetList(fomServer.deleteClient)
                                            , new object[] { this });

                    networkStream.Close();
                    socket.Close();
                    networkStream = null;
                    Thread.Sleep(20);//これを入れないとNullReferenceExceptionが起きる
                    socket = null;
                }

            }
            catch (System.Net.Sockets.SocketException)
            {
                //スレッドが閉じられた時に発生
                //何もしません;
                return;
            }
            catch (System.IO.IOException)
            {
                //スレッドが閉じられた時に発生
                return;
            }
            catch (Exception ex)
            {
                //エラーログの書き込み
                fomServer.Invoke(new dlgWriteLog(fomServer.WriteLog)
                , new object[] { "受信エラーが起こりました " + ex.ToString() });
            }
        }

        // 送信
        //別スレッドで送信し、送信が終了すると
        //OnWriteCompleteがコールバックされます。
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

        // 文字列の書き込みが完了したときにメッセージを出力して読み取りを続けます
        private void OnWriteComplete(IAsyncResult ar)
        {
            networkStream.EndWrite(ar);
            //networkStream.BeginRead(buffer, 0, buffer.Length,callbackRead, null);
        }
    }
}
