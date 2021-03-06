﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using BasketballManagementSystem.baseClass.game;
using BasketballManagementSystem.manager;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using BasketballManagementSystem.bmForm.input;
using BMErrorLibrary;
using BasketballManagementSystem.bmForm.Transmission.compression;

namespace BasketballManagementSystem.bmForm.Transmission.tcp
{
    public partial class TCPClient : Form
    {

        //受信は必ずshift-jisと仮定している
        //他の文字の場合はここを変える事
        private Encoding ecUni = Encoding.GetEncoding("utf-16");
        private Encoding ecSjis = Encoding.GetEncoding("shift-jis");

        /// <summary>
        /// クライアント設定
        /// </summary>
        private TcpClient client = null;

        /// <summary>
        /// クライアントのセカンドスレッドの設定
        /// </summary>
        private Thread threadClient = null;

        /// <summary>
        /// ゲームデータ受信フラグ(trueのときに受信)
        /// </summary>
        private static bool readFlag = true;

        private Game sendGame;

        private FormInputPresenter instance;

        /// <summary>
        /// 別スレッドからメインスレッドのテキストボックスに書き込むデリゲート
        /// </summary>
        /// <param name="text"></param>
        delegate void WriteTextDelegate(string text);

        /// <summary>
        /// 引数を持たない汎用のデリゲート ストップボタンを押す等に使用
        /// </summary>
        delegate void MydelegateDelegate();

        /// <summary>
        /// タイマーの有効化に使用
        /// </summary>
        delegate void EnableTimerDelegate();


        public TCPClient(FormInputPresenter f)
        {
            InitializeComponent();
            instance = f;
        }

        /// <summary>
        /// Startボタン押下
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
            bool openflg = false;

            openflg = ClientStart();

            //ボタンのenableを変える
            if (openflg)
            {
                StartButton.Enabled = false;
                StopButton.Enabled = true;
            }
        }

        /// <summary>
        /// セカンドスレッドの作成とクライアントのスタート
        /// </summary>
        /// <returns></returns>
        private bool ClientStart()
        {
            if (UserNameTextBox.Text == null || UserNameTextBox.Text == string.Empty)
                UserNameTextBox.Text = "名無しさん";

            try
            {
                //クライアントのソケットを用意
                client = new TcpClient(IpTextButton.Text, int.Parse(PortNumberTextbox.Text));
                client.SendBufferSize = 50000;

                //サーバからのデータを受信するループをスレッドで処理
                threadClient = new Thread(new ThreadStart(this.ClientListen));
                threadClient.Start();

                SendPassword();
                
                //接続インディケータ
                IndicatorPctureBox.BackColor = Color.LightGreen;
                writeLog("クライアント接続されました");
                return (true);
            }
            catch (Exception ex)
            {
                writeLog("クライアント接続エラー:" + ex.Message.ToString());
                BMError.ErrorMessageOutput(ex.Message, true);
                IndicatorPctureBox.BackColor = Color.Navy;
                return (false);
            }
        }

