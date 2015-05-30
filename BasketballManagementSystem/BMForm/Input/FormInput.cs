using System.Windows.Forms;
using BasketballManagementSystem.BaseClass.Player;
using BasketballManagementSystem.BaseClass.Action;
using BasketballManagementSystem.BMForm.Input.EventHelper;
using System;
using QuarterTimer;
using BasketballManagementSystem.BaseClass.Game;
using BasketballManagementSystem.Manager.SaveDataManager;
using BasketballManagementSystem.BMForm.GraphScore;
using BasketballManagementSystem.BMForm.BoxScore;
using BasketballManagementSystem.BaseClass.TimeOut;
using BasketballManagementSystem.Manager.PrintManager;
using BasketballManagementSystem.BMForm.PlayerData;
using BasketballManagementSystem.BaseClass.Settings;
using System.Drawing;
using System.Collections.Generic;
using BasketballManagementSystem.BMForm.Tactick2D;
using System.Globalization;
using System.Threading;
using BasketballManagementSystem.BMForm.Input.Language;
using BasketballManagementSystem.BMForm.GameDataEdit;
using BasketballManagementSystem.BMForm.Transmission;
using BasketballManagementSystem.BMForm.Input.LoadHelper;
using System.Runtime.CompilerServices;
using BasketballManagementSystem.BMForm.TeamMake;
using BasketballManagementSystem.BMForm.ActionPointEdit;
using BasketballManagementSystem.BMForm.ActionPointGraph;
using BasketballManagementSystem.BMForm.StrategySimulation;
using BasketballManagementSystem.BMForm.Transmission.TCP;
using BasketballManagementSystem.BMForm.ClubEdit;

namespace BasketballManagementSystem.BMForm.Input
{
    public partial class FormInput : Form
    {

        /// <summary>
        /// アクションクリックのイベントの処理を行うクラス
        /// </summary>
        private ActionClickEventHelper actionClickEventHelper = new ActionClickEventHelper();

        /// <summary>
        /// チームチェンジのイベントの処理を行うクラス
        /// </summary>
        private TeamChengeEventHelper teamChangeEventHelper = new TeamChengeEventHelper();

        /// <summary>
        /// セーブデータの管理を行うクラス
        /// </summary>
        private SaveDataManager saveDataManager = SaveDataManager.GetInstance();

        /// <summary>
        /// コート入力に関するイベントの処理を行うクラス
        /// </summary>
        private CortEventHelper cortEventHelper = new CortEventHelper();

        /// <summary>
        /// キーボードショートカット処理を行うクラス
        /// </summary>
        private KeyboardEventHelper keyboardEventHelper = new KeyboardEventHelper();

        /// <summary>
        /// デバッグメッセージを表示するフォーム
        /// </summary>
        private DebugMessageForm debugMessageForm = new DebugMessageForm();

        /// <summary>
        /// そのクォーターのタイムアウト回数の上限
        /// </summary>
        private int timeOutRimit = 2;
        
        /// <summary>
        /// 試合停止ボタンの画像
        /// </summary>
        private Bitmap StopGraph;

        /// <summary>
        /// 試合再開ボタンの画像
        /// </summary>
        private Bitmap RestartGraph;

        /// <summary>
        /// 色を変更するボタンを格納するリスト
        /// </summary>
        private List<Button> colorChangeButton = new List<Button>();

        /// <summary>
        /// 初回のロード処理が終わるまでtrueを示すフラグ
        /// </summary>
        private bool preLoad = true;

        /// <summary>
        /// Undo,Redoに使われるゲームデータのスタックオブジェクト
        /// </summary>
        private Stack<Game> gameDataStack = new Stack<Game>();

        private Stack<Game> redoGameDataStack = new Stack<Game>();


        /// <summary>
        /// 現在の自分のタイムアウトの数
        /// </summary>
        private int nowMyTimeOut
        {
            get
            {
                if (Quarter == 1 || Quarter == 2)
                    return Game.MyTeam.GetTimeOutCount(TimeOut.FirstHalf);

                else if (Quarter == 3 || Quarter == 4)
                    return Game.MyTeam.GetTimeOutCount(TimeOut.SecondHalf);

                else
                    return Game.MyTeam.GetTimeOutCount(Quarter);
            }
        }

