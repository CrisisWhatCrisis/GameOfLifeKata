using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace GAmeOflife.tests
{
    [TestFixture]
    public class GameOfLifeTests
    {
        private const bool Live = true;
        private const bool Dead = false;

        [Test]
        public void VerifyAllDeadREturnsAllDead()
        {
            var gameOfLife = new GameOfLife.GameOfLife();
            var input = new List<List<bool>>
            {
                new List<bool> {Dead, Dead, Dead, Dead, Dead, Dead, Dead, Dead},
                new List<bool> {Dead, Dead, Dead, Dead, Dead, Dead, Dead, Dead},
                new List<bool> {Dead, Dead, Dead, Dead, Dead, Dead, Dead, Dead},
                new List<bool> {Dead, Dead, Dead, Dead, Dead, Dead, Dead, Dead}
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
                new List<bool> {Dead, Dead, Live, Dead, Dead, Dead, Dead, Dead},
                new List<bool> {Dead, Dead, Dead, Dead, Dead, Dead, Dead, Dead},
                new List<bool> {Dead, Dead, Dead, Dead, Dead, Dead, Dead, Dead},
                new List<bool> {Dead, Dead, Dead, Dead, Dead, Dead, Dead, Dead}
            };

            var expected = new List<List<bool>>
            {
                new List<bool> {Dead, Dead, Dead, Dead, Dead, Dead, Dead, Dead},
                new List<bool> {Dead, Dead, Dead, Dead, Dead, Dead, Dead, Dead},
                new List<bool> {Dead, Dead, Dead, Dead, Dead, Dead, Dead, Dead},
                new List<bool> {Dead, Dead, Dead, Dead, Dead, Dead, Dead, Dead}
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
                new List<bool> {Dead, Dead, Live, Dead, Dead, Dead, Dead, Dead},
                new List<bool> {Dead, Live, Live, Live, Dead, Dead, Dead, Dead},
                new List<bool> {Dead, Dead, Live, Dead, Dead, Dead, Dead, Dead},
                new List<bool> {Dead, Dead, Dead, Dead, Dead, Dead, Dead, Dead}
            };

            var expected = new List<List<bool>>
            {
                new List<bool> {Dead, Dead, Live, Dead, Dead, Dead, Dead, Dead},
                new List<bool> {Dead, Live, Dead, Live, Dead, Dead, Dead, Dead},
                new List<bool> {Dead, Dead, Live, Dead, Dead, Dead, Dead, Dead},
                new List<bool> {Dead, Dead, Dead, Dead, Dead, Dead, Dead, Dead}
            };

            var result = gameOfLife.ProcessGrid(input);

            Assert.That(result, Is.EqualTo(expected),
                string.Format(@"Expected:{2}{0}{2}Returned:{2}{1}{2}{2}", ConvertToText(expected), ConvertToText(result), Environment.NewLine));
        }

        private static string ConvertToText(IReadOnlyList<List<bool>> grid)
        {
            var pattern = new StringBuilder();

            var rowCount = grid.Count;
            for (var row = 0; row < rowCount; row++)
            {
                var columnCount = grid[row].Count;
                for (var column = 0; column < columnCount; column++)
                {
                    pattern.Append(grid[row][column] ? "*" : ".");
                }
                pattern.AppendLine();
            }
            return pattern.ToString();
        }
    }
}