        /// <summary>
        /// 別スレッドで実行されるクライアント側の処理
        /// </summary>
        private void ClientListen()
        {

            NetworkStream stream = client.GetStream();

            Byte[] bytes = new Byte[100000];
            WriteTextDelegate dlgText = new WriteTextDelegate(WriteReadText);

            while (true)
            {
                try
                {
                    int intCount = stream.Read(bytes, 0, bytes.Length);
                    if (intCount != 0)
                    {

                        //受信部分だけ切り出す
                        Byte[] getByte1 = new byte[intCount];
                        for (int i = 0; i < intCount; i++)
                            getByte1[i] = bytes[i];

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
                            string getText = ecUni.GetString(uniBytes);

                            WriteTextBox.Invoke(dlgText, getText);

                        }
                        else if (header == "GAME")
                        {
                            BinaryFormatter b = new BinaryFormatter();

                            using (MemoryStream m = new MemoryStream(body))
                            {
                                m.Seek(0, SeekOrigin.Begin);
                                Game g = (Game)b.Deserialize(m);

                                if (g.Equals(sendGame))
                                {
                                    readFlag = true;
                                }
                                else
                                {
                                    if (readFlag && !g.Equals(SaveDataManager.GetInstance().GetGame()))
                                    {
                                        instance.LoadGame(g);
                                    }

                                }
                            }
                        }
                        else if (header == "PASS")
                        {
                            byte[] uniBytes;
                            //'S-Jisからユニコードに変換
                            uniBytes = Encoding.Convert(ecSjis, ecUni, body);
                            string getText = ecUni.GetString(uniBytes);

                            if (getText != "OK")
                            {
                                this.StartButton.BeginInvoke(new MydelegateDelegate(StopSock),
                             new object[] { });

                                this.LogTextBox.BeginInvoke(new WriteTextDelegate(writeLog), 
                                    new object[] { "パスワードが間違っています" });
                                return;
                            }
                            else
                            {
                                //パスワードがあってるか確認してからユーザー名送信
                                SendUserName();
                                Invoke(new EnableTimerDelegate(EnableTimer));
                            }
                        }
                    }
                    else
                    {
                        //サーバーが切断された 
                        this.LogTextBox.BeginInvoke(new WriteTextDelegate(writeLog)
                             , new object[] { "ホストが切断されました。" });
                        this.StartButton.BeginInvoke(new MydelegateDelegate(StopSock),
                             new object[] { });
                        return;
                    }
                }
                catch (System.Threading.ThreadAbortException ex)
                {
                    //何もしません;
                    BMError.ErrorMessageOutput(ex.Message, false);
                    return;
                }
                catch (Exception ex)
                {
                    this.LogTextBox.BeginInvoke(new WriteTextDelegate(writeLog)
                            , new object[] { "受信エラー　　" + ex.Message });
                    BMError.ErrorMessageOutput(ex.Message, false);

                    //TODO:読み込みエラーが起きても通信は切断しないようにしてるけど再送要求に変えたり通信をリセットしたり他にやり方あるかも
                 //   return;
                }
            }
        }


        /// <summary>
        /// ソケット通信の終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopButton_Click(object sender, EventArgs e)
        {
            StopSock();
        }

        private void StopSock()
        {
            //クライアントストップ
            CloseClient();

            StartButton.Enabled = true;
            StopButton.Enabled = false;
            GameSendTimer.Enabled = false;
        }

        /// <summary>
        /// クライアントのクローズ
        /// </summary>
        private void CloseClient()
        {

            //スレッドは必ず終了させること
            if (threadClient != null)
                threadClient.Abort();

            //クライアントのインスタンスが有って、接続されていたら
            if (client != null && client.Connected)
                client.Close();

            //インディケータの色を変える      
            IndicatorPctureBox.BackColor = Color.Navy;
            //ログを書き込む
            writeLog("クライアントが閉じられました。");
        }

        /// <summary>
        /// 受信文字をテキストボックスに書き込む
        /// </summary>
        /// <param name="text"></param>
        private void WriteReadText(string text)
        {
            this.ReadTextBox.AppendText(text + "\r\n");
        }

        //Logを書き込む
        private void writeLog(string strlog)
        {
            this.LogTextBox.AppendText(DateTime.Now.ToString() + "  "
                                        + strlog + "\r\n");
        }

        private void EnableTimer()
        {
            this.GameSendTimer.Enabled = true;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            SendStringData();
            WriteTextBox.Clear();
        }

        private void SendPassword()
        {
            //sift-jisに変換して送る
            Byte[] data = ecSjis.GetBytes(PasswordTextBox.Text);

            Byte[] header = ecSjis.GetBytes("PASS");

            List<Byte> l = new List<byte>();

            l.AddRange(header);
            l.AddRange(data);

            Byte[] sendData = l.ToArray();
            
            sendData = Compressor.Compress(sendData);

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
                BMError.ErrorMessageOutput(exc.Message, true);
            }
        }

        private void SendUserName()
        {

            //sift-jisに変換して送る
            Byte[] data = ecSjis.GetBytes(UserNameTextBox.Text);

            Byte[] header = ecSjis.GetBytes("NAME");

            List<Byte> l = new List<byte>();

            l.AddRange(header);
            l.AddRange(data);

            Byte[] sendData = l.ToArray();
            sendData = Compressor.Compress(sendData);

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
                BMError.ErrorMessageOutput(exc.Message, true);
            }
        }

        /// <summary>
        /// 文字データの送信
        /// </summary>
        private void SendStringData()
        {
            //sift-jisに変換して送る
            Byte[] data = ecSjis.GetBytes(WriteTextBox.Text);

            Byte[] header = ecSjis.GetBytes("TEXT");

            List<Byte> l = new List<byte>();

            l.AddRange(header);
            l.AddRange(data);

            Byte[] sendData = l.ToArray();
            sendData = Compressor.Compress(sendData);

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
                BMError.ErrorMessageOutput(exc.Message, true);
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
        /// プログラムの終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TCPClient_FormClosing(object sender, FormClosingEventArgs e)
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

            //データ圧縮
            sendData = Compressor.Compress(sendData);

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


                writeLog("sendGameData... byte is " + sendData.Length + "byte");

                stream.Write(sendData, offset, sendData.Length - offset);
                readFlag = false;

                sendGame = game.CloneDeep();
            }
            catch (Exception exc)
            {
                writeLog("送信エラー:" + exc.Message);
                BMError.ErrorMessageOutput(exc.Message, true);
            }
        }

    }
}
