using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace UnitTestChessGame
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestKingStartPosition()
        {
            ChessGame chessGame = new ChessGame();
            Square<IEnumerable> squares = chessGame.GetCurrentSquare(ChessFigures.King, FigureColor.White);
            Square square = squares.FirstOrDefault();

            Assert.AreEqual(square.rank, SquareRanks.One);
            Assert.AreEqual(square.file, SquareFiles.E);
        }
    }
}