        /// <summary>
        /// 現在の相手のタイムアウトの数
        /// </summary>
        private int nowOppentTimeOut 
        {
            get
            {
                if (Quarter == 1 || Quarter == 2)
                    return Game.OppentTeam.GetTimeOutCount(TimeOut.FirstHalf);

                else if (Quarter == 3 || Quarter == 4)
                    return Game.OppentTeam.GetTimeOutCount(TimeOut.SecondHalf);

                else
                    return Game.OppentTeam.GetTimeOutCount(Quarter);
            }
        }

        /// <summary>
        /// ゲームデータ
        /// </summary>
        public Game Game { get; set; }

        /// <summary>
        /// 現在選択されているプレイヤーの変数
        /// </summary>
        public Player SelectedPlayer { get; set; }

        /// <summary>
        /// ファウルが行われたときに与えるフリースローの数
        /// </summary>
        public int GivenFreeThrow
        {
            get
            {
                int r = 0;
                try
                {
                    r = int.Parse(this.givenFreeThowLabel.Text.ToString());
                    return r;
                }
                catch (Exception exc)
                {
                    BMErrorLibrary.BMError.ErrorMessageOutput(exc.ToString());
                    return -1;
                }
            }
            private set { GivenFreeThrow = value; }
        }

        /// <summary>
        /// 自分のチーム(全員)
        /// </summary>
        public Team MyTeam 
        { 
            get { return Game.MyTeam; } 
            set { Game.MyTeam = value; } 
        }

        /// <summary>
        /// 相手のチーム(全員)
        /// </summary>
        public Team OppentTeam
        { 
            get { return Game.OppentTeam; } 
            set { Game.OppentTeam = value; }
        }

        /// <summary>
        /// クォーターの残り時間
        /// </summary>
        public TimeSpan RemainingTime
        {
            get{  return QuarterTimer.remainingTime; }
        }

        /// <summary>
        /// 現在のクォーター
        /// </summary>
        public int Quarter
        {
            get { return QuarterTimer.quarter; }
        }

        /// <summary>
        /// クォーターの経過時間
        /// </summary>
        public TimeSpan ElaspedTime {
            get { return QuarterTimer.elapsedTime; }
        }

        public FormInput()
        {
            InitializeComponent();
            Init();
           
        }

        /// <summary>
        /// 初期化処理メソッド
        /// </summary>
        private void Init()
        {

            /******************************プロパティ初期化******************************************/

            preLoad = false;
            Game = new Game();

            //現在のコードを実行しているAssemblyを取得
            System.Reflection.Assembly assembly =
                System.Reflection.Assembly.GetExecutingAssembly();

            RestartGraph = new Bitmap(assembly.GetManifestResourceStream
                            ("BasketballManagementSystem.BMForm.Input.Picture.susumu.png"));

            StopGraph = new Bitmap(assembly.GetManifestResourceStream
                            ("BasketballManagementSystem.BMForm.Input.Picture.teisi.png"));

            foreach (var c in Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    colorChangeButton.Add((Button)c);
                }
            }

            MyTeam = new Team();
            OppentTeam = new Team();

            SelectedPlayer = new Player("No Name", 0);

            /******************************************************************************************/



            /*************************コントロール初期化**********************************************/

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            // すべてのカルチャ情報（＝CultureInfoオブジェクトの配列）を取得
            CultureInfo[] cultures =
              CultureInfo.GetCultures(CultureTypes.AllCultures);

            // ComboBoxに取得したカルチャ情報を設定する
            foreach (var c in cultures)
            {
                if (c.Name == "ja" || c.Name == "en")
                    this.ChangeLanguageComboBox.Items.Add(c.DisplayName);
            }

            ChangeLanguageComboBox.SelectedIndex = AppSetting.GetInstance().CultureSelectedIndex;
            QuarterChangeTimerSpeedCombo.SelectedIndex = 0;


            /******************************************************************************************/


            
            /************************************設定読み込み****************************************/

