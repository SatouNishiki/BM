using System.Windows.Forms;
using BasketballManagementSystem.baseClass.player;
using BasketballManagementSystem.baseClass.action;
using BasketballManagementSystem.bMForm.input.eventHelper;
using System;
using BasketballManagementSystem.baseClass.game;
using BasketballManagementSystem.manager;
using BasketballManagementSystem.bMForm.graphScore;
using BasketballManagementSystem.bMForm.boxScore;
using BasketballManagementSystem.baseClass.timeOut;
using BasketballManagementSystem.bMForm.playerData;
using BasketballManagementSystem.baseClass.settings;
using System.Drawing;
using System.Collections.Generic;
using BasketballManagementSystem.bMForm.tactick2D;
using System.Globalization;
using System.Threading;
using BasketballManagementSystem.bMForm.input.language;
using BasketballManagementSystem.bMForm.gameDataEdit;
using BasketballManagementSystem.bMForm.Transmission;
using BasketballManagementSystem.bMForm.input.loadHelper;
using System.Runtime.CompilerServices;
using BasketballManagementSystem.bMForm.teamMake;
using BasketballManagementSystem.bMForm.actionPointEdit;
using BasketballManagementSystem.bMForm.actionPointGraph;
using BasketballManagementSystem.bMForm.strategySimulation;
using BasketballManagementSystem.bMForm.Transmission.tCP;
using BasketballManagementSystem.bMForm.clubEdit;
using BasketballManagementSystem.bMForm.centralityAnalyze;
using BasketballManagementSystem.interfaces.input;
using BasketballManagementSystem.events;
using BasketballManagementSystem.interfaces;
using BasketballManagementSystem.abstracts;
using BasketballManagementSystem.events.input;
using BasketballManagementSystem.baseClass.command;

namespace BasketballManagementSystem.bMForm.input
{
    public partial class FormInputView : Form, IInputView
    {

        /// <summary>
        /// 色を変更するボタンを格納するリスト
        /// </summary>
        public List<Button> colorChangeButton { get; set; }

        private AbstractPresenter presenter;

        public AbstractPresenter Presenter
        {
            get
            {
                return this.presenter;
            }
            set
            {
                this.presenter = value;

                this.Init();
            }
        }

        public DebugMessageForm DebugMessageForm
        {
            get { return (DebugMessageForm)this.presenter.GetModelProperty("DebugMessageForm"); }
        }

        public Team MyTeam
        {
            get { return (Team)this.presenter.GetModelProperty("MyTeam"); }
        }

        public Team OppentTeam
        {
            get { return (Team)this.presenter.GetModelProperty("OppentTeam"); }
        }

        public int Quarter
        {
            get { return (int)this.presenter.GetModelProperty("Quarter"); }
        }

        public int NowMyTimeOut
        {
            get { return (int)this.presenter.GetModelProperty("NowMyTimeOut"); }
        }

        public int NowOppentTimeOut
        {
            get { return (int)this.presenter.GetModelProperty("NowOppentTimeOut"); }
        }

        public Player SelectedPlayer
        {
            get { return (Player)this.presenter.GetModelProperty("SelectedPlayer"); }
        }

        public Bitmap RestartGraph
        {
            get { return (Bitmap)this.presenter.GetModelProperty("RestartGraph"); }
        }

        public Bitmap StopGraph
        {
            get { return (Bitmap)this.presenter.GetModelProperty("StopGraph"); }
        }

        public bool UseComment
        {
            get { return (bool)this.presenter.GetModelProperty("UseComment"); }
        }

        public int TimeOutRimit
        {
            get { return (int)this.presenter.GetModelProperty("TimeOutRimit"); }
        }

        public Stack<Game> GameDataStack
        {
            get { return (Stack<Game>)this.presenter.GetModelProperty("GameDataStack"); }
        }

        public Stack<Game> RedoGameDataStack
        {
            get { return (Stack<Game>)this.presenter.GetModelProperty("RedoGameDataStack"); }
        }

        public Game Game
        {
            get { return (Game)this.presenter.GetModelProperty("Game"); }
        }

        public QuarterTimer.QuarterTimer QuarterTimer
        {
            get { return (QuarterTimer.QuarterTimer)this.presenter.GetModelProperty("QuarterTimer"); }
        }

        public TimeSpan RemainingTime
        {
            get { return (TimeSpan)this.presenter.GetModelProperty("RemainingTime"); }
        }

