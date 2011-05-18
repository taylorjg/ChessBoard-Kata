using System;

namespace Chess.Model
{
    /// <summary>
    /// This class represents a chess board.
    /// </summary>
    public class ChessBoard
    {
        private Square[,] squares;

        public event EventHandler<GameOverEventArgs> GameOver;
        public event EventHandler<PieceTakenEventArgs> PieceTaken;
        public event EventHandler<MoveMadeEventArgs> MoveMade;

        /// <summary>
        /// Initialises a new instance of the ChessBoard class.
        /// </summary>
        public ChessBoard()
        {
            this.Round = 1;
            this.squares = new Square[8, 8];
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    this.squares[i, j] = new Square();
                }
            }
        }

        /// <summary>
        /// Add a chess piece to the board at a given position.
        /// </summary>
        /// <param name="boardPosition">The initial position at which to place the chess piece</param>
        /// <param name="chessPiece">The chess piece to be placed</param>
        public void SetInitialPosition(BoardPosition boardPosition, ChessPiece chessPiece)
        {
            Square square = GetSquare(boardPosition);

            if (square.ChessPiece != null) {
                var ex = new ChessBoardException(ExceptionReason.InitialPositionAlreadyOccupied);
                throw ex;
            }

            square.ChessPiece = chessPiece;
            chessPiece.BoardPosition = boardPosition;
        }

        /// <summary>
        /// Move a chess piece from one board position to another.
        /// </summary>
        /// <param name="fromBoardPosition">The board position to move a chess piece from</param>
        /// <param name="toBoardPosition">The board position to move a chess piece to</param>
        public void MakeMove(BoardPosition from, BoardPosition to)
        {
            Square fromSquare = GetSquare(from);
            Square toSquare = GetSquare(to);

            ChessPiece pieceBeingMoved = fromSquare.ChessPiece;

            if (pieceBeingMoved == null) {
                var ex = new ChessBoardException(ExceptionReason.FromSquareIsNotOccupied);
                throw ex;
            }

            GameResult? gameResult = null;
            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = pieceBeingMoved.ValidateMove(this, from, to, out exceptionReasonDetail);

            switch (moveResult) {

                case MoveResult.Valid:

                    // Does this move involve a piece being taken ?
                    if (toSquare.ChessPiece != null) {
                        ChessPiece takenPiece = toSquare.ChessPiece;
                        RaisePieceTaken(toSquare, takenPiece);
                        takenPiece.BoardPosition = null;
                        gameResult = (pieceBeingMoved.Colour == Colour.White) ? GameResult.WhiteWin : GameResult.BlackWin;
                    }

                    fromSquare.ChessPiece = null;
                    toSquare.ChessPiece = pieceBeingMoved;
                    pieceBeingMoved.BoardPosition = to;
                    RaiseMoveMade(from, to, pieceBeingMoved);
                    break;

                case MoveResult.Collision:
                    gameResult = GameResult.Draw;
                    break;

                case MoveResult.Illegal:
                    var ex = new ChessBoardException(ExceptionReason.IllegalMove, exceptionReasonDetail);
                    throw ex;

                default:
                    break;
            }

            // By convention, White always goes first so if we just moved
            // a Black piece, this must be the end of a round.
            // NOTE: There is nothing in the SpecFlow features regarding :-
            //       - which colour goes first
            //       - checking that turns alternate colour
            //       - checking the maximum number of rounds (meant to be 2)
            //       - etc.
            if (pieceBeingMoved.Colour == Colour.Black) {
                this.Round++;
            }

            if (gameResult.HasValue) {
                RaiseGameOver(gameResult.Value);
            }
        }

        /// <summary>
        /// The round (turn) number.
        /// </summary>
        public int Round { get; internal set; }

        /// <summary>
        /// Returns the Square at the given board position.
        /// </summary>
        /// <param name="boardPosition">The board position for which the Square should be returned</param>
        /// <returns>The Square at the given board position</returns>
        public virtual Square GetSquare(BoardPosition boardPosition)
        {
            return this.squares[boardPosition.InternalFile, boardPosition.InternalRank];
        }

        private void RaiseGameOver(GameResult result)
        {
            var handler = this.GameOver;
            if (handler != null) {
                var eventArgs = new GameOverEventArgs(result);
                handler(this, eventArgs);
            }
        }

        private void RaisePieceTaken(Square square, ChessPiece pieceTaken)
        {
            var handler = this.PieceTaken;
            if (handler != null) {
                var eventArgs = new PieceTakenEventArgs(square, pieceTaken);
                handler(this, eventArgs);
            }
        }

        private void RaiseMoveMade(BoardPosition from, BoardPosition to, ChessPiece chessPiece)
        {
            var handler = this.MoveMade;
            if (handler != null) {
                var eventArgs = new MoveMadeEventArgs(from, to, chessPiece);
                handler(this, eventArgs);
            }
        }
    }
}
