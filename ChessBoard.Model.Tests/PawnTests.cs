using System;
using Chess.Model;
using NUnit.Framework;
using Rhino.Mocks;

namespace Chess.Model.Tests
{
    [TestFixture]
    public class PawnTests
    {
        private static Square SquareWithBlackKnight = new Square() { ChessPiece = new Knight(Colour.Black) };
        private static Square SquareWithWhitePawn = new Square() { ChessPiece = new Pawn(Colour.White) };
        private static Square EmptySquare = new Square();

        [Test]
        public void ValidateMove_PawnForward1Square_ReturnsValid()
        {
            var from = "C3";
            var to = "C4";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(EmptySquare);

            var whitePawn = new Pawn(Colour.White);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = whitePawn.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Valid));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.None));
        }

        [Test]
        public void ValidateMove_PawnBackward1Square_ReturnsIllegal()
        {
            var from = "C3";
            var to = "C2";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(EmptySquare);

            var whitePawn = new Pawn(Colour.White);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = whitePawn.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Illegal));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.None));
        }

        [Test]
        public void ValidateMove_PawnForward1SquareBlocked_ReturnsCollision()
        {
            var from = "C3";
            var to = "C4";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(SquareWithBlackKnight);

            var whitePawn = new Pawn(Colour.White);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = whitePawn.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Collision));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.None));
        }

        [Test]
        public void ValidateMove_PawnForward2SquaresRound1OnHomeRank_ReturnsValid()
        {
            var from = "C2";
            var inbetween = "C3";
            var to = "C4";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Round = 1;
            chessBoardStub.Stub(stub => stub.GetSquare(inbetween)).Return(EmptySquare);
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(EmptySquare);

            var whitePawn = new Pawn(Colour.White);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = whitePawn.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Valid));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.None));
        }

        [Test]
        public void ValidateMove_PawnForward2SquaresNotOnHomeRank_ReturnsIllegal()
        {
            var from = "C4";
            var inbetween = "C5";
            var to = "C6";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Round = 1;
            chessBoardStub.Stub(stub => stub.GetSquare(inbetween)).Return(EmptySquare);
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(EmptySquare);

            var whitePawn = new Pawn(Colour.White);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = whitePawn.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Illegal));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.PawnCannotMoveTwoSpacesAtThisTime));
        }

        [Test]
        public void ValidateMove_PawnForward2SquaresNotRound1_ReturnsIllegal()
        {
            var from = "C2";
            var inbetween = "C3";
            var to = "C4";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Round = 2;
            chessBoardStub.Stub(stub => stub.GetSquare(inbetween)).Return(EmptySquare);
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(EmptySquare);

            var whitePawn = new Pawn(Colour.White);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = whitePawn.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Illegal));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.PawnCannotMoveTwoSpacesAtThisTime));
        }

        [Test]
        public void ValidateMove_PawnForward2SquaresBlocked1Not2_ReturnsCollision()
        {
            var from = "C2";
            var inbetween = "C3";
            var to = "C4";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Round = 1;
            chessBoardStub.Stub(stub => stub.GetSquare(inbetween)).Return(SquareWithBlackKnight);
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(EmptySquare);

            var whitePawn = new Pawn(Colour.White);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = whitePawn.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Collision));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.None));
        }

        [Test]
        public void ValidateMove_PawnForward2SquaresBlocked1And2_ReturnsCollision()
        {
            var from = "C2";
            var inbetween = "C3";
            var to = "C4";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Round = 1;
            chessBoardStub.Stub(stub => stub.GetSquare(inbetween)).Return(SquareWithBlackKnight);
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(SquareWithBlackKnight);

            var whitePawn = new Pawn(Colour.White);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = whitePawn.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Collision));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.None));
        }

        [Test]
        public void ValidateMove_PawnForward2SquaresBlocked2Not1_ReturnsIllegal()
        {
            var from = "C2";
            var inbetween = "C3";
            var to = "C4";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Round = 1;
            chessBoardStub.Stub(stub => stub.GetSquare(inbetween)).Return(EmptySquare);
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(SquareWithBlackKnight);

            var whitePawn = new Pawn(Colour.White);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = whitePawn.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Illegal));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.None));
        }

        [Test]
        public void ValidateMove_PawnDiagonalCaptureLeftOfBlackPiece_ReturnsValid()
        {
            var from = "C2";
            var to = "B3";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(SquareWithBlackKnight);

            var whitePawn = new Pawn(Colour.White);
            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = whitePawn.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Valid));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.None));
        }

        [Test]
        public void ValidateMove_PawnDiagonalCaptureLeftOfWhitePiece_ReturnsIllegal()
        {
            var from = "C2";
            var to = "B3";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(SquareWithWhitePawn);

            var whitePawn = new Pawn(Colour.White);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = whitePawn.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Illegal));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.PawnCannotMoveDiagonallyUnlessCapturing));
        }

        [Test]
        public void ValidateMove_PawnDiagonalCaptureLeftOfNothing_ReturnsIllegal()
        {
            var from = "C2";
            var to = "B3";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(EmptySquare);

            var whitePawn = new Pawn(Colour.White);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = whitePawn.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Illegal));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.PawnCannotMoveDiagonallyUnlessCapturing));
        }

        [Test]
        public void ValidateMove_PawnDiagonalCaptureRightOfBlackPiece_ReturnsValid()
        {
            var from = "C2";
            var to = "D3";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(SquareWithBlackKnight);

            var whitePawn = new Pawn(Colour.White);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = whitePawn.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Valid));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.None));
        }

        [Test]
        public void ValidateMove_PawnDiagonalCaptureRightOfWhitePiece_ReturnsIllegal()
        {
            var from = "C2";
            var to = "D3";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(SquareWithWhitePawn);

            var whitePawn = new Pawn(Colour.White);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = whitePawn.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Illegal));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.PawnCannotMoveDiagonallyUnlessCapturing));
        }

        [Test]
        public void ValidateMove_PawnDiagonalCaptureRightOfNothing_ReturnsIllegal()
        {
            var from = "C2";
            var to = "D3";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(EmptySquare);

            var whitePawn = new Pawn(Colour.White);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = whitePawn.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Illegal));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.PawnCannotMoveDiagonallyUnlessCapturing));
        }
    }
}