            this.BackColor = AppSetting.GetInstance().FormInputBackGroundColor;
            this.MyTeamPointLabel.BackColor = AppSetting.GetInstance().FormInputPointBackGroundColor;
            this.OppentTeamPointLabel.BackColor = AppSetting.GetInstance().FormInputPointBackGroundColor;
            TimerTickComboBox.SelectedIndex = AppSetting.GetInstance().FormInputFPS;
            DebugFormVisiableItem.Checked = AppSetting.GetInstance().DebugWindowChecked;

            foreach (var b in colorChangeButton)
            {
                b.BackColor = AppSetting.GetInstance().FormInputButtonColor;

                //UseVisualStyleBackColorは若干フィーリングで設定してる(これをやらないとボタンの立体感が消える)
                if (AppSetting.GetInstance().FormInputButtonColorAsRGB == "")
                    b.UseVisualStyleBackColor = true;
                b.ForeColor = AppSetting.GetInstance().FormInputButtonTextColor;
            }

            /*****************************************************************************************/

           

            /***********************************デバッグウインドウ設定*******************************/


            if (DebugFormVisiableItem.Checked)
            {
                debugMessageForm.Show();

                this.TopMost = true;
                this.TopMost = false;
            }

            /*****************************************************************************************/

           
        }

        /// <summary>
        /// うけとった文字列をそれっぽくデバッグメッセージに出す
        /// </summary>
        /// <param name="message"></param>
        public void AddDebugMessage(string message)
        {

            if(debugMessageForm != null && !debugMessageForm.IsDisposed)
            debugMessageForm.addDebugMessage(message);

        }

        private void FormInputTimer_Tick(object sender, System.EventArgs e)
        {

            /*********************** 選択選手 ****************************************/

            PlayerNameLabel.Text = SelectedPlayer.ToString();

            /***********************************************************************/


            /********************** チーム情報 ********************************************/

            MyTeamNameLael.Text = MyTeam.Name;

            OppentTeamNameLabel.Text = OppentTeam.Name;

            /***********************************************************************/



            /************************** ファウル情報 *******************************************/

            if (Quarter <= 4)
                MyTeamFaulLabel.Text = MyTeam.TeamFaul[Quarter].ToString();
            else
                MyTeamFaulLabel.Text = MyTeam.TeamFaul[4].ToString();

            if (Quarter <= 4)
                OppentTeamFaulLabel.Text = OppentTeam.TeamFaul[Quarter].ToString();
            else
                OppentTeamFaulLabel.Text = OppentTeam.TeamFaul[4].ToString();

            /***********************************************************************/


            /********************************* 点数 **************************************/

            MyTeamPointLabel.Text = MyTeam.AllPoint.ToString();
            OppentTeamPointLabel.Text = OppentTeam.AllPoint.ToString();

            /***********************************************************************/


            /******************************** タイムアウト ***************************************/
            MyTimeOutLabel.Text = nowMyTimeOut + "/" + timeOutRimit;

            OppentTimeOutLabel.Text = nowOppentTimeOut + "/" + timeOutRimit;

            /***********************************************************************/


            /******************************* DebugWindow **********************************************/

            if ((debugMessageForm == null || debugMessageForm.IsDisposed) && DebugFormVisiableItem.Checked)
            {
                DebugFormVisiableItem.Checked = false;
                AppSetting.GetInstance().DebugWindowChecked = false;
                AppSetting.GetInstance().SettingChanged();
            }

            /*****************************************************************************************/

            if (gameDataStack.Count == 0) UndoToolStripButton.Enabled = false;
            else UndoToolStripButton.Enabled = true;

            if (redoGameDataStack.Count == 0) RedoToolStripButton.Enabled = false;
            else RedoToolStripButton.Enabled = true;

            this.SaveToSaveManager();
        }


        /// <summary>
        /// 自チーム変更ボタンが押されたときに呼び出し
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeMyTeamButton_Click(object sender, System.EventArgs e)
        {
            teamChangeEventHelper.onMyTeamChange(this,  MyCortTeamListBox, MyOutTeamListBox);

            SyncTeam();
        }

        /// <summary>
        /// 相手チーム変更ボタンが押されたときに呼び出し
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeOppentTeamButton_Click(object sender, System.EventArgs e)
        {
            teamChangeEventHelper.onOppentTeamChange(this, OppentCortTeamListBox, OppentOutTeamListBox);

            SyncTeam();
        }

