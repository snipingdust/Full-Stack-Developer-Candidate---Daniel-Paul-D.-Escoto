using System;

namespace BowlingGame.bowling.utils
{
    public class Constants
    {
        // Titles
        public const string ATTENTION_TITLE = "Attention";
        public const string CONFIRMATION_TITLE = "Confirmation";
        public const string ERROR_TITLE = "Error";

        // Messagebox
        public const string GAME_START_MESSAGE = "Game Start!";
        public const string INPUT_CORRECT_VALUE_MESSAGE = "Please input values between 1-9 X or / only";
        public const string STRIKE_UNAVAILABLE_MESSAGE = "Shot is open frame. Unable to input a strike.";
        public const string PLEASE_INPUT_NAME_MESSAGE = "Please input name.";
        public const string PLEASE_INPUT_FIELDS_MESSAGE = "Please input fields.";
        public const string WELCOME_MESSAGE = "Welcome, ";

        // Confirmation
        public const string NEW_GAME_CONFIRMATION = "Are you sure you want a new game? Any unsaved progress will be lost.";

        // Symbols
        public const string STRIKE = "X";
        public const string SPARE = "/";
        public const int STRIKE_VALUE = 10;
        public const string HYPHEN = "-";
        public const string ZERO = "0";
        public const string ONE = "1";
        public const string TWO = "2";
        public const string THREE = "3";
        public const string FOUR = "4";
        public const string FIVE = "5";
        public const string SIX = "6";
        public const string SEVEN = "7";
        public const string EIGHT = "8";
        public const string NINE = "9";
        public const string EXCLAMATION = "!";

        // Pic Box Settings
        public const string STRETCH = "Stretch";

        // DB Connection
        public const string WIN_PROCESSOR = "win32_processor";
        public const string PROCESSOR_ID = "processorID";
        public const string DB_DATASOURCE = "db.datasource";
        public const string DB_INITIAL_CATALOG = "db.initial.catalog";
        public const string DB_USER_ID = "db.user.id";
        public const string DB_PASSWORD = "db.password";
        public const string DB_MSG_ERROR = "Database Connectivity encountered an Error.";
        public const string USER_TYPE = "usertype";
        public const string USER_FIRST_NAME = "firstname";
        public const string USER_LAST_NAME = "lastname";

        // DB fields
        public const string BOWLING_GAME_ID = "bowling_game_id";
        public const string BOWLER_NAME = "bowler_name";
        public const string PINS_KNOCKED_DOWN = "pins_knocked_down";
        public const string BOWLER_ID = "bowler_id";

        // Program Data Folder
        public static string USER_DIR = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        public static string DB_PROPERTIES = USER_DIR + "\\BowlingGame\\DB\\dbBowlingGame.properties";

        // Data Grid View Column Headers
        public const string GAME_ID = "Game ID";
        public const string BOWLER = "Bowler";
        public const string SCORE = "Score";

    }
}
