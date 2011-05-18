using System;

namespace Chess.Model
{
    /// <summary>
    /// Class passed to handlers of events generated when the game is over.
    /// </summary>
    public class GameOverEventArgs : EventArgs
    {
        public GameOverEventArgs(GameResult result)
        {
            this.Result = result;
        }

        public GameResult Result { get; private set; }
    }
}
