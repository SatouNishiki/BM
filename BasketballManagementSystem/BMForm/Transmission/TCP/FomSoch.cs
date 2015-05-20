using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using BasketballManagementSystem.BaseClass.Game;
using BasketballManagementSystem.Manager.SaveDataManager;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using BasketballManagementSystem.BMForm.Input;
using BMErrorLibrary;

namespace BasketballManagementSystem.BMForm.Transmission.TCP
{
    public partial class FomSoch : Form
    {

        //***********************************************************
        //初期設定宣言
        //***********************************************************
        //受信は必ずshift-jisと仮定している
        //他の文字の場合はここを変える事
        private Encoding ecUni = Encoding.GetEncoding("utf-16");
        private Encoding ecSjis = Encoding.GetEncoding("shift-jis");

        //クライアント設定
        private TcpClient client = null;
        //クライアントのセカンドスレッドの設定
        private Thread threadClient = null;

        /// <summary>
        /// ゲームデータ受信フラグ(trueのときに受信)
        /// </summary>
        private static bool readFlag = true;

        private Game sendGame;

        private FormInput instance;

        //**********************************************************
        //デリゲート宣言
        //**********************************************************
        //別スレッドからメインスレッドのテキストボックスに書き込むデリゲート
        delegate void dlgWriteText(string text);

        //引数を持たない汎用のデリゲート
        //ストップボタンを押す等に使用
        delegate void dlgMydelegate();


        public FomSoch(FormInput f)
        {
            InitializeComponent();
            instance = f;
        }

        //***********************************************************
        //ソケット通信の開始処理
        //***********************************************************
        //Startボタン押下
        private void butStart_Click(object sender, EventArgs e)
        {
            StartSock();
        }

        //ソケット通信開始
        private void StartSock()
        {
            bool openflg = false;

            openflg = ClientStart();

            //ボタンのenableを変える
            if (openflg)
            {
                butStart.Enabled = false;
                butStop.Enabled = true;
            }
        }

        //***********************************************************
        //セカンドスレッドの作成とクライアントのスタート
        //***********************************************************    
        private bool ClientStart()
        {
            try
            {
                //クライアントのソケットを用意
                client = new TcpClient(textBoxIp.Text, int.Parse(textBoxPortNo.Text));
                client.SendBufferSize = 50000;

                //サーバからのデータを受信するループをスレッドで処理
                threadClient = new Thread(new ThreadStart(this.ClientListen));
                threadClient.Start();

                //接続インディケータ
                picIndicator.BackColor = Color.LightGreen;
                writeLog("クライアント接続されました:");
                return (true);
            }
            catch (Exception ex)
            {
                writeLog("クライアント接続エラー:" + ex.Message.ToString());
                BMError.ErrorMessageOutput(ex.Message);
                picIndicator.BackColor = Color.Navy;
                return (false);
            }
        }

        //***********************************************************
        //別スレッドで実行されるクライアント側の処理
        //ここの処理はServerと同じなのでそちらを参照のこと
        //***********************************************************
        private void ClientListen()
        {

            NetworkStream stream = client.GetStream();

            Byte[] bytes = new Byte[100000];
            dlgWriteText dlgText = new dlgWriteText(WriteReadText);

            while (true)
            {
                try
                {
                    int intCount = stream.Read(bytes, 0, bytes.Length);
                    if (intCount != 0)
                    {

                        //受信部分だけ切り出す
                        Byte[] getByte = new byte[intCount];
                        for (int i = 0; i < intCount; i++)
                            getByte[i] = bytes[i];

                        Byte[] temp = new byte[4];

                        //ヘッダー切り出し
                        Array.Copy(getByte, 0, temp, 0, 4);

                        string header = ecSjis.GetString(temp);
                        Byte[] body = new byte[intCount - 4];
                        Array.Copy(getByte, 4, body, 0, intCount - 4);

                        if (header == "TEXT")
                        {

                            byte[] uniBytes;
                            //'S-Jisからユニコードに変換
                            uniBytes = Encoding.Convert(ecSjis, ecUni, body);
                            string strGetText = ecUni.GetString(uniBytes);

                            textBoxWrite.Invoke(dlgText, strGetText);

                        }
                        else if (header == "GAME")
                        {
                            BinaryFormatter b = new BinaryFormatter();
                            MemoryStream m = new MemoryStream(body);
                            m.Seek(0, SeekOrigin.Begin);
                            Game g = (Game)b.Deserialize(m);

                            if (g.Equals(sendGame))
                            {
                                readFlag = true;
                            }
                            else
                            {
                                if(readFlag && !g.Equals(SaveDataManager.GetInstance().GetGame()))
                                instance.LoadProcess(g);
                            }
                            m.Close();
                        }
                    }
                    else
                    {
                        //サーバーが切断された 
                        this.textBoxLog.BeginInvoke(new dlgWriteText(writeLog)
                             , new object[] { "ホストが切断されました。" });
                        this.butStart.BeginInvoke(new dlgMydelegate(StopSock),
                             new object[] { });
                        return;
                    }
                }
                catch (System.Threading.ThreadAbortException)
                {
                    //何もしません;
                    return;
                }
                catch (Exception ex)
                {
                    this.textBoxLog.BeginInvoke(new dlgWriteText(writeLog)
                            , new object[] { "受信エラー　　" + ex.ToString() });
                    BMError.ErrorMessageOutput(ex.Message);
                    return;
                }
            }
        }