        public TimeSpan ElaspedTime
        {
            get { return (TimeSpan)this.presenter.GetModelProperty("ElaspedTime"); }
        }

        public int GivenFreeThrow
        {
            get { return (int)this.presenter.GetModelProperty("GivenFreeThrow"); }
        }

        

        /********************************************イベント****************************************/

        /// <summary>
        /// データ入力汎用イベント
        /// </summary>
        public event DataInputEventHandler DataInputEvent;

        /// <summary>
        /// チーム変更時に呼ばれるイベント
        /// </summary>
        public event TeamChangeEventHandler TeamChangeEvent;

        /// <summary>
        /// メンバー変更時に呼ばれるイベント
        /// </summary>
        public event Action<FormInputView> MemberChangeEvent;

        /// <summary>
        /// キーボードイベント発生時に呼ばれるイベント
        /// </summary>
        public event KeyboardEventHandler KeyboardEvent;

        /// <summary>
        /// Undo時に呼ばれるイベント
        /// </summary>
        public event Action UndoEvent;

        /// <summary>
        /// Redo時に呼ばれるイベント
        /// </summary>
        public event Action RedoEvent;

        /// <summary>
        /// ロードボタンが押された時のイベント
        /// </summary>
        public event Action GameLoadEvent;

        /// <summary>
        /// セーブボタンが押された時のイベント
        /// </summary>
        public event Action GameSaveEvent;

        /// <summary>
        /// セーブデータ管理クラスへの定期セーブ時に呼ばれるイベント
        /// </summary>
        public event Action SetSaveDataToManagerEvent;

        /// <summary>
        /// TCPクライアント画面が開かれる時のイベント
        /// </summary>
        public event Action OpenTCPClientFormEvent;

        /// <summary>
        /// TCPサーバー画面が開かれる時のイベント
        /// </summary>
        public event Action OpenTCPServerFormEvent;
        
        /// <summary>
        /// 試合が開始された時のイベント
        /// </summary>
        public event Action StartGameEvent;

        /// <summary>
        /// クォーター遷移が行われた時のイベント
        /// </summary>
        public event Action NextQuarterEvent;
        
        /// <summary>
        /// 試合が一時停止された時のイベント
        /// </summary>
        public event Action StopGameEvent;

        /// <summary>
        /// 試合が再開された時のイベント
        /// </summary>
        public event Action RestartGameEvent;

        /// <summary>
        /// 試合が終了した時のイベント
        /// </summary>
        public event Action EndGameEvent;

        /// <summary>
        /// 試合へのコメントメソッドが呼ばれる時のイベント
        /// </summary>
        public event Action<string> GameCommentEvent;

        /// <summary>
        /// アクション入力が行われたときのイベント
        /// </summary>
        public event Action<Type> ActionClickEvent;

        /// <summary>
        /// コートがクリックされたときのイベント
        /// </summary>
        public event Action<PictureBox, EventArgs> CortClickEvent;

        public event Action FormActionPointEditOpenEvent;

        /// <summary>
        /// データ変更イベントを投げる
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        private void DataChangeEventThrow(string name, object value)
        {
            if (this.DataInputEvent != null)
            {
                this.DataInputEvent(this, new DataInputEventArgs(name, value));
            }
        }

        /// <summary>
        /// チーム変更イベントを投げる
        /// </summary>
        /// <param name="cortMemberList"></param>
        /// <param name="outMemberList"></param>
        private void TeamChangeEventThrow(ListBox cortMemberList, ListBox outMemberList, TeamChangeEventArgs.TeamType type)
        {
            if (this.TeamChangeEvent != null)
            {
                this.TeamChangeEvent(this, new TeamChangeEventArgs(cortMemberList, outMemberList, type));
            }
        }

        /// <summary>
        /// メンバー変更イベントを投げる
        /// </summary>
        /// <param name="form"></param>
        private void MemberChangeEventThrow(FormInputView form)
        {
            if (this.MemberChangeEvent != null)
            {
                this.MemberChangeEvent(form);
            }
        }

        private void KeyboardEventThrow(FormInputView form, KeyEventArgs key, KeyboardEventArgs.KeyType type)
        {
            if (this.KeyboardEvent != null)
            {
                this.KeyboardEvent(form, new KeyboardEventArgs(key, type));
            }
        }

        private void UndoEventThrow()
        {
            if (this.UndoEvent != null)
            {
                this.UndoEvent();
            }
        }

