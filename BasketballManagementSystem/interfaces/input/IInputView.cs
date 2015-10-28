using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.abstracts;
using BasketballManagementSystem.baseClass.player;
using BasketballManagementSystem.baseClass.game;
using System.Drawing;
using BasketballManagementSystem.bMForm.input;
using BasketballManagementSystem.events.input;
using System.Windows.Forms;

namespace BasketballManagementSystem.interfaces.input
{
    public interface IInputView : IView
    {
        DebugMessageForm DebugMessageForm { get; }
        Team MyTeam { get; }
        Team OppentTeam { get; }
        int Quarter { get; }
        int NowMyTimeOut { get; }
        int NowOppentTimeOut { get; }
        Player SelectedPlayer { get; }
        Bitmap RestartGraph { get; }
        Bitmap StopGraph { get; }
        bool UseComment { get; }
        int TimeOutRimit { get; }
        Stack<Game> GameDataStack { get; }
        Stack<Game> RedoGameDataStack { get; }
        Game Game { get; }
        QuarterTimer.QuarterTimer QuarterTimer { get; }
        TimeSpan RemainingTime { get; }
        TimeSpan ElaspedTime { get; }
        int GivenFreeThrow { get; }

        /// <summary>
        /// チーム変更時に呼ばれるイベント
        /// </summary>
        event TeamChangeEventHandler TeamChangeEvent;

        /// <summary>
        /// メンバー変更時に呼ばれるイベント
        /// </summary>
        event Action<FormInputView> MemberChangeEvent;

        /// <summary>
        /// キーボードイベント発生時に呼ばれるイベント
        /// </summary>
        event KeyboardEventHandler KeyboardEvent;

        /// <summary>
        /// Undo時に呼ばれるイベント
        /// </summary>
        event Action UndoEvent;

        /// <summary>
        /// Redo時に呼ばれるイベント
        /// </summary>
        event Action RedoEvent;

        /// <summary>
        /// ロードボタンが押された時のイベント
        /// </summary>
        event Action GameLoadEvent;

        /// <summary>
        /// セーブボタンが押された時のイベント
        /// </summary>
        event Action GameSaveEvent;

        /// <summary>
        /// セーブデータ管理クラスへの定期セーブ時に呼ばれるイベント
        /// </summary>
        event Action SetSaveDataToManagerEvent;

        /// <summary>
        /// TCPクライアント画面が開かれる時のイベント
        /// </summary>
        event Action OpenTCPClientFormEvent;

        /// <summary>
        /// TCPサーバー画面が開かれる時のイベント
        /// </summary>
        event Action OpenTCPServerFormEvent;

        /// <summary>
        /// 試合が開始された時のイベント
        /// </summary>
        event Action StartGameEvent;

        /// <summary>
        /// クォーター遷移が行われた時のイベント
        /// </summary>
        event Action NextQuarterEvent;

        /// <summary>
        /// 試合が一時停止された時のイベント
        /// </summary>
        event Action StopGameEvent;

        /// <summary>
        /// 試合が再開された時のイベント
        /// </summary>
        event Action RestartGameEvent;

        /// <summary>
        /// 試合が終了した時のイベント
        /// </summary>
        event Action EndGameEvent;

        /// <summary>
        /// 試合へのコメントメソッドが呼ばれる時のイベント
        /// </summary>
        event Action<string> GameCommentEvent;

        /// <summary>
        /// アクション入力が行われたときのイベント
        /// </summary>
        event Action<Type> ActionClickEvent;

        /// <summary>
        /// コートがクリックされたときのイベント
        /// </summary>
        event Action<PictureBox, EventArgs> CortClickEvent;

        event Action FormActionPointEditOpenEvent;
    }
}
