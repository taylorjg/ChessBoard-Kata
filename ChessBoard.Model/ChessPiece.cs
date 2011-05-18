using System;

namespace Chess.Model
{
    /// <summary>
    /// Abstract base class representing a chess piece.
    /// </summary>
    public abstract class ChessPiece
    {
        /// <summary>
        /// Initialises a new instance of the ChessPiece class with the given colour.
        /// </summary>
        /// <param name="colour">The colour of the chess piece.</param>
        public ChessPiece(Colour colour)
            : this(colour, null)
        {
        }

        /// <summary>
        /// Initialises a new instance of the ChessPiece class with the given colour and initial board position.
        /// </summary>
        /// <param name="colour">The colour of the chess piece.</param>
        /// <param name="boardPosition">The initial board position of the chess piece.</param>
        public ChessPiece(Colour colour, BoardPosition boardPosition)
        {
            this.Colour = colour;
            this.BoardPosition = null;
            this.Name = string.Empty;
        }

        /// <summary>
        /// Determine whether the given move is valid for this chess piece on the given chess board.
        /// </summary>
        /// <param name="chessBoard">The chess board on which the chess piece is being moved.</param>
        /// <param name="from">The board position from which the chess piece is being moved.</param>
        /// <param name="to">The board position to which the chess piece is being moved.</param>
        /// <returns></returns>
        internal virtual MoveResult ValidateMove(
            ChessBoard chessBoard,
            BoardPosition from,
            BoardPosition to,
            out ExceptionReasonDetail exceptionReasonDetail)
        {
            exceptionReasonDetail = ExceptionReasonDetail.None;
            return MoveResult.Illegal;
        }

        /// <summary>
        /// The colour of this chess piece.
        /// </summary>
        public Colour Colour { get; private set; }

        /// <summary>
        /// The board position of this chess piece.
        /// </summary>
        public BoardPosition BoardPosition { get; set; }

        /// <summary>
        /// The name of this chess piece e.g. "Knight", "Pawn", etc.
        /// </summary>
        public string Name { get; protected set; }
    }
}
