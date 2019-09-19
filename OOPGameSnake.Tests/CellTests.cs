using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OOPGameSnake.Tests
{
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void TwoCellsAreEqualWithEqualXY()
        {
            var firstCell = new Cell(2, 2);
            var secondCell = new Cell(2, 2);

            Assert.AreEqual(firstCell.GetHashCode(), secondCell.GetHashCode());
        }

        [TestMethod]
        public void TwoCellsAreNotEqualWithDiffXY()
        {
            var firstCell = new Cell(3, 2);
            var secondCell = new Cell(2, 2);

            Assert.AreNotEqual(firstCell.GetHashCode(), secondCell.GetHashCode());
        }
    }
}