        private void SyncTeam()
        {
            MyTeam.CortMember.Clear();

            foreach (Player p in MyCortTeamListBox.Items)
            {
                MyTeam.CortMember.Add(p);
            }

            MyTeam.OutMember.Clear();

            foreach (Player p in MyOutTeamListBox.Items)
            {
                MyTeam.OutMember.Add(p);
            }

            OppentTeam.CortMember.Clear();

            foreach (Player p in OppentCortTeamListBox.Items)
            {
                OppentTeam.CortMember.Add(p);
            }

            OppentTeam.OutMember.Clear();

            foreach (Player p in OppentOutTeamListBox.Items)
            {
                OppentTeam.OutMember.Add(p);
            }
        }


        /****************************** アクション入力部 **************************************************************/

        private void AssistButton_Click(object sender, System.EventArgs e)
        {
            actionClickEventHelper.ActionInputAccept(this, new Assist(), null);
        }

        private void PersonalFaulButton_Click(object sender, System.EventArgs e)
        {
            actionClickEventHelper.ActionInputAccept(this, new PersonalFaul(), null);
        }

        private void TurnOverButton_Click(object sender, System.EventArgs e)
        {
            actionClickEventHelper.ActionInputAccept(this, new TurnOver(), null);
        }

        private void StealButton_Click(object sender, System.EventArgs e)
        {
            actionClickEventHelper.ActionInputAccept(this, new Steal(), null);
        }

        private void BlockShotButton_Click(object sender, System.EventArgs e)
        {
            actionClickEventHelper.ActionInputAccept(this, new ShootBlock(), null);
        }

        private void TechnicalFaulButton_Click(object sender, EventArgs e)
        {
            actionClickEventHelper.ActionInputAccept(this, new TechnicalFaul(), null);
        }

        private void UnSportsmanLikeFaulButton_Click(object sender, EventArgs e)
        {
            actionClickEventHelper.ActionInputAccept(this, new UnSportsmanLikeFaul(), null);
        }

        private void DisQualifyingFaulButton_Click(object sender, EventArgs e)
        {
            actionClickEventHelper.ActionInputAccept(this, new DisQualifyingFaul(), null);
        }

        private void CortPicture_Click(object sender, System.EventArgs e)
        {
            cortEventHelper.onCortClick(this, CortPictureBox, sender, e);
        }

        /***************************************************************************************************/

        /************************************** その他入力等 ***********************************************/

        /// <summary>
        /// チームのリストがクリックされたとき選択選手を記憶する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeamList_Click(object sender, System.EventArgs e)
        {
            //リストに何も入っていなかったら終了
            if (((ListBox)sender).Items.Count == 0) return;

            //何もない場所が選択されていたら終了
            if (((ListBox)sender).SelectedIndex < 0) return;
            
            try
            {
                //選択選手の記憶
                SelectedPlayer = (Player)(((ListBox)sender).Items[((ListBox)sender).SelectedIndex]);
            }
            catch(System.Exception exception)
            {
                SelectedPlayer = new Player("No Name", 0);
               
                BMErrorLibrary.BMError.ErrorMessageOutput(exception.Message);
            }
        }