        //***********************************************************
        //ソケット通信の終了処理
        //***********************************************************
        //Stopボタン押下
        private void butStop_Click(object sender, EventArgs e)
        {
            StopSock();
        }

        private void StopSock()
        {
            //クライアントストップ

            CloseClient();

            //ボタンのenableを変える
            butStart.Enabled = true;
            butStop.Enabled = false;
        }

        //クライアントのクローズ
        private void CloseClient()
        {
            //クライアントのインスタンスが有って、接続されていたら
            if (client != null && client.Connected)
                client.Close();

            //スレッドは必ず終了させること
            if (threadClient != null)
                threadClient.Abort();

            //インディケータの色を変える      
            picIndicator.BackColor = Color.Navy;
            //ログを書き込む
            writeLog("クライアントが閉じられました。");
        }


        //******************************************************
        //デリゲートから呼ばれるテキストに書き込むメソド、
        //*******************************************************
        //受信文字をテキストボックスに書き込む
        private void WriteReadText(string text)
        {
            //受信文字の改行は全て↓に置き換えられる
            text = text.Replace("\r\n", "↓");
            this.textBoxRead.AppendText(text + "\r\n");
        }

        //Logを書き込む
        private void writeLog(string strlog)
        {
            this.textBoxLog.AppendText(DateTime.Now.ToString() + "  "
                                        + strlog + "\r\n");
        }


        //************************************************************
        //文字データの送信
        //************************************************************
        //送信ボタン押下
        private void butSend_Click(object sender, EventArgs e)
        {
            SendStringData();
        }

        //文字データーの送信
        private void SendStringData()
        {
            //sift-jisに変換して送る
            Byte[] data = ecSjis.GetBytes(textBoxWrite.Text);

            Byte[] header = ecSjis.GetBytes("TEXT");

            List<Byte> l = new List<byte>();

            l.AddRange(header);
            l.AddRange(data);

            Byte[] sendData = l.ToArray();

            //送信streamを作成
            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();

                //Streamを使って送信
                for (int offset = 0; offset >= sendData.Length; offset += client.SendBufferSize)
                {
                    stream.Write(sendData, offset, client.SendBufferSize);
                }

                stream.Write(sendData, 0, sendData.Length);
            }
            catch (Exception exc)
            {
                writeLog("送信エラー:" + exc.Message);
                BMError.ErrorMessageOutput(exc.Message);
            }
        }


        //******************************************************
        //テキストボックスのクリア
        //******************************************************
        private void butCls_Click(object sender, EventArgs e)
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

        //*******************************************************
        //プログラムの終了処理
        //*******************************************************
        private void FomSoch_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseClient();
        }

        private void GameSendTimer_Tick(object sender, EventArgs e)
        {
            if (client == null) return;


            Game game = SaveDataManager.GetInstance().GetGame();

            if (sendGame != null && sendGame.Equals(game)) return;

            BinaryFormatter b = new BinaryFormatter();
            MemoryStream m = new MemoryStream();

            b.Serialize(m, game);
            byte[] byt = m.ToArray();
            byte[] header = ecSjis.GetBytes("GAME");
            
            //バイナリシリアライズしたゲームデータオブジェクトにヘッダーをくっつけて送信バイト配列を生成
            List<byte> temp = new List<byte>(byt.Length + header.Length);
            temp.AddRange(header);
            temp.AddRange(byt);

            byte[] sendData = temp.ToArray();

            m.Close();

            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();

                int offset = 0;

                //もしネットワークバッファのサイズを超えたデータを送ろうとしていたら分割送信処理
                if (sendData.Length > client.SendBufferSize)
                {
                    for (offset = 0; offset*2 < sendData.Length; offset += client.SendBufferSize)
                    {
                        stream.Write(sendData, offset, client.SendBufferSize);
                        readFlag = false;
                    }
                }

                stream.Write(sendData, offset, sendData.Length - offset);

                sendGame = game.CloneDeep();
            }
            catch (Exception exc)
            {
                writeLog("送信エラー:" + exc.Message);
                BMError.ErrorMessageOutput(exc.Message);
            }
        }

    }
}
