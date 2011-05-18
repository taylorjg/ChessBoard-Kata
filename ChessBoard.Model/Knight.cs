using System;

namespace Chess.Model
{
    /// <summary>
    /// This class represents a Knight chess piece.
    /// </summary>
    public class Knight : ChessPiece
    {
         public Knight(Colour colour) : base(colour)
        {
            this.Name = "Knight";
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
             int rankDiff = Math.Abs(from.InternalRank - to.InternalRank);

             if ((fileDiff == 2 && rankDiff == 1) || (fileDiff == 1 && rankDiff == 2)) {
                 Square toSquare = chessBoard.GetSquare(to);
                 if (toSquare.ChessPiece == null || toSquare.ChessPiece.Colour != this.Colour) {
                     result = MoveResult.Valid;
                 }
             }

             return result;
         }
    }
}
