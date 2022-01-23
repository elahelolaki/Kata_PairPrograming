using NUnit.Framework;
using ScoreKeeper;

namespace ScoreKeeperTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]  
        [TestCase(0, 0, "000:000")]
        [TestCase(999, 0, "999:000")]
        [TestCase(0, 999, "000:999")]
        [TestCase(999, 999, "999:999")]
        public void GivenANewScoreKeeper_WhenStartingANewGame_ThenScoreIsSet(int initialScoreA, int initialScoreB,
            string visualScore)
        {
            var scoreKeeper = new Keeper(initialScoreA, initialScoreB);
            Assert.AreEqual(visualScore, scoreKeeper.Show());
        }

        [Test]
        public void GivenANewScoreKeeper_WhenTeamAScoresTwoPoints_ThenScoreIs2Vs0()
        {
            var scoreKeeper = new Keeper(0, 0);
            scoreKeeper.ScoreTeamA2();
            Assert.AreEqual("002:000", scoreKeeper.Show());
        }

        [Test]
        public void GivenANewScoreKeeper_WhenTeamBScoresTwoPoints_ThenScoreIs0Vs2()
        {
            var scoreKeeper = new Keeper(0, 0);
            scoreKeeper.ScoreTeamB2();
            Assert.AreEqual("000:002", scoreKeeper.Show());
        }
    }
}