        private void RedoEventThrow()
        {
            if (this.RedoEvent != null)
            {
                this.RedoEvent();
            }
        }

        private void GameLoadEventThrow()
        {
            if (this.GameLoadEvent != null)
            {
                this.GameLoadEvent();
            }
        }

        private void GameSaveEventThrow()
        {
            if (this.GameSaveEvent != null)
            {
                this.GameSaveEvent();
            }
        }

        private void SetSaveDataToManagerEventThrow()
        {
            if (this.SetSaveDataToManagerEvent != null)
            {
                this.SetSaveDataToManagerEvent();
            }
        }

        private void OpenTCPClientFormEventThrow()
        {
            if (this.OpenTCPClientFormEvent != null)
            {
                this.OpenTCPClientFormEvent();
            }
        }

        private void OpenTCPServerFormEventThrow()
        {
            if (this.OpenTCPServerFormEvent != null)
            {
                this.OpenTCPServerFormEvent();
            }
        }

        private void StartGameEventThrow()
        {
            if (this.StartGameEvent != null)
            {
                this.StartGameEvent();
            }
        }

        private void NextQuarterEventThrow()
        {
            if (this.NextQuarterEvent != null)
            {
                this.NextQuarterEvent();
            }
        }

        private void StopGameEventThrow()
        {
            if (this.StopGameEvent != null)
            {
                this.StopGameEvent();
            }
        }

        private void RestartGameEventThrow()
        {
            if (this.RestartGameEvent != null)
            {
                this.RestartGameEvent();
            }
        }

        private void EndGameEventThrow()
        {
            if (this.EndGameEvent != null)
            {
                this.EndGameEvent();
            }
        }

        private void GameCommentEventThrow(string comment)
        {
            if (this.GameCommentEvent != null)
            {
                this.GameCommentEvent(comment);
            }
        }

        private void ActionClickEventThrow(Type type)
        {
            if (this.ActionClickEvent != null)
            {
                this.ActionClickEvent(type);
            }
        }

        private void CortClickEventThrow(PictureBox pictureBox, EventArgs e)
        {
            if (this.CortClickEvent != null)
            {
                this.CortClickEvent(pictureBox, e);
            }
        }

        private void FormActionPointEditOpenEventThrow()
        {
            if (this.FormActionPointEditOpenEvent != null)
            {
                this.FormActionPointEditOpenEvent();
            }
        }

        /*********************************************************************************************/

        public FormInputView()
        {
            InitializeComponent();
            PreInit();
           
        }

        /// <summary>
        /// コンストラクタで呼ばれる初期化処理メソッド
        /// </summary>
        private void PreInit()
        {
            /******************************プロパティ初期化******************************************/
           
            this.colorChangeButton = new List<Button>();

            foreach (var c in Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    colorChangeButton.Add((Button)c);
                }
            }

            
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
            
            


            /******************************************************************************************/


            
            /************************************設定読み込み****************************************/

            this.BackColor = AppSetting.GetInstance().FormInputBackGroundColor;
            this.MyTeamPointLabel.BackColor = AppSetting.GetInstance().FormInputPointBackGroundColor;
            this.OppentTeamPointLabel.BackColor = AppSetting.GetInstance().FormInputPointBackGroundColor;
            TimerTickComboBox.SelectedIndex = AppSetting.GetInstance().FormInputFPS;
            DebugFormVisiableItem.Checked = AppSetting.GetInstance().DebugWindowChecked;
            UseCommentItem.Checked = AppSetting.GetInstance().UseCommentChecked;

            foreach (var b in colorChangeButton)
            {
                b.BackColor = AppSetting.GetInstance().FormInputButtonColor;

                //UseVisualStyleBackColorは若干フィーリングで設定してる(これをやらないとボタンの立体感が消える)
                if (AppSetting.GetInstance().FormInputButtonColorAsRGB == "")
                    b.UseVisualStyleBackColor = true;
                b.ForeColor = AppSetting.GetInstance().FormInputButtonTextColor;
            }

            /*****************************************************************************************/

           


           
        }

