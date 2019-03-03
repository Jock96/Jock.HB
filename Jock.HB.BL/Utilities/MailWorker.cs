namespace Jock.HB.BL.Utilities
{
    using System.Net;
    using System.Net.Mail;

    using Jock.HB.BL.Constants;

    /// <summary>
    /// Инструмент отправки уведомлений на почту.
    /// </summary>
    public class MailWorker
    {
        /// <summary>
        /// Инструмент отправки уведомлений на почту.
        /// </summary>
        /// <param name="userMail">Почтовый адрес пользователя.</param>
        public MailWorker(string userMail, string hotelName, string hotelStars, string hotelPrice, string hotelInfo)
        {
            _userMail = userMail;
            _hotelName = hotelName;
            _hotelStars = hotelStars;
            _hotelPrice = hotelPrice;
            _hotelInfo = hotelInfo;
        }

        #region Информация по отправке письма.

        /// <summary>
        /// Информация об отеле.
        /// </summary>
        private string _hotelInfo { get; set; }

        /// <summary>
        /// Цена бронирования.
        /// </summary>
        private string _hotelPrice { get; set; }

        /// <summary>
        /// Количество звёзд в отеле.
        /// </summary>
        private string _hotelStars { get; set; }

        /// <summary>
        /// Имя отеля.
        /// </summary>
        private string _hotelName { get; set; }

        /// <summary>
        /// Почтовый адрес пользователя.
        /// </summary>
        private string _userMail { get; set; }

        #endregion

        /// <summary>
        /// Отправка письма на почту пользователя.
        /// </summary>
        public void SendMail()
        {
            MailAddress from = new MailAddress(MailConstants.SYSTEM_MAIL, 
                MailConstants.SYSTEM_NAME);

            MailAddress to = new MailAddress(_userMail);

            MailMessage mailMessage = new MailMessage(from,to)
            {
                From = new MailAddress(MailConstants.SYSTEM_MAIL),
                Subject = MailConstants.SYSTEM_MAIL_SUBJECT,

                Body = $"<p>Вами было забронировано место в отеле {_hotelName} c {_hotelStars} звёздами.</p>" +
                        $"<p>Стоимость бронирования: {_hotelPrice} рублей.</p>" +
                        $"<p>Дополнительная информация по номеру: {_hotelInfo}</p>",

                IsBodyHtml = true
            };

            SmtpClient smtpClient = new SmtpClient(MailConstants.SMTP_CLIENT, 587)
            {
                Credentials = new NetworkCredential(MailConstants.SYSTEM_MAIL, 
                MailConstants.SYSTEM_PASSWORD),

                EnableSsl = true
            };

            smtpClient.Send(mailMessage);
        }
    }
}
