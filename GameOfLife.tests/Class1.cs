using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GAmeOflife.tests
{
    [TestFixture]
    public class Class1
    {
        const bool LIVE = true;
        const bool DEAD = false;
        [Test]
        public void VerifyAllDeadREturnsAllDead()
        {
            var gameOfLife = new GameOfLife.GameOfLife();
            var input = new List<List<bool>>
            {
                new List<bool> {DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD},
                new List<bool> {DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD},
                new List<bool> {DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD},
                new List<bool> {DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD}
            };

            var returnedGrid = gameOfLife.ProcessGrid(input);

            Assert.That(returnedGrid, Is.EqualTo(input));


        }

        [Test]
        public void VerifyLiveCellWithLessThen2LiveNeighboursDies()
        {
            var gameOfLife = new GameOfLife.GameOfLife();
            var input = new List<List<bool>>
            {
                new List<bool> {DEAD, DEAD, LIVE, DEAD, DEAD, DEAD, DEAD, DEAD},
                new List<bool> {DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD},
                new List<bool> {DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD},
                new List<bool> {DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD}
            };

            var expected = new List<List<bool>>
            {
                new List<bool> {DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD},
                new List<bool> {DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD},
                new List<bool> {DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD},
                new List<bool> {DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD}
            };

            var returnedGrid = gameOfLife.ProcessGrid(input);

            Assert.That(returnedGrid, Is.EqualTo(expected));
        }

        [Test]
        public void VerifyLiveCellWithMoreThan3LiveNeighboursDies()
        {
            var gameOfLife = new GameOfLife.GameOfLife();
            var input = new List<List<bool>>
            {
                new List<bool> {DEAD, DEAD, LIVE, DEAD, DEAD, DEAD, DEAD, DEAD},
                new List<bool> {DEAD, LIVE, LIVE, LIVE, DEAD, DEAD, DEAD, DEAD},
                new List<bool> {DEAD, DEAD, LIVE, DEAD, DEAD, DEAD, DEAD, DEAD},
                new List<bool> {DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD}
            };

            var expected = new List<List<bool>>
            {
                new List<bool> {DEAD, DEAD, LIVE, DEAD, DEAD, DEAD, DEAD, DEAD},
                new List<bool> {DEAD, LIVE, DEAD, LIVE, DEAD, DEAD, DEAD, DEAD},
                new List<bool> {DEAD, DEAD, LIVE, DEAD, DEAD, DEAD, DEAD, DEAD},
                new List<bool> {DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD, DEAD}
            };

            var returnedGrid = gameOfLife.ProcessGrid(input);

            Assert.That(returnedGrid, Is.EqualTo(expected));
        }


    }
}
