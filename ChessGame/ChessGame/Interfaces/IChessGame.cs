using Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IChessGame
    {
        IEnumerable<Square> GetFigures(Figures figure, FigureColors figureColor);
    }
}