        private void TimeOut_Click(object sender, EventArgs e)
        {
            if (nowMyTimeOut < timeOutRimit)
            {
                try
                {
                    StackGameData();
                    Game.MyTeam.TimeOutList.Add(new BaseClass.TimeOut.TimeOut(Quarter, DateTime.Now, QuarterTimer.remainingTime));
                }
                catch (Exception exc)
                {
                    BMErrorLibrary.BMError.ErrorMessageOutput(exc.ToString());
                }
                if (StopGameItem.Enabled)
                {
                    QuarterTimer.StopGame();
                    StopGameItem.Enabled = false;
                    RestartGameItem.Enabled = true;
                    QuarterTimerStopButton.Image = RestartGraph;
                }
            }
            else
            {
                MessageBox.Show("タイムアウトの回数が上限を超えています",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void OppentTimeOut_Click(object sender, EventArgs e)
        {
            if (nowOppentTimeOut < timeOutRimit)
            {
                try
                {
                    StackGameData();
                    Game.OppentTeam.TimeOutList.Add(new BaseClass.TimeOut.TimeOut(Quarter, DateTime.Now, QuarterTimer.remainingTime));
                }
                catch (Exception exc)
                {
                    BMErrorLibrary.BMError.ErrorMessageOutput(exc.ToString());
                }
                if (StopGameItem.Enabled)
                {
                    QuarterTimer.StopGame();
                    StopGameItem.Enabled = false;
                    RestartGameItem.Enabled = true;
                    QuarterTimerStopButton.Image = RestartGraph;
                }
            }
            else
            {
                MessageBox.Show("タイムアウトの回数が上限を超えています",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (int.Parse(this.givenFreeThowLabel.Text.ToString()) < 3)
            {

                int a = int.Parse(this.givenFreeThowLabel.Text.ToString()) + 1;
                this.givenFreeThowLabel.Text = a.ToString();
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (int.Parse(this.givenFreeThowLabel.Text.ToString()) > 1)
            {
                int a = int.Parse(this.givenFreeThowLabel.Text.ToString()) - 1;
                this.givenFreeThowLabel.Text = a.ToString();
            }
        }

        private void TeamChangeButton_Click(object sender, EventArgs e)
        {
            List<object> obj1 = new List<object>();
            List<object> obj2 = new List<object>();

            foreach (var o in MyCortTeamListBox.SelectedItems) obj1.Add(o);
            foreach (var o in MyOutTeamListBox.SelectedItems) obj2.Add(o);

            if (MyCortTeamListBox.ExchangeSelectedItem(MyOutTeamListBox))
            {
                MemberChange m = new MemberChange();

                foreach (Player p in obj1)
                {
                    m.ChangedCortMembers.Add(p);
                }

                foreach (Player p in obj2)
                {
                    m.ChangedOutMembers.Add(p);
                }

                m.ChengedMemberTime = DateTime.Now;
                m.RemainingTime = QuarterTimer.remainingTime;
                m.Quarter = Quarter;
                StackGameData();
                Game.MyTeam.MemberChange.Add(m);
            }

            obj1.Clear();
            obj2.Clear();

            foreach (object o in OppentCortTeamListBox.SelectedItems) obj1.Add(o);
            foreach (object o in OppentOutTeamListBox.SelectedItems) obj2.Add(o);

            if (OppentCortTeamListBox.ExchangeSelectedItem(OppentOutTeamListBox))
            {
                MemberChange m = new MemberChange();

                foreach (Player p in obj1)
                {
                    m.ChangedCortMembers.Add(p);
                }

                foreach (Player p in obj2)
                {
                    m.ChangedOutMembers.Add(p);
                }

                m.ChengedMemberTime = DateTime.Now;
                m.RemainingTime = QuarterTimer.remainingTime;
                m.Quarter = Quarter;
                StackGameData();
                Game.OppentTeam.MemberChange.Add(m);
            }

            PlayerListSortEventHelper.Sort(MyCortTeamListBox);

            PlayerListSortEventHelper.Sort(MyOutTeamListBox);

            PlayerListSortEventHelper.Sort(OppentCortTeamListBox);

            PlayerListSortEventHelper.Sort(OppentOutTeamListBox);
        }

        /***********************************************************************************************************/

        /*********************************** ゲームの進行に関するメソッド郡 ****************************************/

        /// <summary>
        /// ゲームの試合開始がクリックされたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartGame_Click(object sender, EventArgs e)
        {
            QuarterTimer.StartGame();

            NextQuarterItem.Enabled = true;

            GameEndItem.Enabled = true;
            //ゲーム開始ボタンはゲーム終了まで操作不能にしておく
            StartGameItem.Enabled = false;

            StopGameItem.Enabled = true;
            QuarterTimerStopButton.Enabled = true;
            Game.StartTime = QuarterTimer.startTime;
        }

        private void NextQuarterButton_Click(object sender, EventArgs e)
        {
            QuarterTimer.GoNextQuarter();
            QuarterText.Text = QuarterTimer.displayQuarter;

            if (Quarter == 3)
            {
                timeOutRimit = 3;
            }

            if (Quarter >= 5)
            {
                timeOutRimit = 1;
            }
           
        }

        private void StopGameButton_Click(object sender, EventArgs e)
        {
            QuarterTimerStop_Click(sender, e);
        }

        private void RestartGameButton_Click(object sender, EventArgs e)
        {
            QuarterTimerStop_Click(sender, e);
        }

        private void GameEndButton_Click(object sender, EventArgs e)
        {
            StartGameItem.Enabled = true;
            NextQuarterItem.Enabled = false;
            StopGameItem.Enabled = false;
            QuarterTimer.EndGame();
            Game.EndTime = QuarterTimer.endTime;
        }

        private void QuarterTimerFastFoward_MouseDown(object sender, MouseEventArgs e)
        {
            QuarterTimer.fastFowardFlag = true;
        }

        private void QuarterTimerFastFoward_MouseUp(object sender, MouseEventArgs e)
        {
            QuarterTimer.fastFowardFlag = false;
        }

        private void QuarterTimerRewind_MouseDown(object sender, MouseEventArgs e)
        {
            QuarterTimer.rewindFlag = true;
        }

        private void QuarterTimerRewind_MouseUp(object sender, MouseEventArgs e)
        {
            QuarterTimer.rewindFlag = false;
        }

        private void QuarterTimerStop_Click(object sender, EventArgs e)
        {
            if (StopGameItem.Enabled)
            {
                QuarterTimer.StopGame();
                StopGameItem.Enabled = false;
                RestartGameItem.Enabled = true;
                QuarterTimerStopButton.Image = RestartGraph;
            }
            else
            {
                QuarterTimer.RestartGame();
                StopGameItem.Enabled = true;
                RestartGameItem.Enabled = false;
                QuarterTimerStopButton.Image = StopGraph;
            }
        }

        /*******************************************************************************************/


        /******************************** セーブロード関連 ******************************************/

        /// <summary>
        /// セーブデータ管理クラスへの一時的なデータの保存
        /// </summary>
        private void SaveToSaveManager()
        {
            saveDataManager.SetGame(Game);
        }

        private void GameDataSave_Click(object sender, EventArgs e)
        {
            GameSaveLoadEventHelper g = new GameSaveLoadEventHelper();
            g.GameSave(saveDataManager.GetGame());
        }

        /// <summary>
        /// ゲームロードがクリックされたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameDataLoad_Click(object sender, EventArgs e)
        {
            GameSaveLoadEventHelper g = new GameSaveLoadEventHelper();

            Game temp = g.GameLoad();

            if (temp != null)
            {
                Game = temp;

                saveDataManager.SetGame(Game);

                LoadProcess(Game);

                gameDataStack.Clear();
            }
        }

        /// <summary>
        /// ゲームデータをロードするときの処理
        /// </summary>
        /// <param name="game"></param>
        public void LoadProcess(Game game)
        {
            FormInputLoader f = FormInputLoader.GetFormInputLoaderInstance();
            f.LoadForm(this, game);
        }

        /***********************************************************************************************/


        /**************************** その他メニュー画面用メソッド郡************************************/

        private void NewGameItem_Click(object sender, EventArgs e)
        {
            //TODO:メモリリークの可能性あり? 要検証
            this.Controls.Clear();
            Game = new Game();
            gameDataStack.Clear();
            redoGameDataStack.Clear();
            InitializeComponent();
            Init();

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GameNameText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Game.Name = GameNameText.Text;
            }
            catch(Exception ex)
            {
                GameNameText.Text = "Game1";
                Game.Name = "Game1";
                BMErrorLibrary.BMError.ErrorMessageOutput(ex.ToString());
            }
        }

        private void GameLocationText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Game.Location = GameLocationText.Text;
            }
            catch(Exception ex)
            {
                Game.Location = "NoInputLocation";
                GameLocationText.Text = "NoInputLocation";
                BMErrorLibrary.BMError.ErrorMessageOutput(ex.ToString());
            }
        }

        private void PrintForm_Click(object sender, EventArgs e)
        {
            FormPrinter frp = new FormPrinter();
            frp.PrintForm(this);
        }

        private void PrintPreview_Click(object sender, EventArgs e)
        {
            FormPrinter frp = new FormPrinter();
            frp.ShowPrintPreview(this);
        }

        private void ChangeBackGroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog.Color = this.BackColor;

            // ダイアログを表示し、戻り値が [OK] の場合は選択した色を textBox1 に適用する
            if (ColorDialog.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = ColorDialog.Color;
                AppSetting.GetInstance().FormInputBackGroundColor = ColorDialog.Color;
            }

            // 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
            ColorDialog.Dispose();
        }

        private void PointColorChange_Click(object sender, EventArgs e)
        {
            // 初期選択する色を設定する
            ColorDialog.Color = MyTeamPointLabel.BackColor;

            // ダイアログを表示し、戻り値が [OK] の場合は選択した色を textBox1 に適用する
            if (ColorDialog.ShowDialog() == DialogResult.OK)
            {
                MyTeamPointLabel.BackColor = ColorDialog.Color;
                OppentTeamPointLabel.BackColor = ColorDialog.Color;
                AppSetting.GetInstance().FormInputPointBackGroundColor = ColorDialog.Color;
            }

            // 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
            ColorDialog.Dispose();
        }

        private void ChangeFormBackGroundColorDefault_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Empty;
            AppSetting.GetInstance().FormInputBackGroundColor = this.BackColor;
        }

        private void ChangePointLabelColorDefault_Click(object sender, EventArgs e)
        {
            MyTeamPointLabel.BackColor = Color.Empty;
            OppentTeamPointLabel.BackColor = Color.Empty;
            AppSetting.GetInstance().FormInputPointBackGroundColor = Color.Empty;
        }

        private void ChangeButtonColor_Click(object sender, EventArgs e)
        {
          
            // 初期選択する色を設定する
            ColorDialog.Color = MyTeamPointLabel.BackColor;

            // ダイアログを表示し、戻り値が [OK] の場合は選択した色を textBox1 に適用する
            if (ColorDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var b in colorChangeButton)
                {
                    b.BackColor = ColorDialog.Color;
                }

                AppSetting.GetInstance().FormInputButtonColor = ColorDialog.Color;
            }

            // 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
            ColorDialog.Dispose();
        }

