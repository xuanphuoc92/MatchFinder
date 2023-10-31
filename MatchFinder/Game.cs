using System;
using System.Collections.Generic;

namespace MatchFinder
{
    public class Game
    {
        public List<Cell> Cells { get; private set; }
        public DateTime? StartTime { get; private set; }

        private Game() 
        {
            Cells = new List<Cell>();
        }

        public static Game New() { return new Game(); }
        public Game Add(int cellContent)
        {
            Cells.Add(new Cell() { Content = cellContent });
            return this;
        }

        public void Pick(int cellIndex)
        {
            if (StartTime == null)
                StartTime = DateTime.Now;
        }
    }

    public class Cell
    {
        public int Content { get; set; }
    }
}
