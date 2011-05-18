using System;
using System.Collections.Generic;
using Chess.Model;
using TechTalk.SpecFlow;

namespace AcceptanceTests
{
    public static class ScenarioContextUtils
    {
        public const string CHESSBOARD_KEY = "CHESSBOARD_KEY";
        public const string BLACK_KNIGHT_KEY = "BLACK_KNIGHT_KEY";
        public const string WHITE_PAWN_KEY = "WHITE_PAWN_KEY";
        public const string CHESSBOARD_EXCEPTION_KEY = "CHESSBOARD_EXCEPTION_KEY";
        public const string GAME_OVER_EVENTARGS_KEY = "GAME_OVER_EVENTARGS_KEY";
        public const string PIECE_TAKEN_EVENTARGS_KEY = "PIECE_TAKEN_EVENTARGS_KEY";
        public const string MOVE_MADE_EVENTARGS_KEY = "MOVE_MADE_EVENTARGS_KEY";
        public const string CHESSBOARD_MESSAGE_KEY = "CHESSBOARD_MESSAGE_KEY";
        public const string CHESSBOARD_MESSAGE_DETAIL_KEY = "CHESSBOARD_MESSAGE_DETAIL_KEY";

        public static ChessBoard GetChessBoard()
        {
            ChessBoard chessBoard = null;

            try {
                chessBoard = ScenarioContext.Current.Get<ChessBoard>(CHESSBOARD_KEY);
            }
            catch (KeyNotFoundException) {
            }

            if (chessBoard == null) {
                chessBoard = new ChessBoard();
                ScenarioContext.Current[CHESSBOARD_KEY] = chessBoard;
            }

            return chessBoard;
        }

        public static Knight GetBlackKnight()
        {
            return ScenarioContext.Current.Get<Knight>(BLACK_KNIGHT_KEY);
        }

        public static void SetBlackKnight(Knight blackKnight)
        {
            ScenarioContext.Current[BLACK_KNIGHT_KEY] = blackKnight;
        }

        public static Pawn GetWhitePawn()
        {
            return ScenarioContext.Current.Get<Pawn>(WHITE_PAWN_KEY);
        }

        public static void SetWhitePawn(Pawn whitePawn)
        {
            ScenarioContext.Current[WHITE_PAWN_KEY] = whitePawn;
        }

        public static ChessBoardException GetChessBoardException()
        {
            return ScenarioContext.Current.Get<ChessBoardException>(CHESSBOARD_EXCEPTION_KEY);
        }

        public static void SetChessBoardException(ChessBoardException ex)
        {
            ScenarioContext.Current[CHESSBOARD_EXCEPTION_KEY] = ex;
        }

        public static GameOverEventArgs GetGameOverEventArgs()
        {
            return ScenarioContext.Current.Get<GameOverEventArgs>(GAME_OVER_EVENTARGS_KEY);
        }

        public static void SetGameOverEventArgs(GameOverEventArgs e)
        {
            ScenarioContext.Current[GAME_OVER_EVENTARGS_KEY] = e;
        }

        public static PieceTakenEventArgs GetPieceTakenEventArgs()
        {
            return ScenarioContext.Current.Get<PieceTakenEventArgs>(PIECE_TAKEN_EVENTARGS_KEY);
        }

        public static void SetPieceTakenEventArgs(PieceTakenEventArgs e)
        {
            ScenarioContext.Current[PIECE_TAKEN_EVENTARGS_KEY] = e;
        }

        public static MoveMadeEventArgs GetMoveMadeEventArgs()
        {
            return ScenarioContext.Current.Get<MoveMadeEventArgs>(MOVE_MADE_EVENTARGS_KEY);
        }

        public static void SetMoveMadeEventArgs(MoveMadeEventArgs e)
        {
            ScenarioContext.Current[MOVE_MADE_EVENTARGS_KEY] = e;
        }

        public static string GetChessBoardMessage()
        {
            return ScenarioContext.Current.Get<string>(CHESSBOARD_MESSAGE_KEY);
        }

        public static void SetChessBoardMessage(string message)
        {
            ScenarioContext.Current[CHESSBOARD_MESSAGE_KEY] = message;
        }

        public static string GetChessBoardMessageDetail()
        {
            string messageDetail = string.Empty;

            try {
                messageDetail = ScenarioContext.Current.Get<string>(CHESSBOARD_MESSAGE_DETAIL_KEY);
            }
            catch (KeyNotFoundException) {
            }

            return messageDetail;
        }

        public static void SetChessBoardMessageDetail(string messageDetail)
        {
            ScenarioContext.Current[CHESSBOARD_MESSAGE_DETAIL_KEY] = messageDetail;
        }
    }
}
