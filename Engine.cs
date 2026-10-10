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
        private bool gameEnded;


        public Engine() 
        {
            leader = new PlayerLeader();
            driven = new PlayerDriven();
            map = new Map();
            driven.RaiseEvent += OnGameEnded;
            map.RaiseEvent += OnGameEnded;
        }

        private void OnGameEnded(object sender, GameEndedEventArgs e)
        {
            string winner = e.Winner == EndReason.MapTriggered ? "Ведомый игрок" : "ведущий игрок";
            Console.WriteLine($"Победил {winner}");
            gameEnded = true;
        }

        internal void Start()
        {
            gameEnded = false;
            while (!gameEnded)
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
        }
    }
}
