namespace Jock.HB.BL.Models
{
    using System.Data.Linq.Mapping;

    /// <summary>
    /// Модель пользователя.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Модель пользователя.
        /// </summary>
        public UserModel(string name, string password, string mail, int id)
        {
            Id = id;
            Name = name;
            Password = password;
            Mail = mail;
        }

        /// <summary>
        /// ID пользователя.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Почта пользователя.
        /// </summary>
        public string Mail { get; set; }
    }
}
