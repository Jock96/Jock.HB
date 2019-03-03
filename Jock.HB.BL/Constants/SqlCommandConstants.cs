namespace Jock.HB.BL.Constants
{
    /// <summary>
    /// Команды для SQL Server.
    /// </summary>
    public class SqlCommandConstants
    {
        /// <summary>
        /// Комманда выбора всех значений о пользователях.
        /// </summary>
        public const string SELECT_ALL_USERS_COMMAND = "SELECT * FROM Users";

        /// <summary>
        /// Команда добавления нового пользователя в базу данных.
        /// </summary>
        public const string INSERT_NEW_USER =
            "INSERT INTO Users (UserName, UserMail, UserPassword) " +
            "VALUES (@user, @mail, @password)";

        /// <summary>
        /// Имя базы данных пользователей.
        /// </summary>
        public const string USERS_DATA_BASE_NAME = "Users";

        /// <summary>
        /// Комманда выбора всех значений об отелях.
        /// </summary>
        public const string SELECT_ALL_HOTELS_COMMAND = "SELECT * FROM Hotels";

        /// <summary>
        /// Имя базы данных отелей.
        /// </summary>
        public const string HOTELS_DATA_BASE_NAME = "Hotels";
    }
}
