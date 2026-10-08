using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rgr
{
    interface IRestorable
    {
        void Restore();
    }
    internal partial class Engine
    {
        private class PlayerDriven : IRestorable
        {
            private const int numberOfMoves = 25;
            private static readonly ImmutableArray<bool> moves = [true, false];
            private int currentMove = 0;

            public bool MakeMove()
            {
                if (currentMove > numberOfMoves)
                {
                    throw new ArgumentOutOfRangeException();
                }
                bool result = moves[currentMove];
                currentMove++;
                return result;
            }

            public void Restore()
            {
                currentMove = 0;
            }
        }
    }

}
