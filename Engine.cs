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
        private int leaderWinCounter = 0;
        private int drivenWinCounter = 0;
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
            if (e.Winner == EndReason.MapTriggered)
                leaderWinCounter += 1;
            else
                drivenWinCounter += 1;
            gameEnded = true;
            RestoreGame();
        }
        private void RestoreGame()
        {
            driven.Restore();
            map.Restore();
        }
        internal void Start(double k, int n)
        {
            leaderWinCounter = 0;
            drivenWinCounter = 0;
            int count = 0;
            leader.RndFactor = k;
            while (count < n)
            {
                Play();
                count++;
            }
            Console.WriteLine($"Количество побед ведущего: {leaderWinCounter}\nКоличество побед ведомого: {drivenWinCounter}");
        }

        private void Play()
        {
            gameEnded = false;
            while (!gameEnded)
            {
                bool leaderMove = leader.MakeMove();
                bool drivenMove = driven.MakeMove();
                if ((leaderMove && drivenMove) || (!leaderMove && !drivenMove))
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
