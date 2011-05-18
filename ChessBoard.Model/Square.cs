using System;

namespace Chess.Model
{
    /// <summary>
    /// This class represents an individual square on a chess board and the
    /// chess piece that currently occupies the square (if any).
    /// </summary>
    public class Square
    {
        public Square()
        {
            this.ChessPiece = null;
        }

        /// <summary>
        /// The chess piece that currently occupies this square (if any).
        /// </summary>
        public ChessPiece ChessPiece { get; set; }
    }
}
