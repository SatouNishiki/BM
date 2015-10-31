using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.interfaces;
using BasketballManagementSystem.abstracts;
using BasketballManagementSystem.events.input;
using BasketballManagementSystem.bmForm.input.eventHelper;
using BasketballManagementSystem.bmForm.input.loadHelper;
using BasketballManagementSystem.baseClass.game;
using BasketballManagementSystem.bmForm.Transmission.tcp;
using BasketballManagementSystem.baseClass.command;
using BasketballManagementSystem.factory;
namespace BasketballManagementSystem.bmForm.input
{
    public class FormInputPresenter : AbstractPresenter
    {

        private FormInputView inputView;

        private FormInputModel inputModel;

        /// <summary>
        /// メンバーチェンジに関する処理を行うヘルパークラス
        /// </summary>
        private MemberChangeEventHelper memberChangeEventHelper = new MemberChangeEventHelper();

        /// <summary>
        /// キーボードショートカット処理を行うヘルパークラス
        /// </summary>
        private KeyboardEventHelper keyboardEventHelper = new KeyboardEventHelper();

        /// <summary>
        /// コート入力に関するイベントの処理を行うヘルパークラス
        /// </summary>
        private CortEventHelper cortEventHelper = new CortEventHelper();

        /// <summary>
        /// ゲームローダー
        /// </summary>
        private FormInputLoader loader = FormInputLoader.GetFormInputLoaderInstance();


        public FormInputPresenter(FormInputView f, FormInputModel f2)
            : base(f, f2)
        {
            this.inputModel = f2;
            this.inputView = f;

            this.inputView.TeamChangeEvent += inputView_TeamChangeEvent;
            this.inputView.MemberChangeEvent += inputView_MemberChangeEvent;
            this.inputView.KeyboardEvent += inputView_KeyboardEvent;
            this.inputView.UndoEvent += inputView_UndoEvent;
            this.inputView.RedoEvent += inputView_RedoEvent;
            this.inputView.GameLoadEvent += inputView_GameLoadEvent;
            this.inputView.GameSaveEvent += inputView_GameSaveEvent;
            this.inputView.SetSaveDataToManagerEvent += inputView_SetSaveDataToManagerEvent;
            this.inputView.OpenTCPClientFormEvent += inputView_OpenTCPClientFormEvent;
            this.inputView.OpenTCPServerFormEvent += inputView_OpenTCPServerFormEvent;
            this.inputView.StartGameEvent += inputView_StartGameEvent;
            this.inputView.NextQuarterEvent += inputView_NextQuarterEvent;
            this.inputView.StopGameEvent += inputView_StopGameEvent;
            this.inputView.RestartGameEvent += inputView_RestartGameEvent;
            this.inputView.EndGameEvent += inputView_EndGameEvent;
            this.inputView.GameCommentEvent += inputView_GameCommentEvent;
            this.inputView.ActionClickEvent += inputView_ActionClickEvent;
            this.inputView.CortClickEvent += inputView_CortClickEvent;
            this.inputView.FormActionPointEditOpenEvent += inputView_FormActionPointEditOpenEvent;
            this.inputView.FormActionPointGraphOpenEvent += inputView_FormActionPointGraphOpenEvent;
            this.inputView.FormBoxScoreOpenEvent += inputView_FormBoxScoreOpenEvent;
        }

        void inputView_FormBoxScoreOpenEvent()
        {
            FormFactory factory = new FormBoxScoreFactory();
            AbstractPresenter presenter = factory.CreatePresenter();
            presenter.ShowView();
        }

        void inputView_FormActionPointGraphOpenEvent()
        {
            FormFactory factory = new FormAcitonPointGraphFactory();
            AbstractPresenter presenter = factory.CreatePresenter();
            presenter.ShowView();
        }

        void inputView_FormActionPointEditOpenEvent()
        {
            FormFactory factory = new FormActionPointEditFactory();
            AbstractPresenter presenter = factory.CreatePresenter();
            presenter.ShowView();
        }

        void inputView_CortClickEvent(System.Windows.Forms.PictureBox arg1, EventArgs arg2)
        {
            
            this.cortEventHelper.OnCortClick(this.inputView, this.inputModel, arg1, arg2);
        }
        
        void inputView_ActionClickEvent(Type obj)
        {
            ICommand command = new ActionCommand(this.inputModel, obj);
            command.Execute();
        }

        void inputView_GameCommentEvent(string obj)
        {
            this.inputModel.SetGameComment(obj);
        }

        void inputView_EndGameEvent()
        {
            this.inputModel.OnEndGame();
        }

        void inputView_RestartGameEvent()
        {
            this.inputModel.OnRestartGame();
        }

        void inputView_StopGameEvent()
        {
            this.inputModel.OnStopGame();
        }

        void inputView_NextQuarterEvent()
        {
            this.inputModel.OnNextQuarter();
        }

        void inputView_StartGameEvent()
        {
            this.inputModel.OnStartGame();
        }

        void inputView_OpenTCPServerFormEvent()
        {
            TCPServer f = new TCPServer(this);
            f.ShowDialog();
            f.Dispose();
        }

        void inputView_OpenTCPClientFormEvent()
        {
            TCPClient f = new TCPClient(this);
            f.Show();
        }

        void inputView_SetSaveDataToManagerEvent()
        {
            this.inputModel.SetSaveDataToManager();
        }

        void inputView_GameSaveEvent()
        {
            this.inputModel.SaveGame();
        }

        void inputView_RedoEvent()
        {
            Game g = this.inputModel.Redo();

            if (g != null)
            {
                loader.LoadForm(this.inputModel, this.inputView, g);
            }
        }

        void inputView_GameLoadEvent()
        {
            Game g = this.inputModel.LoadGame();

            if (g != null)
            {
                loader.LoadForm(this.inputModel, this.inputView, g);
            }
        }

        
        void inputView_UndoEvent()
        {
            Game g = this.inputModel.Undo();

            if (g != null)
            {
                loader.LoadForm(this.inputModel, this.inputView, g);
            }
        }

        void inputView_KeyboardEvent(object sender, KeyboardEventArgs e)
        {
            if(!(sender is FormInputView)) return;

            if (e.Type == KeyboardEventArgs.KeyType.KeyDown)
            {
                this.keyboardEventHelper.KeyDownEvent((FormInputView)sender, e.KeyEventArgs);
            }
            else if (e.Type == KeyboardEventArgs.KeyType.KeyUp)
            {
                this.keyboardEventHelper.KeyUpEvent((FormInputView)sender);
            }
        }

        void inputView_MemberChangeEvent(FormInputView obj)
        {
            this.memberChangeEventHelper.ChangeMember(obj);
        }

        /// <summary>
        /// チーム変更ボタンが押されたときここに落ちる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void inputView_TeamChangeEvent(object sender, TeamChangeEventArgs e)
        {
            if (e.Type == TeamChangeEventArgs.TeamType.MyTeam)
            {
                inputModel.OnMyTeamChange(e.CortMemberListBox, e.OutMemberListBox);
            }
            else if (e.Type == TeamChangeEventArgs.TeamType.OppentTeam)
            {
                inputModel.OnOppentTeamChange(e.CortMemberListBox, e.OutMemberListBox);
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
                this.inputModel.LoadGame(game);
                loader.LoadForm(this.inputModel, this.inputView, game);
            }
        }

        public override void ShowView()
        {
            this.inputView.Show();
        }

        public override System.Windows.Forms.Form GetForm()
        {
            return this.inputView;
        }
    }
}
