using System;

namespace Chess.Model
{
    /// <summary>
    /// This class represents a Pawn chess piece.
    /// </summary>
    public class Pawn : ChessPiece
    {
        public Pawn(Colour colour)
            : base(colour)
        {
            this.Name = "Pawn";
        }

        internal override MoveResult ValidateMove(
            ChessBoard chessBoard,
            BoardPosition from,
            BoardPosition to,
            out ExceptionReasonDetail exceptionReasonDetail)
        {
            exceptionReasonDetail = ExceptionReasonDetail.None;
            MoveResult result = MoveResult.Illegal;

            int fileDiff = Math.Abs(from.InternalFile - to.InternalFile);
            int forward = (this.Colour == Colour.White) ? to.InternalRank - from.InternalRank : from.InternalRank - to.InternalRank;

            Square toSquare = chessBoard.GetSquare(to);

            if (forward == 1) {

                if (fileDiff == 0) {
                    if (toSquare.ChessPiece != null) {
                        result = MoveResult.Collision;
                    }
                    else {
                        result = MoveResult.Valid;
                    }
                }

                if (fileDiff == 1) {
                    if (toSquare.ChessPiece != null && toSquare.ChessPiece.Colour != this.Colour) {
                        result = MoveResult.Valid;
                    }
                    else {
                        exceptionReasonDetail = ExceptionReasonDetail.PawnCannotMoveDiagonallyUnlessCapturing;
                    }
                }
            }

            if (forward == 2 && fileDiff == 0) {
                bool onHomeRank = (this.Colour == Colour.White && from.Rank == 2) || (this.Colour == Colour.Black && from.Rank == 7);
                if (onHomeRank && chessBoard.Round == 1) {
                    int inbetweenFile = from.InternalFile;
                    int inbetweenRank = (this.Colour == Colour.White) ? from.InternalRank + 1 : from.InternalRank - 1;
                    Square inbetweenSquare = chessBoard.GetSquare(new BoardPosition(inbetweenFile, inbetweenRank));
                    if (inbetweenSquare.ChessPiece != null) {
                        result = MoveResult.Collision;
                    }
                    else {
                        if (toSquare.ChessPiece == null) {
                            result = MoveResult.Valid;
                        }
                    }
                }
                else {
                    exceptionReasonDetail = ExceptionReasonDetail.PawnCannotMoveTwoSpacesAtThisTime;
                }
            }

            return result;
        }
    }
}
