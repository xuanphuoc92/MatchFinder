using FluentAssertions;

namespace MatchFinder.Test
{
    [TestClass]
    public class Game_Test
    {
        [TestMethod]
        public void _01_New_Add()
        {
            Game game = Game.New();
            game.Cells.Should().HaveCount(0);
            game.Add(0);
            game.Cells.Should().HaveCount(1);
        }

        [TestMethod]
        public void _02_StartTime_Pick()
        {
            Game game = Game.New();
            game.Add(0).Add(0);
            game.StartTime.Should().BeNull();

            DateTime now = DateTime.Now;
            game.Pick(0);
            game.StartTime.Should().BeOnOrAfter(now);
        }

        [TestMethod]
        public void _03_IsPicked()
        {
            Game game = Game.New();
            game.Add(0).Add(0);
            game.Cells[0].IsPicked.Should().BeFalse();
            game.Cells[1].IsPicked.Should().BeFalse();
            game.Pick(0);
            game.Cells[0].IsPicked.Should().BeTrue();
            game.Cells[1].IsPicked.Should().BeFalse();
            game.Pick(0); // Try Pick again, which is invalid
            game.Cells[0].IsPicked.Should().BeTrue();
            game.Cells[1].IsPicked.Should().BeFalse();
        }

        [TestMethod]
        public void _04_Unpick()
        {
            Game game = Game.New();
            game.Add(0)
                .Add(0)
                .Add(1)
                .Add(1);

            game.Pick(0).Pick(2);

            game.Cells[0].IsPicked.Should().BeFalse();
            game.Cells[2].IsPicked.Should().BeFalse();
        }

        [TestMethod]
        public void _05_IsMatched()
        {
            Game game = Game.New();
            game.Add(0)
                .Add(0)
                .Add(1)
                .Add(1);

            game.Cells[0].IsMatched.Should().BeFalse();
            game.Cells[1].IsMatched.Should().BeFalse();

            game.Pick(0).Pick(1);

            game.Cells[0].IsMatched.Should().BeTrue();
            game.Cells[1].IsMatched.Should().BeTrue();            
        }
    }
}