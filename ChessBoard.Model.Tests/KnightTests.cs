using System;
using Chess.Model;
using NUnit.Framework;
using Rhino.Mocks;

namespace Chess.Model.Tests
{
    [TestFixture]
    public class KnightTests
    {
        private static Square SquareWithBlackKnight = new Square() { ChessPiece = new Knight(Colour.Black) };
        private static Square SquareWithWhitePawn = new Square() { ChessPiece = new Pawn(Colour.White) };
        private static Square EmptySquare = new Square();

        [Test]
        public void ValidateMove_Knight1Forward2Left_ReturnsValid()
        {
            var from = "C4";
            var to = "A5";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(EmptySquare);

            var blackKnight = new Knight(Colour.Black);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = blackKnight.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Valid));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.None));
        }

        [Test]
        public void ValidateMove_Knight1Forward2Right_ReturnsValid()
        {
            var from = "C4";
            var to = "E5";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(EmptySquare);

            var blackKnight = new Knight(Colour.Black);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = blackKnight.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Valid));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.None));
        }

        [Test]
        public void ValidateMove_Knight1Backward2Left_ReturnsValid()
        {
            var from = "C4";
            var to = "A3";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(EmptySquare);

            var blackKnight = new Knight(Colour.Black);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = blackKnight.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Valid));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.None));
        }

        [Test]
        public void ValidateMove_Knight1Backward2Right_ReturnsValid()
        {
            var from = "C4";
            var to = "E3";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(EmptySquare);

            var blackKnight = new Knight(Colour.Black);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = blackKnight.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Valid));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.None));
        }

        [Test]
        public void ValidateMove_Knight2Forward1Left_ReturnsValid()
        {
            var from = "C4";
            var to = "B6";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(EmptySquare);

            var blackKnight = new Knight(Colour.Black);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = blackKnight.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Valid));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.None));
        }

        [Test]
        public void ValidateMove_Knight2Forward1Right_ReturnsValid()
        {
            var from = "C4";
            var to = "D6";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(EmptySquare);

            var blackKnight = new Knight(Colour.Black);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = blackKnight.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Valid));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.None));
        }

        [Test]
        public void ValidateMove_Knight2Backward1Left_ReturnsValid()
        {
            var from = "C4";
            var to = "B2";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(EmptySquare);

            var blackKnight = new Knight(Colour.Black);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = blackKnight.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Valid));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.None));
        }

        [Test]
        public void ValidateMove_Knight2Backward1Right_ReturnsValid()
        {
            var from = "C4";
            var to = "D2";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(EmptySquare);

            var blackKnight = new Knight(Colour.Black);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = blackKnight.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Valid));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.None));
        }

        [Test]
        public void ValidateMove_KnightCaptureOfWhitePiece_ReturnsValid()
        {
            var from = "C4";
            var to = "D2";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(EmptySquare);

            var blackKnight = new Knight(Colour.Black);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = blackKnight.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Valid));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.None));
        }

        [Test]
        public void ValidateMove_KnightCaptureOfBlackPiece_ReturnsIllegal()
        {
            var from = "C4";
            var to = "D2";

            var chessBoardStub = MockRepository.GenerateStub<ChessBoard>();
            chessBoardStub.Stub(stub => stub.GetSquare(to)).Return(SquareWithBlackKnight);

            var blackKnight = new Knight(Colour.Black);

            ExceptionReasonDetail exceptionReasonDetail;
            MoveResult moveResult = blackKnight.ValidateMove(chessBoardStub, from, to, out exceptionReasonDetail);

            Assert.That(moveResult, Is.EqualTo(MoveResult.Illegal));
            Assert.That(exceptionReasonDetail, Is.EqualTo(ExceptionReasonDetail.None));
        }
    }
}