        private void ChangeButtonColorDefault_Click(object sender, EventArgs e)
        {
            foreach (var b in colorChangeButton)
            {
                b.BackColor = Color.Empty;
                b.UseVisualStyleBackColor = true;
            }
            AppSetting.GetInstance().FormInputButtonColor = Color.Empty;
        }

        private void ChangeButtonTextColor_Click(object sender, EventArgs e)
        {
            // 初期選択する色を設定する
            ColorDialog.Color = MyTeamPointLabel.BackColor;

            // ダイアログを表示し、戻り値が [OK] の場合は選択した色を textBox1 に適用する
            if (ColorDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var b in colorChangeButton)
                {
                    b.ForeColor = ColorDialog.Color;
                }

                AppSetting.GetInstance().FormInputButtonTextColor = ColorDialog.Color;
            }

            // 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
            ColorDialog.Dispose();
        }

        private void ChangeButtonTextColorDefault_Click(object sender, EventArgs e)
        {
            foreach (var b in colorChangeButton)
            {
                b.ForeColor = Color.Black;
                b.UseVisualStyleBackColor = true;
            }
            AppSetting.GetInstance().FormInputButtonTextColor = Color.Black;
        }

        private void TimerTickComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!preLoad)
            {
                FormInputTimer.Interval = int.Parse(TimerTickComboBox.SelectedItem.ToString());
                AppSetting.GetInstance().FormInputFPS = TimerTickComboBox.SelectedIndex;
                AppSetting.GetInstance().SettingChanged();
            }
        }

        private void DebugFormVisiable_Click(object sender, EventArgs e)
        {
            if (!((ToolStripMenuItem)sender).Checked)
            {
                debugMessageForm = new DebugMessageForm();
                debugMessageForm.Show();
                this.TopMost = true;
                this.TopMost = false;
            }
            else
            {
                debugMessageForm.Close();
            }

            //チェック状態反転
            ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;

            AppSetting.GetInstance().DebugWindowChecked = ((ToolStripMenuItem)sender).Checked;
            AppSetting.GetInstance().SettingChanged();
        }

        private void QuarterChangeTimerSpeedCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuarterTimer.SetChangeSpeedTimerInterval(int.Parse(QuarterChangeTimerSpeedCombo.SelectedItem.ToString()));
        }

        private void ChangeLanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppSetting.GetInstance().Culture = CultureHelper.GetCultureInfoStringFromDisplayName((string)this.ChangeLanguageComboBox.SelectedItem);
            AppSetting.GetInstance().CultureSelectedIndex = this.ChangeLanguageComboBox.SelectedIndex;
        }

        /***********************************************************************************************/

        /******************************* 画面遷移に関するメソッド郡 ************************************/

        private void GoGraphScorePage_Click(object sender, EventArgs e)
        {
            FormGraphScore fgs = new FormGraphScore();
            fgs.Show();
        }

        private void GoBoxScorePage_Click(object sender, EventArgs e)
        {
            FormBoxScore fbs = new FormBoxScore();
            fbs.Show();
        }

        private void GoPlayerData_Click(object sender, EventArgs e)
        {
            PlayerData.PlayerData pd = new PlayerData.PlayerData();
            pd.Show();
        }

        private void GoTacticks2D_Click(object sender, EventArgs e)
        {
            Tacticks2D t = new Tacticks2D();
            t.Show();
        }

        //TODO:コンフィグ画面分離？
        private void PropToolStripMenuItem_Click(object sender, EventArgs e)
        {
       //     ConfigForm c = new ConfigForm();
       //     c.ShowDialog();
       //     c.Dispose();
        }

        private void dataEdit_Click(object sender, EventArgs e)
        {
            EditForm ed = new EditForm();
            ed.Show();
        }

        private void teamMake_Click(object sender, EventArgs e)
        {
            TeamDataEdit t = new TeamDataEdit();
            t.Show();
        }

        private void actionPointEdit_Click(object sender, EventArgs e)
        {
            ActionPointEditForm a = new ActionPointEditForm();
            a.Show();
        }

        private void actionPointGraph_Click(object sender, EventArgs e)
        {
            FormActionPointGraph f = new FormActionPointGraph();
            f.Show();
        }

        private void strategySimulation_Click(object sender, EventArgs e)
        {
            FormStrategySimulation f = new FormStrategySimulation();
            f.Show();
        }

        private void tCPServer_Click(object sender, EventArgs e)
        {
            TCPServer f = new TCPServer(this);
            f.ShowDialog();
            f.Dispose();
        }

        private void tCPClient_Click(object sender, EventArgs e)
        {
            TCPClient f = new TCPClient(this);
            f.Show();
        }

        private void clubMake_Click(object sender, EventArgs e)
        {
            FormClubEdit f = new FormClubEdit();
            f.Show();
        }

        /****************************************************************************************/


        /********************************* KeyEvent *********************************************/

        private void FormInput_KeyDown(object sender, KeyEventArgs e)
        {
            keyboardEventHelper.KeyDownEvent(this, e);
        }

        private void FormInput_KeyUp(object sender, KeyEventArgs e)
        {
            keyboardEventHelper.KeyUpEvent(this);
        }

        /****************************************************************************************/


        /**************************** ショートカットアイコン ************************************/

        private void NewGameToolStripButton_Click(object sender, EventArgs e)
        {
            NewGameItem.PerformClick();
        }

        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            GameDataSaveItem.PerformClick();
        }

        private void OpenToolStripButton_Click(object sender, EventArgs e)
        {
            LoadGameDataItem.PerformClick();
        }

        private void UndoToolStripButton_Click(object sender, EventArgs e)
        {
            if (gameDataStack.Count != 0)
            {
                redoGameDataStack.Push(Game.CloneDeep());

                Game g = gameDataStack.Pop();

                LoadProcess(g);

            }
       
        }

        private void RedoToolStripButton_Click(object sender, EventArgs e)
        {
            if (redoGameDataStack.Count != 0)
            {
                Game g = redoGameDataStack.Pop();

                LoadProcess(g);

            }
        }

        /****************************************************************************************/

        /// <summary>
        /// ゲームデータのディープコピーをスタックに入れます
        /// アクションの変更など、Undo操作の対象にしたい動作が行われる直前に呼んでください
        /// </summary>
        public void StackGameData()
        {
            gameDataStack.Push(Game.CloneDeep());
            redoGameDataStack.Clear();
        }
    }
}
