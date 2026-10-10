using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rgr
{
    internal partial class Engine
    {
        private class PlayerLeader
        {
            private readonly Random rnd = new();
            private const double maxRndFactor = 1.0;
            private const double minRndFactor = 0.0;
            private double rndFactor = 0.5;
            public double RndFactor
            {
                get => rndFactor;
                set
                {
                    if (value < minRndFactor || value > maxRndFactor)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), "");
                    }
                    rndFactor = value;
                }
            }

            public bool MakeMove()
            {
                if (rnd.NextDouble() >= rndFactor)
                    return true;
                return false;
            }
        }
    }
}
