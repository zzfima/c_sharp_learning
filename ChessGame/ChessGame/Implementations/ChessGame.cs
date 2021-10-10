using Interfaces;
using Models;
using System.Collections.Generic;

namespace Implementations
{
    public class ChessGame : IChessGame
    {
        public IEnumerable<Square> GetFigures(Figures figure, FigureColors figureColor)
        {
            List<Square> squares = new List<Square>();

            return squares;
        }
    }
}
