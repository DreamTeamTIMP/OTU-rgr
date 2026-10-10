using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rgr
{
    internal partial class Engine
    {
        private readonly PlayerLeader leader;
        private readonly PlayerDriven driven;
        private readonly Map map;


        public Engine() 
        {
            leader = new PlayerLeader();
            driven = new PlayerDriven();
            map = new Map();
        }
        internal void Start()
        {
            do
            {
                bool leaderMove = leader.MakeMove();
                bool drivenMove = driven.MakeMove();
                if ((leaderMove && drivenMove) || (!leaderMove && drivenMove))
                {
                    map.Lvl += 1;
                }
                else
                {
                    map.Lvl -= 1;
                }
            }
            while ();
        }
    }
}
