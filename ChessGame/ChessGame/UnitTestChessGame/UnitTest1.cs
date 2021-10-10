using Implementations;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestChessGame
{
    [TestClass]
    public class UnitTest1
    {
        IChessGame _chessGame;

        [TestInitialize]
        public void Setup()
        {
            Bootstrap bootstrap = new Bootstrap();
            ServiceProvider serviceProvider = bootstrap.Build();
            _chessGame = serviceProvider.GetService<IChessGame>();
        }

        [TestCleanup]
        public void TearDown()
        {

        }


        [TestMethod]
        public void TestKingStartPosition()
        {
            IEnumerable<Square> squares = _chessGame.GetFigures(Figures.King, FigureColors.White);
            Square square = squares.FirstOrDefault();

            Assert.AreEqual(square.Rank, SquareRanks.One);
            Assert.AreEqual(square.File, SquareFiles.E);
        }

        //[TestMethod]
        //public void TestPawnMoves()
        //{
        //    ChessGame chessGame = new ChessGame();
        //    Square<IEnumerable> pawnSquares = chessGame.GetCurrentSquares(ChessFigures.Pawn, FigureColor.White);
        //    Square pawnSquare = squares.FirstOrDefault();

        //    Square<IEnumerable> pawnSquaresToMove = chessGame.GetSquares(ChessFigures.Pawn, FigureColor.White);
        //    Assert.AreEqual(pawnSquare.rank, SquareRanks.One);
        //    Assert.AreEqual(pawnSquare.file, SquareFiles.E);
        //}
    }
}
