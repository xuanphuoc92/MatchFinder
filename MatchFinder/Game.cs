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

        private Cell _pick1 { get; set; } = null;
        private Cell _pick2 { get; set; } = null;

        public Game Pick(int cellIndex)
        {
            if (StartTime == null)
                StartTime = DateTime.Now;

            Cell cell = Cells[cellIndex];
            if (cell.IsPicked) 
                return this;

            cell.IsPicked = true;
            if (_pick1 == null)
            {
                _pick1 = cell;
                return this;
            }

            if (_pick2 == null)
            {
                _pick2 = cell;
            }

            Match();
            Unpick();
            return this;
        }

        private void Match()
        {
            if (_pick1.Content == _pick2.Content)
            {
                _pick1.IsMatched = _pick2.IsMatched= true;
            }
        }

        private void Unpick()
        {
            _pick1.IsPicked = false;
            _pick2.IsPicked = false;
            _pick1 = _pick2 = null;
        }
    }

    public class Cell
    {
        public int Content { get; set; }
        public bool IsPicked { get; set; }
        public bool IsMatched { get; set; }
    }
}