        /// <summary>
        /// Presenter設定後に呼ばれる初期化処理メソッド
        /// モデルのデータを用いてコントロールの初期化をするような場合に使う
        /// </summary>
        private void Init()
        {
            QuarterChangeTimerSpeedCombo.SelectedIndex = 0;

            /***********************************デバッグウインドウ設定*******************************/

            if (DebugFormVisiableItem.Checked)
            {
                DebugMessageForm.Show();
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
            if (DebugMessageForm != null && !DebugMessageForm.IsDisposed)
                DebugMessageForm.AddDebugMessage(message);

        }

        private void FormInputTimer_Tick(object sender, System.EventArgs e)
        {

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
            MyTimeOutLabel.Text = NowMyTimeOut + "/" + TimeOutRimit;

            OppentTimeOutLabel.Text = NowOppentTimeOut + "/" + TimeOutRimit;

            /***********************************************************************/


            /******************************* DebugWindow **********************************************/

            //DebugWindowが表示モードなのにユーザーから強制的に消されたら
            if ((DebugMessageForm == null || DebugMessageForm.IsDisposed) && DebugFormVisiableItem.Checked)
            {
                //非表示モードにしてあげる
                DebugFormVisiableItem.Checked = false;
                AppSetting.GetInstance().DebugWindowChecked = false;
                AppSetting.GetInstance().SettingChanged();
            }

            /*****************************************************************************************/

            if (GameDataStack.Count == 0) UndoToolStripButton.Enabled = false;
            else UndoToolStripButton.Enabled = true;

            if (RedoGameDataStack.Count == 0) RedoToolStripButton.Enabled = false;
            else RedoToolStripButton.Enabled = true;

            this.SaveToSaveManager();

            if (this.QuarterTimer.Text != string.Empty)
                this.QuarterTimerLabel.Text = this.QuarterTimer.Text;
            else
                this.QuarterTimerLabel.Text = "10:00";
        }


        /// <summary>
        /// 自チーム変更ボタンが押されたときに呼び出し
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeMyTeamButton_Click(object sender, System.EventArgs e)
        {
            this.TeamChangeEventThrow(MyCortTeamListBox, MyOutTeamListBox, TeamChangeEventArgs.TeamType.MyTeam);

            SyncTeam();
        }

        /// <summary>
        /// 相手チーム変更ボタンが押されたときに呼び出し
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeOppentTeamButton_Click(object sender, System.EventArgs e)
        {
            this.TeamChangeEventThrow(OppentCortTeamListBox, OppentOutTeamListBox, TeamChangeEventArgs.TeamType.OppentTeam);

            SyncTeam();
        }

        /// <summary>
        /// リストとGameDataの選手リストを同期させます
        /// </summary>
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
            this.ActionClickEventThrow(typeof(Assist));
        }

        private void PersonalFaulButton_Click(object sender, System.EventArgs e)
        {
            this.ActionClickEventThrow(typeof(PersonalFaul));
        }

        private void TurnOverButton_Click(object sender, System.EventArgs e)
        {
            this.ActionClickEventThrow(typeof(TurnOver));         
        }

        private void StealButton_Click(object sender, System.EventArgs e)
        {
            this.ActionClickEventThrow(typeof(Steal));  
        }

        private void BlockShotButton_Click(object sender, System.EventArgs e)
        {
            this.ActionClickEventThrow(typeof(ShootBlock));  
        }

        private void TechnicalFaulButton_Click(object sender, EventArgs e)
        {
            this.ActionClickEventThrow(typeof(TechnicalFaul));  
        }

        private void UnSportsmanLikeFaulButton_Click(object sender, EventArgs e)
        {
            this.ActionClickEventThrow(typeof(UnSportsmanLikeFaul));  
        }

        private void DisQualifyingFaulButton_Click(object sender, EventArgs e)
        {
            this.ActionClickEventThrow(typeof(DisQualifyingFaul));  
        }

