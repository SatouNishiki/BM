using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.interfaces;
using BasketballManagementSystem.events;
using BasketballManagementSystem.baseClass.settings;
using BasketballManagementSystem.baseClass.game;
using System.Drawing;
using System.Windows.Forms;
using BasketballManagementSystem.baseClass.player;
using BasketballManagementSystem.baseClass.timeOut;
using QuarterTimer;
using BasketballManagementSystem.manager;
using BMErrorLibrary;
using BMFileLibrary;
using System.Xml.Serialization;

namespace BasketballManagementSystem.bMForm.input
{
    public class FormInputModel : IModel
    {

        private const string defaultFileName = "Game1";

        /// <summary>
        /// デバッグメッセージを表示するフォーム
        /// </summary>
        public DebugMessageForm DebugMessageForm { get; set; }

        /// <summary>
        /// デバッグ画面表示設定
        /// </summary>
        public bool DebugFormVisiablle { get; set; }
        
        /// <summary>
        /// 言語インデックス
        /// </summary>
        public int CultureSelectedIndex { get; set; }

        private Game game;

        /// <summary>
        /// ゲームデータ
        /// </summary>
        public Game Game
        {
            get { return this.game; }
            set
            {
                this.game = value;

                if (this.PropertyChangedEvent != null)
                {
                    this.PropertyChangedEvent(this, new PropertyChangedEventArgs("Game", this.game));
                }
            }
        }

        /// <summary>
        /// 一時停止画像
        /// </summary>
        public Bitmap RestartGraph { get; private set; }

        /// <summary>
        /// 停止画像
        /// </summary>
        public Bitmap StopGraph { get; private set; }

        /// <summary>
        /// そのクォーターのタイムアウト回数の上限
        /// </summary>
        public int TimeOutRimit { get; set; }


        /// <summary>
        /// Undo,Redoに使われるゲームデータのスタックオブジェクト
        /// </summary>
        public Stack<Game> GameDataStack { get; set; }

        public Stack<Game> RedoGameDataStack { get; set; }

        /// <summary>
        /// 現在の自分のタイムアウトの数
        /// </summary>
        public int NowMyTimeOut
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
        public int NowOppentTimeOut
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
        /// コメント機能を利用するかどうかを取得
        /// </summary>
        public bool UseComment { get; set; }

        /// <summary>
        /// 現在選択されているプレイヤーの変数
        /// </summary>
        public Player SelectedPlayer { get; set; }


        private int givenFreeThrow;

        /// <summary>
        /// ファウルが行われたときに与えるフリースローの数
        /// </summary>
        public int GivenFreeThrow
        {
            get
            {
                return this.givenFreeThrow;
            }
            private set { this.givenFreeThrow = value; }
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

        public QuarterTimer.QuarterTimer QuarterTimer { get; set; }

        /// <summary>
        /// クォーターの残り時間
        /// </summary>
        public TimeSpan RemainingTime
        {
            get { return QuarterTimer.remainingTime; }
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
        public TimeSpan ElaspedTime
        {
            get { return QuarterTimer.elapsedTime; }
        }

        /// <summary>
        /// チーム変更のときのマネージャ
        /// </summary>
        private TeamManager teamManager = TeamManager.getInstance();

        /// <summary>
        /// セーブデータの管理を行うクラス
        /// </summary>
        private SaveDataManager saveDataManager = SaveDataManager.GetInstance();

        public event PropertyChangedEventHandler PropertyChangedEvent;


        public FormInputModel()
        {
            PreInit();
            Init();
            
        }

        /// <summary>
        /// 初期設定のために必要になりそうな設定
        /// </summary>
        public void PreInit() 
        {
            Game = new Game();

            //現在のコードを実行しているAssemblyを取得
            System.Reflection.Assembly assembly =
                System.Reflection.Assembly.GetExecutingAssembly();

            RestartGraph = new Bitmap(assembly.GetManifestResourceStream
                            ("BasketballManagementSystem.bMForm.input.picture.susumu.png"));

            StopGraph = new Bitmap(assembly.GetManifestResourceStream
                            ("BasketballManagementSystem.bMForm.input.picture.teisi.png"));
        }

        /// <summary>
        /// 普通の初期設定
        /// </summary>
        public void Init()
        {
            this.TimeOutRimit = 2;
            this.DebugMessageForm = new DebugMessageForm();
            this.GameDataStack = new Stack<Game>();
            this.RedoGameDataStack = new Stack<Game>();

            MyTeam = new Team();
            OppentTeam = new Team();

            SelectedPlayer = new Player("No Name", 0);
            this.QuarterTimer = new QuarterTimer.QuarterTimer();

        }

        

        /// <summary>
        /// 自チーム変更ボタンが押されたときの処理
        /// ファイル選択をし、そのファイルに記述されているチームを読み込む
        /// </summary>
        /// <param name="f"></param>
        /// <param name="PlayerList"></param>
        /// <param name="OutMemberList"></param>
        /// <param name="myTeam"></param>
        public void OnMyTeamChange(ListBox PlayerList, ListBox OutMemberList)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = BMFile.FindDirectory("TeamData");

            Team t;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイルを読み取り専用で開く
                System.IO.Stream stream;
                stream = ofd.OpenFile();

                if (stream != null)
                {
                    //指定したファイルからチーム情報取得
                    t = teamManager.loadTeam(ofd.FileName, true);

                    //チームをリストにセット
                    SetTeamList(PlayerList, OutMemberList, t);

                    MyTeam.Name = t.Name;
                }
                else
                {
                    BMError.ErrorMessageOutput("stream is null", true);
                }
            }
        }

