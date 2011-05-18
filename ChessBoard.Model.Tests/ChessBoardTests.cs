using System;
using Chess.Model;
using NUnit.Framework;

namespace Chess.Model.Tests
{
    [TestFixture]
    public class ChessBoardTests
    {
        [Test]
        public void SetInitialPosition_GivenKnightAtA1_Succeeds()
        {
            var chessBoard = new ChessBoard();
            var boardPosition = new BoardPosition("A1");
            chessBoard.SetInitialPosition(boardPosition, new Knight(Colour.Black));

            Assert.That(chessBoard.GetSquare(boardPosition), Is.Not.Null);
            Assert.That(chessBoard.GetSquare(boardPosition).ChessPiece, Is.Not.Null);
            Assert.That(chessBoard.GetSquare(boardPosition).ChessPiece, Is.InstanceOf<Knight>());
            Assert.That(chessBoard.GetSquare(boardPosition).ChessPiece.Colour, Is.EqualTo(Colour.Black));
        }

        [Test]
        public void SetInitialPosition_GivenTwoPiecesAtSameLocation_ThrowsException()
        {
            var chessBoard = new ChessBoard();
            var boardPosition = new BoardPosition("A1");
            chessBoard.SetInitialPosition(boardPosition, new Knight(Colour.Black));

            try {
                chessBoard.SetInitialPosition(boardPosition, new Pawn(Colour.White));
                Assert.Fail("Expected a ChessBoardException to be thrown!");
            }
            catch (ChessBoardException ex) {
                Assert.That(ex.ExceptionReason, Is.EqualTo(ExceptionReason.InitialPositionAlreadyOccupied));
            }
        }

        [Test]
        public void MakeMove_GivenAValidMove_Succeeds()
        {
            var chessBoard = new ChessBoard();
            var blackKnight = new Knight(Colour.Black);
            var boardPosition1 = new BoardPosition("A1");
            var boardPosition2 = new BoardPosition("B3");
            chessBoard.SetInitialPosition(boardPosition1, blackKnight);
            chessBoard.MakeMove(boardPosition1, boardPosition2);

            Assert.That(chessBoard.GetSquare(boardPosition1), Is.Not.Null);
            Assert.That(chessBoard.GetSquare(boardPosition1).ChessPiece, Is.Null);

            Assert.That(chessBoard.GetSquare(boardPosition2), Is.Not.Null);
            Assert.That(chessBoard.GetSquare(boardPosition2).ChessPiece, Is.Not.Null);
            Assert.That(chessBoard.GetSquare(boardPosition2).ChessPiece, Is.InstanceOf<Knight>());
            Assert.That(chessBoard.GetSquare(boardPosition2).ChessPiece.Colour, Is.EqualTo(Colour.Black));
        }

        [Test]
        public void MakeMove_GivenAValidTakingMove_RaisesPieceTakenEvent()
        {
            PieceTakenEventArgs pieceTakenEventArgs = null;
            var chessBoard = new ChessBoard();
            var blackKnight = new Knight(Colour.Black);
            var whitePawn = new Pawn(Colour.White);
            var boardPosition1 = new BoardPosition("A1");
            var boardPosition2 = new BoardPosition("B3");
            chessBoard.SetInitialPosition(boardPosition1, blackKnight);
            chessBoard.SetInitialPosition(boardPosition2, whitePawn);

            chessBoard.PieceTaken += (sender, e) =>
            {
                pieceTakenEventArgs = e;
            };

            chessBoard.MakeMove(boardPosition1, boardPosition2);

            Assert.That(pieceTakenEventArgs, Is.Not.Null);
            Assert.That(pieceTakenEventArgs.PieceTaken, Is.Not.Null);
            Assert.That(pieceTakenEventArgs.PieceTaken, Is.InstanceOf<Pawn>());
            Assert.That(pieceTakenEventArgs.PieceTaken.Colour, Is.EqualTo(Colour.White));
            Assert.That(pieceTakenEventArgs.Square, Is.Not.Null);
            Assert.That(pieceTakenEventArgs.Square.ChessPiece, Is.Not.Null);
            Assert.That(pieceTakenEventArgs.Square.ChessPiece, Is.InstanceOf<Knight>());
            Assert.That(pieceTakenEventArgs.Square.ChessPiece.Colour, Is.EqualTo(Colour.Black));
        }

        [Test]
        public void MakeMove_GivenAValidTakingMove_RaisesGameOverEvent()
        {
            GameOverEventArgs gameOverEventArgs = null;
            var chessBoard = new ChessBoard();
            var blackKnight = new Knight(Colour.Black);
            var whitePawn = new Pawn(Colour.White);
            var boardPosition1 = new BoardPosition("A1");
            var boardPosition2 = new BoardPosition("B3");
            chessBoard.SetInitialPosition(boardPosition1, blackKnight);
            chessBoard.SetInitialPosition(boardPosition2, whitePawn);

            chessBoard.GameOver += (sender, e) =>
            {
                gameOverEventArgs = e;
            };

            chessBoard.MakeMove(boardPosition1, boardPosition2);

            Assert.That(gameOverEventArgs, Is.Not.Null);
            Assert.That(gameOverEventArgs.Result, Is.EqualTo(GameResult.BlackWin));
        }

        [Test]
        public void MakeMove_GivenAnInvalidTakingMove_ThrowsException()
        {
            var chessBoard = new ChessBoard();
            var blackKnight = new Knight(Colour.Black);
            var blackPawn = new Pawn(Colour.Black);
            var boardPosition1 = new BoardPosition("A1");
            var boardPosition2 = new BoardPosition("B3");
            chessBoard.SetInitialPosition(boardPosition1, blackKnight);
            chessBoard.SetInitialPosition(boardPosition2, blackPawn);

            try {
                chessBoard.MakeMove(boardPosition1, boardPosition2);
                Assert.Fail("Expected a ChessBoardException to be thrown!");
            }
            catch (ChessBoardException ex) {
                Assert.That(ex.ExceptionReason, Is.EqualTo(ExceptionReason.IllegalMove));
            }
        }

        [Test]
        public void MakeMove_GivenAWhitePawnCollision_RaisesGameOverEvent()
        {
            GameOverEventArgs gameOverEventArgs = null;
            var chessBoard = new ChessBoard();
            var blackKnight = new Knight(Colour.Black);
            var whitePawn = new Pawn(Colour.White);
            var boardPosition1 = new BoardPosition("A2");
            var boardPosition2 = new BoardPosition("A3");
            chessBoard.SetInitialPosition(boardPosition2, blackKnight);
            chessBoard.SetInitialPosition(boardPosition1, whitePawn);

            chessBoard.GameOver += (sender, e) =>
            {
                gameOverEventArgs = e;
            };

            chessBoard.MakeMove(boardPosition1, boardPosition2);

            Assert.That(gameOverEventArgs, Is.Not.Null);
            Assert.That(gameOverEventArgs.Result, Is.EqualTo(GameResult.Draw));
        }
    }
}
