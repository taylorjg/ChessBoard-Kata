using System;

namespace Chess.Model
{
    /// <summary>
    /// Class passed to handlers of events generated when a piece is taken.
    /// </summary>
    public class PieceTakenEventArgs : EventArgs
    {
        public PieceTakenEventArgs(Square square, ChessPiece pieceTaken)
        {
            this.Square = square;
            this.PieceTaken = pieceTaken;
        }

        public Square Square { get; private set; }
        public ChessPiece PieceTaken { get; private set; }
    }
}
