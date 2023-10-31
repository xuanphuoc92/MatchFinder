using FluentAssertions;

namespace MatchFinder.Test
{
    [TestClass]
    public class Game_Test
    {
        [TestMethod]
        public void _01_NewAdd()
        {
            Game game = Game.New();
            game.Cells.Should().HaveCount(0);
            game.Add(0);
            game.Cells.Should().HaveCount(1);
        }
    }
}