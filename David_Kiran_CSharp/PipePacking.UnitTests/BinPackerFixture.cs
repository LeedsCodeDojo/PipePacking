using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace PipePacking.UnitTests
{
    [TestFixture]
    class BinPackerFixture
    {
        private BinPacker _binPacker;

        private const int BinSize = 10;

        [SetUp]
        public void SetUp()
        {
            _binPacker = new BinPacker();
        }

        [Test]
        public void Pack_10_ReturnsOneBinWith10()
        {
            // Arrange
            var expected = new List<List<int>> { new List<int> { 10 } };
            var pipesList = new List<int> { 10 };

            // Act
            var actual = _binPacker.Pack(BinSize, pipesList);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Pack_5and5_ReturnsOneBinWith5and5()
        {
            // Arrange
            var expected = new List<List<int>> { new List<int> { 5, 5 } };
            var pipesList = new List<int> { 5, 5 };

            // Act
            var actual = _binPacker.Pack(BinSize, pipesList);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Pack_6and6_ReturnsTwoBinsWith6Each()
        {
            // Arrange
            var expected = new List<List<int>> { new List<int> { 6, }, new List<int> { 6, }, };
            var pipesList = new List<int> { 6, 6 };

            // Act
            var actual = _binPacker.Pack(BinSize, pipesList);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Pack_8and8and2and2_ReturnsTwoBinsWith8and2Each()
        {
            // Arrange
            var expected = new List<List<int>> { new List<int> { 8, 2 }, new List<int> { 8, 2 }, };
            var pipesList = new List<int> { 8, 8, 2, 2 };

            // Act
            var actual = _binPacker.Pack(BinSize, pipesList);

            // Assert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void Pack_7and8and2and3_ReturnsTwoBinsWith7and3_8and2()
        {
            // Arrange
            var expected = new List<List<int>> { new List<int> { 7, 3 }, new List<int> { 8, 2 }, };
            var pipesList = new List<int> { 7, 8, 2, 3 };

            // Act
            var actual = _binPacker.Pack(BinSize, pipesList);

            // Assert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void Pack_MultiPackChallenge_ReturnsOptimumPacking()
        {
            // Arrange
            const int binSize = 13;
            var expected = new List<List<int>>
            {
                new List<int> { 4, 9 }, new List<int> { 4, 9 }, 
                new List<int> { 5, 8 }, new List<int> { 1, 6, 6 }, 
                new List<int> { 8, 3, 1, 1, }, new List<int> { 6 }, 
                new List<int> { 8 }, 
            };
            var pipesList = new List<int> { 1, 1, 1, 3, 4, 4, 5, 6, 6, 6, 8, 8, 8, 9, 9 };

            // Act
            var actual = _binPacker.Pack(binSize, pipesList);

            // Assert
            actual.Count.Should().Be(expected.Count);
            actual.ForEach(x=>x.Sum().Should().BeLessOrEqualTo(binSize));
            actual.Sum(x => x.Count).Should().Be(pipesList.Count);
        }


        [Test]
        public void Pack_MultiPackChallengeWithOut1_ReturnsOptimumPacking()
        {
            // Arrange
            const int binSize = 13;
            var expected = new List<List<int>>
            {
                new List<int> { 4, 9 }, new List<int> { 4, 9 }, 
                new List<int> { 5, 8 }, new List<int> { 1, 6, 6 }, 
                new List<int> { 8, 3, 1, }, new List<int> { 6 }, 
                new List<int> { 8 }, 
            };
            var pipesList = new List<int> { 1, 1, 3, 4, 4, 5, 6, 6, 6, 8, 8, 8, 9, 9 };

            // Act
            var actual = _binPacker.Pack(binSize, pipesList);

            // Assert
            actual.Count.Should().Be(expected.Count);
            actual.ForEach(x => x.Sum().Should().BeLessOrEqualTo(binSize));
            actual.Sum(x => x.Count).Should().Be(pipesList.Count);
        }

    }
}
