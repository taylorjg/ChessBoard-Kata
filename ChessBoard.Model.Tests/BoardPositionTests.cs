using System;
using NUnit.Framework;

namespace Chess.Model.Tests
{
    [TestFixture]
    public class BoardPositionTests
    {
        [Test]
        public void Constructor_GivenFileARank1_Succeeds()
        {
            BoardPosition boardPosition = new BoardPosition('A', 1);

            Assert.That(boardPosition.File, Is.EqualTo('A'));
            Assert.That(boardPosition.Rank, Is.EqualTo(1));
            Assert.That(boardPosition.InternalFile, Is.EqualTo(0));
            Assert.That(boardPosition.InternalRank, Is.EqualTo(0));
            Assert.That(boardPosition.Name, Is.EqualTo("A1"));
        }

        [Test]
        public void Constructor_GivenFileaRank1_Succeeds()
        {
            BoardPosition boardPosition = new BoardPosition('a', 1);

            Assert.That(boardPosition.File, Is.EqualTo('a'));
            Assert.That(boardPosition.Rank, Is.EqualTo(1));
            Assert.That(boardPosition.InternalFile, Is.EqualTo(0));
            Assert.That(boardPosition.InternalRank, Is.EqualTo(0));
            Assert.That(boardPosition.Name, Is.EqualTo("a1"));
        }

        [Test]
        public void Constructor_GivenInternalFileAndRank_Succeeds()
        {
            BoardPosition boardPosition = new BoardPosition(0, 0);

            Assert.That(boardPosition.File, Is.EqualTo('A'));
            Assert.That(boardPosition.Rank, Is.EqualTo(1));
            Assert.That(boardPosition.InternalFile, Is.EqualTo(0));
            Assert.That(boardPosition.InternalRank, Is.EqualTo(0));
            Assert.That(boardPosition.Name, Is.EqualTo("A1"));
        }

        [Test]
        public void Constructor_GivenFileIRank1_ThrowsException()
        {
            try {
                BoardPosition boardPosition = new BoardPosition('I', 1);
                Assert.Fail("Expected a ChessBoardException to be thrown!");
            }
            catch (ChessBoardException ex) {
                Assert.That(ex.ExceptionReason, Is.EqualTo(ExceptionReason.InvalidBoardPosition));
            }
        }

        [Test]
        public void Constructor_GivenFileARank0_ThrowsException()
        {
            try {
                BoardPosition boardPosition = new BoardPosition('A', 0);
                Assert.Fail("Expected a ChessBoardException to be thrown!");
            }
            catch (ChessBoardException ex) {
                Assert.That(ex.ExceptionReason, Is.EqualTo(ExceptionReason.InvalidBoardPosition));
            }
        }

        [Test]
        public void Constructor_GivenFileARank9_ThrowsException()
        {
            try {
                BoardPosition boardPosition = new BoardPosition('A', 9);
                Assert.Fail("Expected a ChessBoardException to be thrown!");
            }
            catch (ChessBoardException ex) {
                Assert.That(ex.ExceptionReason, Is.EqualTo(ExceptionReason.InvalidBoardPosition));
            }
        }

        [Test]
        public void Constructor_GivenInternalFileMinusOne_ThrowsException()
        {
            try {
                BoardPosition boardPosition = new BoardPosition(-1, 0);
                Assert.Fail("Expected a ChessBoardException to be thrown!");
            }
            catch (ChessBoardException ex) {
                Assert.That(ex.ExceptionReason, Is.EqualTo(ExceptionReason.InvalidBoardPosition));
            }
        }

        [Test]
        public void Constructor_GivenInternalFile8_ThrowsException()
        {
            try {
                BoardPosition boardPosition = new BoardPosition(8, 0);
                Assert.Fail("Expected a ChessBoardException to be thrown!");
            }
            catch (ChessBoardException ex) {
                Assert.That(ex.ExceptionReason, Is.EqualTo(ExceptionReason.InvalidBoardPosition));
            }
        }

        [Test]
        public void Constructor_GivenInternalRankMinusOne_ThrowsException()
        {
            try {
                BoardPosition boardPosition = new BoardPosition(0, -1);
                Assert.Fail("Expected a ChessBoardException to be thrown!");
            }
            catch (ChessBoardException ex) {
                Assert.That(ex.ExceptionReason, Is.EqualTo(ExceptionReason.InvalidBoardPosition));
            }
        }

        [Test]
        public void Constructor_GivenInternalRank8_ThrowsException()
        {
            try {
                BoardPosition boardPosition = new BoardPosition(0, 8);
                Assert.Fail("Expected a ChessBoardException to be thrown!");
            }
            catch (ChessBoardException ex) {
                Assert.That(ex.ExceptionReason, Is.EqualTo(ExceptionReason.InvalidBoardPosition));
            }
        }

        [Test]
        public void Constructor_GivenNameA1_Succeeds()
        {
            BoardPosition boardPosition = new BoardPosition("A1");

            Assert.That(boardPosition.File, Is.EqualTo('A'));
            Assert.That(boardPosition.Rank, Is.EqualTo(1));
            Assert.That(boardPosition.InternalFile, Is.EqualTo(0));
            Assert.That(boardPosition.InternalRank, Is.EqualTo(0));
            Assert.That(boardPosition.Name, Is.EqualTo("A1"));
        }

        [Test]
        public void Constructor_GivenNameI1_ThrowsException()
        {
            try {
                BoardPosition boardPosition = new BoardPosition("I1");
                Assert.Fail("Expected a ChessBoardException to be thrown!");
            }
            catch (ChessBoardException ex) {
                Assert.That(ex.ExceptionReason, Is.EqualTo(ExceptionReason.InvalidBoardPosition));
            }
        }

        [Test]
        public void Constructor_GivenNameA9_ThrowsException()
        {
            try {
                BoardPosition boardPosition = new BoardPosition("A9");
                Assert.Fail("Expected a ChessBoardException to be thrown!");
            }
            catch (ChessBoardException ex) {
                Assert.That(ex.ExceptionReason, Is.EqualTo(ExceptionReason.InvalidBoardPosition));
            }
        }

        [Test]
        public void ImplicitOperator_GivenNameA1_Succeeds()
        {
            BoardPosition boardPosition = "A1";

            Assert.That(boardPosition.File, Is.EqualTo('A'));
            Assert.That(boardPosition.Rank, Is.EqualTo(1));
            Assert.That(boardPosition.InternalFile, Is.EqualTo(0));
            Assert.That(boardPosition.InternalRank, Is.EqualTo(0));
            Assert.That(boardPosition.Name, Is.EqualTo("A1"));
        }

        [Test]
        public void ImplicitOperator_GivenNameI1_ThrowsException()
        {
            try {
                BoardPosition boardPosition = "I1";
                Assert.Fail("Expected a ChessBoardException to be thrown!");
            }
            catch (ChessBoardException ex) {
                Assert.That(ex.ExceptionReason, Is.EqualTo(ExceptionReason.InvalidBoardPosition));
            }
        }
    }
}
