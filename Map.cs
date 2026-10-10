using System.ComponentModel.DataAnnotations;

namespace rgr
{
    enum Level
    {
        Level0 = 0,
        Level1 = 1,
        Level2 = 2,
        Level3 = 3,
        Level4 = 4,
        Level5 = 5,
    }

    class Map : IPlayable
    {
        public event EventHandler<GameEndedEventArgs> RaiseEvent;
        private Level lvl;

        public Level Lvl 
        {
            get => lvl;
            set 
            {
                if (value == lvl)
                {
                    throw new ArgumentException(nameof(lvl), "Нельзя остаться на том же уровне.");
                }
                
                int diff = Math.Abs((int)lvl - (int)value);

                if (diff == 1)
                {
                    lvl = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(lvl), "Можно переходить только на один уровень.");
                }
                if (lvl == Level.Level5)
                {
                    OnGameEnd();
                }
            } 
        }

        public Map()
        {
            lvl = Level.Level0;
        }

        public void OnGameEnd()
        {
            RaiseEvent.Invoke(this, new GameEndedEventArgs(EndReason.MapTriggered));
        }

        public void Restore()
        {
            lvl = Level.Level0;
        }
    }
}
