using System;
using System.Collections.Generic;
using Chess.Model;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class StepDefinitions
    {
        private const string BLACK_KNIGHT_WINS_MESSAGE = "Knight takes Pawn. Knight wins";
        private const string WHITE_PAWN_WINS_MESSAGE = "Pawn takes Knight. Pawn wins";
        private const string COLLISION_DRAW_MESSAGE = "Pawn collides with Knight. Draw";
        private const string ILLEGAL_MOVE_EXCEPTION_MESSAGE = "illegal move";
        private const string ILLEGAL_PAWN_MOVE_DETAIL_TWO_SPACES = "Pawn cannot move 2 spaces unless it is the first round and is on the home row.";
        private const string ILLEGAL_PAWN_MOVE_DETAIL_DIAGONAL = "Pawn cannot move diagonally unless it is capturing a piece.";

        [Given(@"the game has just started")]
        public void TheGameHasJustStarted()
        {
            var chessBoard = ScenarioContextUtils.GetChessBoard();
            chessBoard.Round = 1;
        }

        [Given(@"the game has not just started")]
        public void TheGameHasNotJustStarted()
        {
            var chessBoard = ScenarioContextUtils.GetChessBoard();
            chessBoard.Round = 2;
        }

        [Given(@"the Knight is on ([A-Z][0-9])")]
        [Given(@"the Knight is at ([A-Z][0-9])")]
        [Given(@"I have a Black Knight at ([A-Z][0-9])")]
        public void IHaveABlackKnightAt(string boardPosition)
        {
            var chessBoard = ScenarioContextUtils.GetChessBoard();
            var blackKnight = new Knight(Colour.Black);
            chessBoard.SetInitialPosition(new BoardPosition(boardPosition), blackKnight);
            ScenarioContextUtils.SetBlackKnight(blackKnight);
        }

        [Given(@"the Pawn is on ([A-Z][0-9])")]
        [Given(@"the Pawn is at ([A-Z][0-9])")]
        [Given(@"I have a White Pawn at ([A-Z][0-9])")]
        public void IHaveAWhitePawnAt(string boardPosition)
        {
            var chessBoard = ScenarioContextUtils.GetChessBoard();
            var whitePawn = new Pawn(Colour.White);
            chessBoard.SetInitialPosition(new BoardPosition(boardPosition), whitePawn);
            ScenarioContextUtils.SetWhitePawn(whitePawn);
        }

        [Given(@"the Knight moves to ([A-Z][0-9])")]
        [When(@"the Knight moves to ([A-Z][0-9])")]
        [Given(@"I move the Knight to ([A-Z][0-9])")]
        [When(@"I move the Knight to ([A-Z][0-9])")]
        public void IMoveTheKnightTo(string boardPosition)
        {
            var chessBoard = ScenarioContextUtils.GetChessBoard();
            var blackKnight = ScenarioContextUtils.GetBlackKnight();

            EventHandler<PieceTakenEventArgs> pieceTakenHandler = (sender, e) =>
            {
                ScenarioContextUtils.SetPieceTakenEventArgs(e);
            };
            EventHandler<MoveMadeEventArgs> moveMadeHandler = (sender, e) =>
            {
                ScenarioContextUtils.SetMoveMadeEventArgs(e);
                SetMoveMadeMessage(e);
            };
            EventHandler<GameOverEventArgs> gameOverHandler = (sender, e) =>
            {
                ScenarioContextUtils.SetGameOverEventArgs(e);
                SetGameOverMessage(e);
            };

            chessBoard.PieceTaken += pieceTakenHandler;
            chessBoard.MoveMade += moveMadeHandler;
            chessBoard.GameOver += gameOverHandler;

            try {
                chessBoard.MakeMove(blackKnight.BoardPosition, new BoardPosition(boardPosition));
            }
            catch (ChessBoardException ex) {
                ScenarioContextUtils.SetChessBoardException(ex);
                SetChessBoardExceptionMessage(ex);
            }

            chessBoard.PieceTaken -= pieceTakenHandler;
            chessBoard.MoveMade -= moveMadeHandler;
            chessBoard.GameOver -= gameOverHandler;
        }

        [Given(@"the Pawn moves to ([A-Z][0-9])")]
        [When(@"the Pawn moves to ([A-Z][0-9])")]
        [Given(@"I move the Pawn to ([A-Z][0-9])")]
        [When(@"I move the Pawn to ([A-Z][0-9])")]
        public void IMoveThePawnTo(string boardPosition)
        {
            var chessBoard = ScenarioContextUtils.GetChessBoard();
            var whitePawn = ScenarioContextUtils.GetWhitePawn();

            EventHandler<PieceTakenEventArgs> pieceTakenHandler = (sender, e) =>
            {
                ScenarioContextUtils.SetPieceTakenEventArgs(e);
            };
            EventHandler<MoveMadeEventArgs> moveMadeHandler = (sender, e) =>
            {
                ScenarioContextUtils.SetMoveMadeEventArgs(e);
                SetMoveMadeMessage(e);
            };
            EventHandler<GameOverEventArgs> gameOverHandler = (sender, e) =>
            {
                ScenarioContextUtils.SetGameOverEventArgs(e);
                SetGameOverMessage(e);
            };

            chessBoard.PieceTaken += pieceTakenHandler;
            chessBoard.MoveMade += moveMadeHandler;
            chessBoard.GameOver += gameOverHandler;

            try {
                chessBoard.MakeMove(whitePawn.BoardPosition, new BoardPosition(boardPosition));
            }
            catch (ChessBoardException ex) {
                ScenarioContextUtils.SetChessBoardException(ex);
                SetChessBoardExceptionMessage(ex);
            }

            chessBoard.PieceTaken -= pieceTakenHandler;
            chessBoard.MoveMade -= moveMadeHandler;
            chessBoard.GameOver -= gameOverHandler;
        }

        [Given(@"the valid moves are")]
        public void TheValidMovesAre(Table table)
        {
        }

        [Given(@"the valid moves are ([A-Z][0-9])")]
        public void TheValidMovesAre(string boardPosition)
        {
        }

        [Then(@"Knight should be at ([A-Z][0-9])")]
        [Then(@"the Knight should be at ([A-Z][0-9])")]
        public void TheKnightShouldBeAt(string boardPosition)
        {
            var chessBoard = ScenarioContextUtils.GetChessBoard();
            var chessPiece = chessBoard.GetSquare(boardPosition).ChessPiece;

            Assert.That(chessPiece, Is.Not.Null);
            Assert.That(chessPiece, Is.InstanceOf<Knight>());
            Assert.That(chessPiece.Colour, Is.EqualTo(Colour.Black));
        }

        [Then(@"Pawn should be at ([A-Z][0-9])")]
        [Then(@"the Pawn should be at ([A-Z][0-9])")]
        public void ThePawnShouldBeAt(string boardPosition)
        {
            var chessBoard = ScenarioContextUtils.GetChessBoard();
            var chessPiece = chessBoard.GetSquare(boardPosition).ChessPiece;

            Assert.That(chessPiece, Is.Not.Null);
            Assert.That(chessPiece, Is.InstanceOf<Pawn>());
            Assert.That(chessPiece.Colour, Is.EqualTo(Colour.White));
        }

        [Then(@"the Knight should be taken")]
        public void TheKnightShouldBeTaken()
        {
            try {
                var pieceTakenEventArgs = ScenarioContextUtils.GetPieceTakenEventArgs();
                Assert.That(pieceTakenEventArgs.PieceTaken, Is.InstanceOf<Knight>());
                Assert.That(pieceTakenEventArgs.PieceTaken.Colour, Is.EqualTo(Colour.Black));
            }
            catch (KeyNotFoundException) {
                Assert.Fail("Expected a PieceTaken event to be raised!");
            }
        }

        [Then(@"the Pawn should be taken")]
        public void ThePawnShouldBeTaken()
        {
            try {
                var pieceTakenEventArgs = ScenarioContextUtils.GetPieceTakenEventArgs();
                Assert.That(pieceTakenEventArgs.PieceTaken, Is.InstanceOf<Pawn>());
                Assert.That(pieceTakenEventArgs.PieceTaken.Colour, Is.EqualTo(Colour.White));
            }
            catch (KeyNotFoundException) {
                Assert.Fail("Expected a PieceTaken event to be raised!");
            }
        }

        [Then(@"I should be warned of an illegal move message")]
        public void IShouldBeWarnedOfAnIllegalMoveMessage()
        {
            IShouldBeShown("illegal move");
        }

        [Then(@"I should be shown ""(.*)""")]
        public void IShouldBeShown(string message)
        {
            try {
                string message1 = ScenarioContextUtils.GetChessBoardMessage();
                string message2 = ScenarioContextUtils.GetChessBoardMessageDetail();
                Assert.That(message == message1 || message == message2);
            }
            catch (KeyNotFoundException) {
                Assert.Fail("Expected a message to have been set!");
            }
        }

        // If we were testing against a real GUI instead of just a domain model,
        // the GUI might handle events/exceptions and update a UI element such as
        // a status bar to display a message. We mimic that here by storing a message
        // in the ScenarioContext.
        private void SetGameOverMessage(GameOverEventArgs e)
        {
            switch (e.Result) {

                case GameResult.BlackWin:
                    ScenarioContextUtils.SetChessBoardMessage(BLACK_KNIGHT_WINS_MESSAGE);
                    break;

                case GameResult.WhiteWin:
                    ScenarioContextUtils.SetChessBoardMessage(WHITE_PAWN_WINS_MESSAGE);
                    break;

                case GameResult.Draw:
                    ScenarioContextUtils.SetChessBoardMessage(COLLISION_DRAW_MESSAGE);
                    break;
            }
        }

        // If we were testing against a real GUI instead of just a domain model,
        // the GUI might handle events/exceptions and update a UI element such as
        // a status bar to display a message. We mimic that here by storing a message
        // in the ScenarioContext.
        private void SetMoveMadeMessage(MoveMadeEventArgs e)
        {
            string message = string.Format("{0} to {1}", e.ChessPiece.Name, e.To.Name);
            ScenarioContextUtils.SetChessBoardMessage(message);
        }

        // If we were testing against a real GUI instead of just a domain model,
        // the GUI might handle events/exceptions and update a UI element such as
        // a status bar to display a message. We mimic that here by storing a message
        // in the ScenarioContext.
        private void SetChessBoardExceptionMessage(ChessBoardException ex)
        {
            string message = null;
            string messageDetail = null;

            switch (ex.ExceptionReason) {

                case ExceptionReason.IllegalMove:
                    message = ILLEGAL_MOVE_EXCEPTION_MESSAGE;
                    switch (ex.ExceptionReasonDetail) {
                        case ExceptionReasonDetail.PawnCannotMoveTwoSpacesAtThisTime:
                            messageDetail = ILLEGAL_PAWN_MOVE_DETAIL_TWO_SPACES;
                            break;
                        case ExceptionReasonDetail.PawnCannotMoveDiagonallyUnlessCapturing:
                            messageDetail = ILLEGAL_PAWN_MOVE_DETAIL_DIAGONAL;
                            break;
                    }
                    break;

                case ExceptionReason.InvalidBoardPosition:
                    message = ILLEGAL_MOVE_EXCEPTION_MESSAGE;
                    break;
            }

            if (message != null) {
                ScenarioContextUtils.SetChessBoardMessage(message);
            }

            if (messageDetail != null) {
                ScenarioContextUtils.SetChessBoardMessageDetail(messageDetail);
            }
        }
    }
}
