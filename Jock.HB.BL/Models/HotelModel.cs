namespace Jock.HB.BL.Models
{
    using System.Data.Linq.Mapping;

    /// <summary>
    /// Модель гостиницы.
    /// </summary>
    public class HotelModel
    {
        /// <summary>
        /// Модель гостиницы.
        /// </summary>
        public HotelModel(string name, string info, int stars, int price, int rooms, int id)
        {
            Name = name;
            Info = info;
            Stars = stars;
            Price = price;
            Rooms = rooms;
            Id = id;
        }

        /// <summary>
        /// ID в базе данных.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <summary>
        /// Имя отеля.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Информация об отеле.
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// Количество звёзд отеля.
        /// </summary>
        public int Stars { get; set; }

        /// <summary>
        /// Цена за номер.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Количество свободных комнат.
        /// </summary>
        public int Rooms { get; set; }
    }
}
