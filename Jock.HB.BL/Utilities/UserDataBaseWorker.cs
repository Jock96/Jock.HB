namespace Jock.HB.BL.Utilities
{
    using System;
    using System.Data.SqlClient;
    using System.Data;
    using System.Collections.Generic;
    using System.Data.Common;

    using Jock.HB.BL.Constants;
    using Jock.HB.BL.Models;

    /// <summary>
    /// Инструмент для работы с базой данных пользователей.
    /// </summary>
    public class UserDataBaseWorker
    {
        /// <summary>
        /// Строка подключения.
        /// </summary>
        private string _connectionString { get; set; }

        /// <summary>
        /// Набор методов для работы с базой данных.
        /// </summary>
        private DbProviderFactory _dbProviderFactory { get; set; }

        /// <summary>
        /// Подключение к базе данных.
        /// </summary>
        private SqlConnection _sqlConnection { get; set; }

        /// <summary>
        /// Инструмент для работы с базой данных.
        /// </summary>
        /// <param name="connectionString">Строка подключения.</param>
        public UserDataBaseWorker(string connectionString, DbProviderFactory dbProviderFactory)
        {
            _connectionString = connectionString;
            _dbProviderFactory = dbProviderFactory;

            _sqlConnection = StartConnection();
        }

        #region Подключение к базе данных.

        /// <summary>
        /// Попытка установить соединение.
        /// </summary>
        private SqlConnection StartConnection()
        {
            try
            {
                var connection = new SqlConnection(_connectionString);

                if (connection == null)
                    throw new Exception();

                return connection;
            }
            catch (Exception exception)
            {
                MessageBoxer.Error($"Не удалось установить соединение с базой данных " +
                    $"{SqlCommandConstants.USERS_DATA_BASE_NAME}.\n{exception.ToString()}");
                MessageBoxer.Info("Соединение не установленно.\nПриложение будет закрыто.");
                Environment.Exit(0);

                return null;
            }
        }

        /// <summary>
        /// Обновлет значения из базы данных.
        /// </summary>
        /// <param name="sqlCommand">Команда SQL.</param>
        /// <returns>Возвращает выполненную команду.</returns>
        public int Update(string sqlCommand)
        {
            using (DbConnection connection = _dbProviderFactory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (DbCommand command = _dbProviderFactory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sqlCommand;

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Получает таблицу данных.
        /// </summary>
        /// <param name="sqlCommand">Команда SQL.</param>
        /// <returns>Взвращает таблицу данных.</returns>
        private DataTable GetDataTable(string sqlCommand)
        {
            using (DbConnection connection = _dbProviderFactory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (DbCommand command = _dbProviderFactory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = sqlCommand;

                    using (DbDataAdapter adapter = _dbProviderFactory.CreateDataAdapter())
                    {
                        adapter.SelectCommand = command;

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        return dt;
                    }
                }
            }
        }

        #endregion

        #region Работа с пользователями.

        /// <summary>
        /// Добавление нового пользователя в БД.
        /// </summary>
        /// <param name="name">Имя пользователя.</param>
        /// <param name="mail">Почта пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        public bool AddUser(string name, string mail, string password)
        {
            try
            {
                _sqlConnection.Open();

                var command = new SqlCommand(SqlCommandConstants.INSERT_NEW_USER, _sqlConnection);

                var parameterUser = new SqlParameter
                {
                    ParameterName = "@user",
                    Value = name,
                    SqlDbType = SqlDbType.NVarChar
                };

                var parameterMail = new SqlParameter
                {
                    ParameterName = "@mail",
                    Value = mail,
                    SqlDbType = SqlDbType.NVarChar
                };

                var parameterPassword = new SqlParameter
                {
                    ParameterName = "@password",
                    Value = password,
                    SqlDbType = SqlDbType.NVarChar
                };

                command.Parameters.Add(parameterUser);
                command.Parameters.Add(parameterMail);
                command.Parameters.Add(parameterPassword);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    MessageBoxer.Error($"Ошибка выполнения:\n{exception.ToString()}");

                    return false;
                }

                _sqlConnection.Close();
                _sqlConnection.Dispose();
            }
            catch (Exception exception)
            {
                MessageBoxer.Error($"Ошибка подключения:\n{exception.ToString()}");

                return false;
            }

            return true;
        }

        /// <summary>
        /// Получить пользователей.
        /// </summary>
        /// <returns>Возврашает список пользователей.</returns>
        public IList<UserModel> GetUsers()
        {
            var dataTable = GetDataTable(SqlCommandConstants.SELECT_ALL_USERS_COMMAND);

            return MakeUsers(dataTable);
        }

        /// <summary>
        /// Создание пользователей.
        /// </summary>
        /// <param name="dataTable">Строка данных из таблицы данных SQL.</param>
        /// <returns>Возвращает список пользователей.</returns>
        private IList<UserModel> MakeUsers(DataTable dataTable)
        {
            IList<UserModel> userList = new List<UserModel>();
            foreach (DataRow row in dataTable.Rows)
                userList.Add(MakeUsers(row));

            return userList;
        }

        /// <summary>
        /// Создание пользователей (перегрузка для каждого пользователя).
        /// </summary>
        /// <param name="row">Строка данных из таблицы данных SQL.</param>
        /// <returns>Возвращает пользователя.</returns>
        private UserModel MakeUsers(DataRow row)
        {
            int Id = int.Parse(row["id"].ToString());
            string Name = row["UserName"].ToString();
            string Password = row["UserPassword"].ToString();
            string Mail = row["UserMail"].ToString();

            return new UserModel(id: Id, name: Name, password: Password, mail: Mail);
        }

        #endregion
    }
}
