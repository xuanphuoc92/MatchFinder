using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchFinder
{
    public class Game
    {
        public List<Cell> Cells { get; private set; }
        public DateTime? StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }

        private Game() 
        {
            Reset();
        }

        public Game Reset()
        {
            Cells = new List<Cell>();
            StartTime = null;
            EndTime = null;
            return this;
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
            if (cell.IsPicked || cell.IsMatched) 
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
            CheckEnd();
            Unpick();
            return this;
        }

        private void CheckEnd()
        {
            if (_pick1.IsMatched == false)
                return;

            if (Cells.Any(c => c.IsMatched == false))
                return;

            EndTime = DateTime.Now;
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
            _pick1.IsPicked = _pick2.IsPicked = false;
            _pick1 = _pick2 = null;
        }

        public Game AddRandoms(int cells)
        {
            for (int i = 0; i < cells; i++)
                Add(-1);

            Random rnd = new Random();
            var randomlyOrdered = Cells.OrderBy(c => rnd.Next()).ToList();
            for (int i = 0; i < cells; i++)
                randomlyOrdered[i].Content = i / 2;

            return this;
        }
    }

    public class Cell
    {
        public int Content { get; internal set; }
        public bool IsPicked { get; internal set; }
        public bool IsMatched { get; internal set; }
    }
}
