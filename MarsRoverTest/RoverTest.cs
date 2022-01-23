using MarsRover;
using System; 
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace MarsRoverTest
{
    [TestFixture]
    public class RoverTest
    {
        [Test]
        [TestCase("5 5", "1 2 N", "LMLMLMLMM", "1 3 N")]
        [TestCase("5 5","3 3 E", "MMRMMRMRRM", "5 1 E")]
        public void TestMoveShoudAddPositionY(string plateau, string currentPosition, string command,string expected)
        {
            //Act
            string Actual = Navigate.Move(plateau, currentPosition,command);

            //Assert
            Assert.AreEqual(expected, Actual);
        }
    }
}