        /// <summary>
        /// 相手チーム変更ボタンが押されたときの処理委託
        /// ファイル選択をし、そのファイルに記述されているチームを読み込む
        /// </summary>
        /// <param name="f"></param>
        /// <param name="OppentPlayerList"></param>
        /// <param name="OppentOutMemberList"></param>
        /// <param name="oppentTeam"></param>
        public void OnOppentTeamChange(ListBox OppentPlayerList, ListBox OppentOutMemberList)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = BMFile.FindDirectory("TeamData");

            Team t;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイルを読み取り専用で開く
                System.IO.Stream stream;
                stream = ofd.OpenFile();

                if (stream != null)
                {
                    t = teamManager.loadTeam(ofd.FileName, false);

                    SetTeamList(OppentPlayerList, OppentOutMemberList, t);

                    OppentTeam.Name = t.Name;
                }
                else
                {
                    BMError.ErrorMessageOutput("stream is null", true);
                }
            }
        }

        /// <summary>
        /// addListとoutMemberListの中身をリセット
        /// teamのデータをlistに追加する
        /// </summary>
        /// <param name="f"></param>
        /// <param name="addList"></param>
        /// <param name="outMemberList"></param>
        /// <param name="team"></param>
        private void SetTeamList(ListBox cortMemberList, ListBox outMemberList, Team team)
        {
            cortMemberList.Items.Clear();
            outMemberList.Items.Clear();

            List<Player> l1 = team.CortMember;
            List<Player> l2 = team.OutMember;

            foreach (var p in l1)
            {
                cortMemberList.Items.Add(p);
            }

            foreach (var p in l2)
            {
                outMemberList.Items.Add(p);
            }
        }

        /// <summary>
        /// Undo処理をしてUndoした後のゲームデータを返す
        /// </summary>
        /// <returns></returns>
        public Game Undo()
        {
            if (GameDataStack.Count != 0)
            {
                RedoGameDataStack.Push(Game.CloneDeep());

                return GameDataStack.Pop();
            }
            else
            {
                return null;
            }
        }

        public Game Redo()
        {
            if (RedoGameDataStack.Count != 0)
            {
                GameDataStack.Push(Game.CloneDeep());

                return RedoGameDataStack.Pop();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 引数のゲームデータをロードする
        /// </summary>
        /// <param name="game"></param>
        public void LoadGame(Game game)
        {
            if (game != null)
            {
                this.Game = game;

                saveDataManager.SetGame(Game);

                GameDataStack.Clear();
            }
        }

        /// <summary>
        /// ゲームのロード処理が行われるときの処理
        /// </summary>
        /// <returns></returns>
        public Game LoadGame()
        {
            Game temp = LoadGameHelper();

            if (temp != null)
            {
                LoadGame(temp);

                return Game;
            }
            else
            {
                return null;
            }
        }

        public void SaveGame()
        {
            SaveGameHelper(saveDataManager.GetGame());
        }

        private void SaveGameHelper(Game game)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            //はじめのファイル名を指定する
            sfd.FileName = defaultFileName;

            //はじめに表示されるフォルダを指定する
            sfd.InitialDirectory = BMFile.CreateDirectory("Save\\GameData");

            //[ファイルの種類]に表示される選択肢を指定する
            sfd.Filter =
                "Xmlファイル(*.xml)|*.xml|xmlファイル(*.xml)|*.xml";

            sfd.Title = "保存先のファイルを選択してください";

            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.RestoreDirectory = true;

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream stream;
                stream = sfd.OpenFile();

                if (stream != null)
                {

                    XmlSerializer s = new XmlSerializer(typeof(Game));

                    s.Serialize(stream, game);

                    stream.Close();
                }
                else
                {
                    BMError.ErrorMessageOutput("stream is null !!", true);
                }
            }
        }

        private Game LoadGameHelper()
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
            ofd.FileName = "Game1.xml";

            //はじめに表示されるフォルダを指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            ofd.InitialDirectory = BMFile.CreateDirectory("Save\\GameData");

            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            ofd.Filter =
                "Xmlファイル(*.xml)|*.xml|xmlファイル(*.xml)|*.xml";

            //タイトルを設定する
            ofd.Title = "開くファイルを選択してください";

            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;

            Game loadInstance = new Game();

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream stream;
                stream = ofd.OpenFile();

                if (stream != null)
                {

                    XmlSerializer s = new XmlSerializer(typeof(Game));

                    loadInstance = (Game)s.Deserialize(stream);

                    stream.Close();
                }
                else
                {
                    BMError.ErrorMessageOutput("stream is null !!", true);
                }
            }
            else
            {
                return null;
            }

            return loadInstance;
        }

        public void SetSaveDataToManager()
        {
            saveDataManager.SetGame(Game);
        }

        /// <summary>
        /// 試合が開始されたとき
        /// </summary>
        public void OnStartGame()
        {
            this.QuarterTimer.StartGame();
            Game.StartTime = QuarterTimer.startTime;
        }

        /// <summary>
        /// 次のクォーターに遷移したとき
        /// </summary>
        public void OnNextQuarter()
        {
            this.QuarterTimer.GoNextQuarter();
        }

        /// <summary>
        /// 試合が一時停止したとき
        /// </summary>
        public void OnStopGame()
        {
            this.QuarterTimer.StopGame();
        }

        /// <summary>
        /// 試合が再開したとき
        /// </summary>
        public void OnRestartGame()
        {
            this.QuarterTimer.RestartGame();
        }

        /// <summary>
        /// 試合が終了したとき
        /// </summary>
        public void OnEndGame()
        {
            this.QuarterTimer.EndGame();
            Game.EndTime = this.QuarterTimer.endTime;
        }

        /// <summary>
        /// 試合のコメントつけるメソッド
        /// </summary>
        /// <param name="comment"></param>
        public void SetGameComment(string comment)
        {
            this.Game.Comment = comment;
        }
    }
}
