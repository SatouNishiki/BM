using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using BasketballManagementSystem.BaseClass.Game;
using BasketballManagementSystem.Manager.SaveDataManager;
using BasketballManagementSystem.BMForm.Input;
using BasketballManagementSystem.BaseClass.Settings;
using BasketballManagementSystem.Manager.PrintManager;

namespace BasketballManagementSystem.BMForm.Transmission
{
    public partial class UDPClient : Form
    {
        /// <summary>
        /// エンコーディング用変数
        /// </summary>
        private Encoding encoding;

        /// <summary>
        /// UDP通信のクライアント側を表す
        /// </summary>
        private UdpClient client;

        /// <summary>
        /// 受信用スレッド
        /// </summary>
        public Thread threadReceive;

        /// <summary>
        /// 入力画面のインスタンス
        /// </summary>
        private FormInput instance;

        /// <summary>
        /// trueになっているときのみgamedataを受信(falseでもgamedata以外は受信)
        /// </summary>
        private static bool canRead;

        /// <summary>
        /// gamedataの変更比較用変数 変更があったときのみ送信するようにして軽量化とかいろいろ
        /// </summary>
        private Game beforeGame;


        public UDPClient(FormInput f)
        {
            InitializeComponent();

            instance = f;
            encoding = Encoding.UTF8;
            buttonSend.Enabled = false;
            textBoxSend.Enabled = false;
            canRead = true;
            beforeGame = (Game)SaveDataManager.GetInstance().GetGame().CloneDeep();
            sendIntervalComboBox.SelectedIndex = AppSetting.GetInstance().UDPSendInterval;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] sendBytes = encoding.GetBytes("TEXT" + textBoxSend.Text);
                client.Send(sendBytes, sendBytes.Length, textBoxIP.Text, int.Parse(textBoxPort.Text));
            }
            catch (Exception ex)
            {
                trace("send Error: " + ex.Message);
                return;
            }
            trace("send: " + textBoxSend.Text);
            textBoxSend.Text = "";
        }

        private void threadReceive_start()
        {
            IPEndPoint remoteEP = null;
            while (client != null)
            {

                try
                {

                    if (client.Available > 0)
                    {

                        byte[] recvByte = client.Receive(ref remoteEP);

                        //ヘッダー切り出し後のバイト配列
                        byte[] recvByte2 = new byte[recvByte.Length - 4];

                        //ヘッダー切り出し
                        byte[] temp = new byte[4];
                        Array.Copy(recvByte, 0, temp, 0, 4);

                        Array.Copy(recvByte, 4, recvByte2, 0, recvByte.Length - 4);

                        //ヘッダーがTEXTなら
                        if (encoding.GetString(temp) == "TEXT")
                        {

                            trace("receive: " + encoding.GetString(recvByte2) +
                                " (form" + remoteEP.Address + ":" + remoteEP.Port + ")");
                        }
                        else if (encoding.GetString(temp) == "GAME")
                        {     

                            BinaryFormatter b = new BinaryFormatter();
                            MemoryStream m = new MemoryStream(recvByte2);
                            Game g = (Game)b.Deserialize(m);

                            if (canRead)
                            {
                                instance.LoadProcess(g);
                            }
                            m.Close();
                        }
                    }

                }
                catch (Exception ex)
                {
                    trace("receive Error: " + ex.Message);
                }
      //          Thread.Sleep(100);
         
            }

        }

        private void checkBoxNetwork_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNetwork.Checked) // 通信開始
            {
                try
                {
                    if (client == null)
                    {
                        client = new UdpClient(int.Parse(textBoxReceivePort.Text));
                        client.DontFragment = true;
                        client.EnableBroadcast = true;
                    }
                    if (threadReceive == null)
                    {
                        threadReceive = new Thread(threadReceive_start);
                        threadReceive.Start();
                    }

                    timerTransmission.Enabled = true;
                }
                catch (Exception ex)
                {
                    trace("Network Open Error: " + ex.Message);
                    checkBoxNetwork.Checked = false;
                    return;
                }
                trace("Network Open - port:" + textBoxReceivePort.Text);
                textBoxReceivePort.Enabled = false;
                buttonSend.Enabled = true;
                textBoxSend.Enabled = true;
            }
            else // 通信終了
            {
                try
                {
                    if (client != null)
                    {
                        client.Close();
                        client = null;
                    }
                    if (threadReceive != null)
                    {
                        threadReceive.Abort();
                        threadReceive = null;
                    }

                    timerTransmission.Enabled = false;
                }
                catch (Exception ex)
                {
                    trace("Network Close Error: " + ex.Message);
                    checkBoxNetwork.Checked = true;
                    return;
                }
                buttonSend.Enabled = false;
                textBoxSend.Enabled = false;
                trace("Network Closed - port:" + textBoxReceivePort.Text);
                textBoxReceivePort.Enabled = true;
                timerTransmission.Enabled = false;
            }
        }

        private void UDPClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (threadReceive != null) threadReceive.Abort();
            if (client != null)
            {
                client.Close();
                client = null;
            }
        }

        private void trace(string message)
        {
            try
            {
                Invoke((MethodInvoker)delegate()
                {
                    Console.WriteLine(message);
                    textBoxTrace.Text = message + "\r\n" + textBoxTrace.Text;
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void timerTransmission_Tick(object sender, EventArgs e)
        {
            Game game = SaveDataManager.GetInstance().GetGame();

            if (beforeGame.Equals(game))
            {
                canRead = true;
                return;
            }
            else
            {
                canRead = false;
                beforeGame = game.CloneDeep();
            }
            
            BinaryFormatter b = new BinaryFormatter();
            MemoryStream m = new MemoryStream();
            
            b.Serialize(m, game);
            byte[] byt = m.ToArray();
            byte[] header = encoding.GetBytes("GAME");
/*}
            //送信するデータのサイズ
            int byteSize = byt.Length;

            int count = 0;

            //何分割すれば1100バイト以下になるか計算
            //(回線にもよるがヘッダー込みで1200バイト以下にすればシステムの分割機能が働かないことが保障されている)
            while (true)
            {
                count++;
                if ((byteSize / count) <= 1100) break;
            }

            List<byte> _temp = new List<byte>();

            byte[,] _bytArray = new byte[count, byteSize / count];

            for (int i = 0; i < count; i++)
            {
                Array.Copy(byt, i * (byteSize / count), _bytArray[i], 0, (i + 1) * (byteSize / count));
            }
          */  


            //バイナリシリアライズしたゲームデータオブジェクトにヘッダーをくっつけて送信バイト配列を生成
            List<byte> temp = new List<byte>(byt.Length + header.Length);
            temp.AddRange(header);
            temp.AddRange(byt);

            byte[] senderBytes = temp.ToArray();

            m.Close();

            try
            {
                client.Send(senderBytes, senderBytes.Length, textBoxIP.Text, int.Parse(textBoxPort.Text));

            }
            catch (Exception ex)
            {
                trace("send Error: " + ex.Message);
            }
 
        }

        private void sendIntervalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerTransmission.Interval = int.Parse(sendIntervalComboBox.SelectedItem.ToString());
            AppSetting.GetInstance().UDPSendInterval = sendIntervalComboBox.SelectedIndex;
            AppSetting.GetInstance().SettingChanged();
        }

        private void printForm_Click(object sender, EventArgs e)
        {
            FormPrinter fp = new FormPrinter();
            fp.PrintForm(this);
        }

        private void printPreview_Click(object sender, EventArgs e)
        {
            FormPrinter fp = new FormPrinter();
            fp.ShowPrintPreview(this);
        }
    }
}
