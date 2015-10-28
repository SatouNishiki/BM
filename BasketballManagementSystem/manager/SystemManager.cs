using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.baseClass.player;

namespace BasketballManagementSystem.manager
{
    public class SystemManager
    {
        private static SystemManager instance;

        public QuarterTimer.QuarterTimer QuarterTimer { get; set; }

        public Team MyTeam { get; set; }

        public Team OppentTeam { get; set; }

        public bool UseComment { get; set; }

        private SystemManager()
        {
            
        }

        public static SystemManager GetInstance()
        {
            if (instance == null) instance = new SystemManager();

            return instance;
        }


    }
}