        private void CortPicture_Click(object sender, System.EventArgs e)
        {
            this.CortClickEventThrow(CortPictureBox, e);
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
                this.DataChangeEventThrow("SelectedPlayer", (Player)(((ListBox)sender).Items[((ListBox)sender).SelectedIndex]));
               
                PlayerNameLabel.Text = SelectedPlayer.ToString();
            }
            catch(System.Exception exception)
            {
                this.DataChangeEventThrow("SelectedPlayer", new Player("No Name", 0));
               
                BMErrorLibrary.BMError.ErrorMessageOutput(exception.Message, true);
            }
        }

        private void TimeOut_Click(object sender, EventArgs e)
        {
            if (NowMyTimeOut < TimeOutRimit)
            {
                try
                {
                    StackGameData();
                    Game.MyTeam.TimeOutList.Add(new baseClass.timeOut.TimeOut(Quarter, DateTime.Now, this.QuarterTimer.remainingTime));
                }
                catch (Exception exc)
                {
                    BMErrorLibrary.BMError.ErrorMessageOutput(exc.ToString(), true);
                }
                if (StopGameItem.Enabled)
                {
                    this.StopGameEventThrow();
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
            if (NowOppentTimeOut < TimeOutRimit)
            {
                try
                {
                    StackGameData();
                    Game.OppentTeam.TimeOutList.Add(new baseClass.timeOut.TimeOut(Quarter, DateTime.Now, this.QuarterTimer.remainingTime));
                }
                catch (Exception exc)
                {
                    BMErrorLibrary.BMError.ErrorMessageOutput(exc.ToString(), true);
                }
                if (StopGameItem.Enabled)
                {
                    this.StopGameEventThrow();
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
                this.DataChangeEventThrow("GivenFreeThrow", a);
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (int.Parse(this.givenFreeThowLabel.Text.ToString()) > 1)
            {
                int a = int.Parse(this.givenFreeThowLabel.Text.ToString()) - 1;
                this.givenFreeThowLabel.Text = a.ToString();
                this.DataChangeEventThrow("GivenFreeThrow", a);
            }
        }

        private void TeamChangeButton_Click(object sender, EventArgs e)
        {
            this.MemberChangeEventThrow(this);

            this.Sort(MyCortTeamListBox);

            this.Sort(MyOutTeamListBox);

            this.Sort(OppentCortTeamListBox);

            this.Sort(OppentOutTeamListBox);
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
            NextQuarterItem.Enabled = true;

            GameEndItem.Enabled = true;
            //ゲーム開始ボタンはゲーム終了まで操作不能にしておく
            StartGameItem.Enabled = false;

            StopGameItem.Enabled = true;
            QuarterTimerStopButton.Enabled = true;
            
            this.StartGameEventThrow();
        }

        private void NextQuarterButton_Click(object sender, EventArgs e)
        {
            this.NextQuarterEventThrow();
            QuarterText.Text = this.QuarterTimer.displayQuarter;

            if (Quarter == 3)
            {
                this.DataChangeEventThrow("TimeOutRimit", 3);
            }

            if (Quarter >= 5)
            {
                this.DataChangeEventThrow("TimeOutRimit", 1);
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
            this.EndGameEventThrow();

            string comment = Microsoft.VisualBasic.Interaction.InputBox(
                "試合に対するコメントを入力してください",
                "入力画面",
                "",
                200,
                100);

            this.GameCommentEventThrow(comment);
        }

        private void QuarterTimerFastFoward_MouseDown(object sender, MouseEventArgs e)
        {
            this.QuarterTimer.fastFowardFlag = true;
        }

        private void QuarterTimerFastFoward_MouseUp(object sender, MouseEventArgs e)
        {
            this.QuarterTimer.fastFowardFlag = false;
        }

        private void QuarterTimerRewind_MouseDown(object sender, MouseEventArgs e)
        {
            this.QuarterTimer.rewindFlag = true;
        }

        private void QuarterTimerRewind_MouseUp(object sender, MouseEventArgs e)
        {
            this.QuarterTimer.rewindFlag = false;
        }

        private void QuarterTimerStop_Click(object sender, EventArgs e)
        {
            if (StopGameItem.Enabled)
            {
                this.StopGameEventThrow();
                StopGameItem.Enabled = false;
                RestartGameItem.Enabled = true;
                QuarterTimerStopButton.Image = RestartGraph;
            }
            else
            {
                this.RestartGameEventThrow();
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
            this.SetSaveDataToManagerEventThrow();
        }

        private void GameDataSave_Click(object sender, EventArgs e)
        {
            this.GameSaveEventThrow();
        }

        /// <summary>
        /// ゲームロードがクリックされたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameDataLoad_Click(object sender, EventArgs e)
        {
            this.GameLoadEventThrow();
        }


        /***********************************************************************************************/


        /**************************** その他メニュー画面用メソッド郡************************************/

        private void NewGameItem_Click(object sender, EventArgs e)
        {
            //TODO:メモリリークの可能性あり? 要検証
            this.Controls.Clear();
            this.DataChangeEventThrow("Game", new Game());
            GameDataStack.Clear();
            RedoGameDataStack.Clear();
            InitializeComponent();
            PreInit();

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
                BMErrorLibrary.BMError.ErrorMessageOutput(ex.ToString(), true);
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
                BMErrorLibrary.BMError.ErrorMessageOutput(ex.ToString(), true);
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
            FormInputTimer.Interval = int.Parse(TimerTickComboBox.SelectedItem.ToString());
            AppSetting.GetInstance().FormInputFPS = TimerTickComboBox.SelectedIndex;
            AppSetting.GetInstance().SettingChanged();

        }

        private void DebugFormVisiable_Click(object sender, EventArgs e)
        {
            if (!((ToolStripMenuItem)sender).Checked)
            {
                this.DataChangeEventThrow("DebugMessageForm", new DebugMessageForm());
                DebugMessageForm.Show();
                this.TopMost = true;
                this.TopMost = false;
            }
            else
            {
                DebugMessageForm.Close();
            }

            //チェック状態反転
            ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;

            AppSetting.GetInstance().DebugWindowChecked = ((ToolStripMenuItem)sender).Checked;
            AppSetting.GetInstance().SettingChanged();
        }

        private void QuarterChangeTimerSpeedCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.QuarterTimer.SetChangeSpeedTimerInterval(int.Parse(QuarterChangeTimerSpeedCombo.SelectedItem.ToString()));
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
            playerData.PlayerData pd = new playerData.PlayerData();
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
            this.FormActionPointEditOpenEventThrow();
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
            this.OpenTCPServerFormEventThrow();
        }

        private void tCPClient_Click(object sender, EventArgs e)
        {
            this.OpenTCPClientFormEventThrow();
        }

        private void clubMake_Click(object sender, EventArgs e)
        {
            FormClubEdit f = new FormClubEdit();
            f.Show();
        }

        private void CentralityAnalyzeItem_Click(object sender, EventArgs e)
        {
            FormCentralityAnalyze f = new FormCentralityAnalyze();
            f.Show();
        }

        /****************************************************************************************/


        /********************************* KeyEvent *********************************************/

        private void FormInput_KeyDown(object sender, KeyEventArgs e)
        {
            this.KeyboardEventThrow(this, e, KeyboardEventArgs.KeyType.KeyDown);
        }

        private void FormInput_KeyUp(object sender, KeyEventArgs e)
        {
            this.KeyboardEventThrow(this, e, KeyboardEventArgs.KeyType.KeyUp);
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
            this.UndoEventThrow();

            AddDebugMessage("GameData undo");
       
        }

        private void RedoToolStripButton_Click(object sender, EventArgs e)
        {
            this.RedoEventThrow();

            AddDebugMessage("GameData redo");
        }

        private void UseCommentToolStripButton_Click(object sender, EventArgs e)
        {
            UseCommentItem.PerformClick();
            AddDebugMessage("UseComment Enable is" + UseComment);
        }

        /****************************************************************************************/

        /// <summary>
        /// ゲームデータのディープコピーをスタックに入れます
        /// アクションの変更など、Undo操作の対象にしたい動作が行われる直前に呼んでください
        /// </summary>
        public void StackGameData()
        {
            GameDataStack.Push(Game.CloneDeep());
            RedoGameDataStack.Clear();
        }

        private void UseCommentItem_Click(object sender, EventArgs e)
        {

            //チェック状態反転
            ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;

            AppSetting.GetInstance().UseCommentChecked = ((ToolStripMenuItem)sender).Checked;
            AppSetting.GetInstance().SettingChanged();

            this.DataChangeEventThrow("UseComment", ((ToolStripMenuItem)sender).Checked);
        }

        private void UseCommentItem_CheckedChanged(object sender, EventArgs e)
        {
            if (UseComment)
            {
                UseCommentToolStripButton.BackColor = Color.DeepSkyBlue;
            }
            else
            {
                UseCommentToolStripButton.BackColor = DefaultBackColor;
            }
        }

        

        private void Sort(ListBox pList)
        {
            if (pList.Items.Count != 0)
            {
                int index = pList.SelectedIndex;

                Player[] array = new Player[pList.Items.Count];
                pList.Items.CopyTo(array, 0);

                Array.Sort(array, new PlayerCoparer());

                pList.Items.Clear();

                foreach (Player p in array)
                {
                    pList.Items.Add(p);
                }

                pList.SelectedIndex = index;
            }
        }

        
    }
}
