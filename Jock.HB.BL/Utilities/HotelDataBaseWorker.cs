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
    /// Инструмент для работы с базой данных отелей.
    /// </summary>
    public class HotelDataBaseWorker
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
        public HotelDataBaseWorker(string connectionString, DbProviderFactory dbProviderFactory)
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
                    $"{SqlCommandConstants.HOTELS_DATA_BASE_NAME}.\n{exception.ToString()}");
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

        #region Работа с данными гостиниц.

        /// <summary>
        /// Получить информацию об отелях.
        /// </summary>
        /// <returns>Возвращает список отелей.</returns>
        public IList<HotelModel> GetHotels()
        {
            var dataTable = GetDataTable(SqlCommandConstants.SELECT_ALL_HOTELS_COMMAND);

            return MakeHotels(dataTable);
        }

        /// <summary>
        /// Создание отелей.
        /// </summary>
        /// <param name="dataTable">Строка данных из таблицы данных SQL.</param>
        /// <returns>Возвращает список отелей.</returns>
        private IList<HotelModel> MakeHotels(DataTable dataTable)
        {
            IList<HotelModel> hotelsList = new List<HotelModel>();
            foreach (DataRow row in dataTable.Rows)
                hotelsList.Add(MakeHotels(row));

            return hotelsList;
        }

        /// <summary>
        /// Создание отелей (перегрузка для каждого отеля).
        /// </summary>
        /// <param name="row">Строка данных из таблицы данных SQL.</param>
        /// <returns>Возвращает отели.</returns>
        private HotelModel MakeHotels(DataRow row)
        {
            int Id = int.Parse(row["id"].ToString());
            string Name = row["hotelName"].ToString();
            int Stars = int.Parse(row["hotelStars"].ToString());
            int Price = int.Parse(row["hotelPrice"].ToString());
            int Rooms = int.Parse(row["hotelAvailableRooms"].ToString());
            string Info = row["hotelInfo"].ToString();

            return new HotelModel(name: Name, info: Info, stars: Stars, price: Price, rooms: Rooms, id: Id);
        }

        #endregion
    }
}
