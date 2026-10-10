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
        public event EventHandler<EventArgs> RaiseEvent;
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

                int current = (int)lvl;
                int next = (int)value;

                int diff = Math.Abs(current - next);

                if (diff == 1)
                {
                    lvl = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(lvl), "Можно переходить только на один уровень.");
                }

            } 
        }

        public Map()
        {
            lvl = Level.Level0;
        }

        public void EndGame()
        {
            RaiseEvent.Invoke(this, EventArgs.Empty);
        }

        public void Restore()
        {
            lvl = Level.Level0;
        }
    }
}
