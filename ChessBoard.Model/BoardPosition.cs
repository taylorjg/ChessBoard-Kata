using System;

namespace Chess.Model
{
    /// <summary>
    /// This class represents a position on a chess board.
    /// </summary>
    public class BoardPosition
    {
        /// <summary>
        /// Initialises a new instance of the BoardPosition class with the given vertical file and horizontal rank.
        /// </summary>
        /// <param name="file">Vertical file - 'A' through 'H'.</param>
        /// <param name="rank">Horizontal rank - 1 through 8.</param>
        public BoardPosition(char file, int rank)
        {
            if (!((file >= 'A' && file <= 'H') || (file >= 'a' && file <= 'h'))) {
                var ex = new ChessBoardException(ExceptionReason.InvalidBoardPosition);
                ex.Data.Add("File", file);
                throw ex;
            }

            if (!(rank >= 1 && rank <= 8)) {
                var ex = new ChessBoardException(ExceptionReason.InvalidBoardPosition);
                ex.Data.Add("Rank", rank);
                throw ex;
            }

            this.File = file;
            this.Rank = rank;
            this.InternalFile = (file >= 'A' && file <= 'H') ? file - 'A' : file - 'a';
            this.InternalRank = rank - 1;
        }

        /// <summary>
        /// Initialises a new instance of the BoardPosition class with the given vertical file and horizontal rank in algebraic notation.
        /// </summary>
        /// <param name="name">The board position in algebraic notation.</param>
        public BoardPosition(string name)
        {
            this.Name = name;
        }

        internal BoardPosition(int internalFile, int internalRank)
        {
            if (!(internalFile >= 0 && internalFile <= 7)) {
                var ex = new ChessBoardException(ExceptionReason.InvalidBoardPosition);
                ex.Data.Add("InternalFile", internalFile);
                throw ex;
            }

            if (!(internalRank >= 0 && internalRank <= 7)) {
                var ex = new ChessBoardException(ExceptionReason.InvalidBoardPosition);
                ex.Data.Add("InternalRank", internalRank);
                throw ex;
            }

            this.InternalFile = internalFile;
            this.InternalRank = internalRank;
            this.File = (char)('A' + (char)internalFile);
            this.Rank = internalRank + 1;
        }

        /// <summary>
        /// Implicit conversion operator that converts a string in algebraic notation to an instance of the BoardPosition class.
        /// </summary>
        /// <param name="name">The board position in algebraic notation.</param>
        /// <returns>An instance of the BoardPosition class</returns>
        public static implicit operator BoardPosition(string name)
        {
            return new BoardPosition(name);
        }

        /// <summary>
        /// The vertical file labelled 'a' through 'h'.
        /// </summary>
        public char File { get; private set; }

        /// <summary>
        /// The horizontal rank numbered 1 through 8.
        /// </summary>
        public int Rank { get; private set; }

        /// <summary>
        /// The vertical file as a zero-based index form 0 to 7.
        /// </summary>
        internal int InternalFile { get; private set; }

        /// <summary>
        /// The horizontal rank as a zero-based index from 0 to 7.
        /// </summary>
        internal int InternalRank { get; private set; }

        /// <summary>
        /// The name of a board position consisting of its file and rank.
        /// </summary>
        public string Name
        {
            get
            {
                return string.Format("{0}{1}", File, Rank);
            }
            set
            {
                Parse(value);
            }
        }

        /// <summary>
        /// Compare 'this' to 'rhs'. The two instances of BoardPosition are the same if they represent the same board position.
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns>true if 'rhs' represents the same board position as 'this' else false.</returns>
        public override bool Equals(object rhs)
        {
            if (rhs == null)
                return false;

            if (object.ReferenceEquals(this, rhs))
                return true;

            if (this.GetType() != rhs.GetType())
                return false;

            return CompareFields(rhs as BoardPosition);
        }

        private bool CompareFields(BoardPosition rhs)
        {
            return (this.InternalFile == rhs.InternalFile &&
                    this.InternalRank == rhs.InternalRank);
        }

        /// <summary>
        /// Returns a hashcode for this instance (necessary because we override Equals).
        /// </summary>
        /// <returns>A hashcode for this instance.</returns>
        public override int GetHashCode()
        {
            // See the section "The calculated hash" in the following article :-
            // http://codeidol.com/csharp/csharpckbk2/Data-Structures-and-Algorithms/Creating-a-Hash-Code-for-a-Data-Type

            int hashCode = 7;

            hashCode = (hashCode * 31) + this.InternalFile;
            hashCode = (hashCode * 31) + this.InternalRank;

            return hashCode;
        }

        private void Parse(string name)
        {
            if (name.Length != 2) {
                var ex = new ChessBoardException(ExceptionReason.InvalidBoardPosition);
                ex.Data.Add("Name", name);
                throw ex;
            }

            char file = name[0];
            char rankChar = name[1];

            if (!((file >= 'A' && file <= 'H') || (file >= 'a' && file <= 'h'))) {
                var ex = new ChessBoardException(ExceptionReason.InvalidBoardPosition);
                ex.Data.Add("File", file);
                throw ex;
            }

            if (!(rankChar >= '1' && rankChar <= '8')) {
                var ex = new ChessBoardException(ExceptionReason.InvalidBoardPosition);
                ex.Data.Add("Rank", rankChar);
                throw ex;
            }

            int rank = rankChar - '0';

            this.File = file;
            this.Rank = rank;
            this.InternalFile = (file >= 'A' && file <= 'H') ? file - 'A' : file - 'a';
            this.InternalRank = rank - 1;
        }
    }
}
