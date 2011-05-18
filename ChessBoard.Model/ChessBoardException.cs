using System;

namespace Chess.Model
{
    /// <summary>
    /// Specifies the reason why an exception occurred.
    /// </summary>
    public enum ExceptionReason
    {
        FromSquareIsNotOccupied,
        IllegalMove,
        InitialPositionAlreadyOccupied,
        InvalidBoardPosition
    };

    /// <summary>
    /// Specifies additional details regarding the exception that has occurred.
    /// </summary>
    public enum ExceptionReasonDetail
    {
        None,
        PawnCannotMoveTwoSpacesAtThisTime,
        PawnCannotMoveDiagonallyUnlessCapturing
    };

    /// <summary>
    /// The exception that is thrown when an error occurs within the chess application.
    /// </summary>
    public class ChessBoardException : ApplicationException
    {
        public ChessBoardException(ExceptionReason exceptionReason)
            : this(exceptionReason, ExceptionReasonDetail.None, null)
        {
        }

        public ChessBoardException(ExceptionReason exceptionReason, ExceptionReasonDetail exceptionReasonDetail)
            : this(exceptionReason, exceptionReasonDetail, null)
        {
        }

        public ChessBoardException(ExceptionReason exceptionReason, Exception innerException)
            : this(exceptionReason, ExceptionReasonDetail.None, innerException)
        {
        }

        public ChessBoardException(ExceptionReason exceptionReason, ExceptionReasonDetail exceptionReasonDetail, Exception innerException)
            : base(MessageFromExceptionReason(exceptionReason), innerException)
        {
            this.ExceptionReason = exceptionReason;
            this.ExceptionReasonDetail = exceptionReasonDetail;
        }

        /// <summary>
        /// 
        /// </summary>
        public ExceptionReason ExceptionReason { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ExceptionReasonDetail ExceptionReasonDetail { get; private set; }

        private static string MessageFromExceptionReason(ExceptionReason exceptionReason)
        {
            // Get the name of the enum value.
            string exceptionReasonName = Enum.GetName(typeof(ExceptionReason), exceptionReason);

            // Try to find a string resource with this name.
            string message = Resources.ResourceManager.GetString(exceptionReasonName);

            // If we failed to find a string resource or the string is empty,
            // then use the name of the enum value instead.
            if (String.IsNullOrEmpty(message)) {
                message = exceptionReasonName;
            }

            return message;
        }
    }
}
