using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rgr
{
    public enum EndReason
    {
        MapTriggered,
        PlayerDrivenTriggered
    }
    public class GameEndedEventArgs : EventArgs
    {
        public EndReason Winner { get; }
        public GameEndedEventArgs(EndReason winner) => Winner = winner;

    }
    interface IPlayable
    {
        event EventHandler<GameEndedEventArgs> RaiseEvent;
        void OnGameEnd();
        void Restore();
    }
    internal partial class Engine
    {
        private class PlayerDriven : IPlayable
        {
            public event EventHandler<GameEndedEventArgs> RaiseEvent;
            private const int numberOfMoves = 25;
            private static readonly ImmutableArray<bool> moves = [true, true, true, true, true, false, false, false, false, false, 
                true, true, true, true, false, false, false, false, 
                true, true, true, false, false, false, 
                true, false];
            private int currentMove = 0;


            public bool MakeMove()
            {
                if (currentMove > numberOfMoves)
                {
                    OnGameEnd();
                    return false;
                }
                bool result = moves[currentMove];
                currentMove++;
                return result;
            }

            public void OnGameEnd()
            {
                RaiseEvent?.Invoke(this, new GameEndedEventArgs(EndReason.PlayerDrivenTriggered));
            }

            public void Restore()
            {
                currentMove = 0;
            }
        }
    }

}
