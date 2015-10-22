using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasketballManagementSystem.BaseClass.game;

namespace BasketballManagementSystem.manager
{
    class SaveDataManager
    {
        private static SaveDataManager instance = new SaveDataManager();

        /// <summary>
        /// セーブデータ
        /// </summary>
        private Game game = new Game();


        /// <summary>
        /// privateコンストラクタ
        /// </summary>
        private SaveDataManager() { }

        /// <summary>
        /// 自身のインスタンスを返す
        /// </summary>
        /// <returns></returns>
        public static SaveDataManager GetInstance()
        {
            return instance;
        }

        public Game GetGame()
        {
            return game;
        }

        public void SetGame(Game g)
        {
            game = g;
        }

    }
}
