using NUnit.Framework;
using System;
using TicTac;

namespace TicTacTest
{
    public class Tests
    {
        

        [Test]
        [TestCase(Player.X, 0, 0)]
        [TestCase(Player.X, -1, 0)]
        [TestCase(Player.X, 0, 3)]
        public void Play_NoValid_ShouldException(Player player,int x,int y)
        {
            Game game = new Game(Player.X);
            var ex = Assert.Throws<Exception>(() => game.Play(player, x, y));
            Assert.AreEqual("Not Valid", ex.Message);
        }


        [Test]
        public void Play_WhenXWin_ThenResultShouldbeResultWin()
        {
            Game game = new Game(Player.O);
            game.Play(Player.X, 0, 0);
            game.Play(Player.O, 1, 0);
            game.Play(Player.X, 0, 1);
            game.Play(Player.O, 2, 0);
            game.Play(Player.X, 0, 2);
            Assert.AreEqual(PlayResult.WinX, game.GetResult());
        }

    }
}