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
    }
}