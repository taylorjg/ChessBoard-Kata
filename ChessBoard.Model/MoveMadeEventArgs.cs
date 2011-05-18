using System;

namespace Chess.Model
{
    /// <summary>
    /// Class passed to handlers of events generated when a move has been made.
    /// </summary>
    public class MoveMadeEventArgs : EventArgs
    {
        public MoveMadeEventArgs(BoardPosition from, BoardPosition to, ChessPiece chessPiece)
        {
            this.From = from;
            this.To = to;
            this.ChessPiece = chessPiece;
        }

        public BoardPosition From { get; private set; }
        public BoardPosition To { get; private set; }
        public ChessPiece ChessPiece { get; private set; }
    }
}
