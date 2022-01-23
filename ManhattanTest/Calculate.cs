using Manhattan;
using NUnit.Framework;
using System;

namespace ManhattanTest
{
    [TestFixture]
    public class Calculate
    {
        [Test]
        [TestCase(new string[]{"-1:5", "1:6", "3:5", "2:3" }, 22)]
        public void ManhattanDistance(string[] points,int expected)
        {
            //Arrange
            var grid=new Grid(points);
            //Act
            int actual = 0;
            for (int i = 0; i < grid.Points.Count - 1; i++)
            {
                int sumNested = 0;
                for (int j = i + 1; j < grid.Points.Count; j++)
                {
                    sumNested += grid.ManhattanDistance(grid.Points[i],grid.Points[j]); 
                }
                actual += sumNested;
            }  

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
