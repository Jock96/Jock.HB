namespace Jock.HB.UI.Commands.WorkSpaceCommands
{
    using Jock.HB.UI.ViewModels;
    using Jock.HB.BL.Utilities;

    /// <summary>
    /// Команда бронирования отеля.
    /// </summary>
    public class ToBookHotelCommand : TypedCommand<WorkSpaceVM>
    {
        /// <summary>
        /// Флаг возможности выполнения.
        /// </summary>
        /// <param name="mainWindowVM">Вью-модель рабочего пространства.</param>
        /// <returns>Возвращает возможность выполнения.</returns>
        protected override bool CanExecute(WorkSpaceVM workSpaceVM)
        {
            return true;
        }

        /// <summary>
        /// Выполнение команды.
        /// </summary>
        /// <param name="workSpaceVM">Вью-модель рабочего пространства.</param>
        protected override void Execute(WorkSpaceVM workSpaceVM)
        {
            if (workSpaceVM.ChoosenHotel == "" || workSpaceVM.ChoosenHotel == null)
            {
                MessageBoxer.Info("Вы должны выбрать отель, чтобы его забронировать!");
                return;
            }

            try
            {
                var mailWorker = new MailWorker(workSpaceVM.UserMail,
                    workSpaceVM.ChoosenHotel,
                    workSpaceVM.HotelStars.ToString(),
                    workSpaceVM.HotelPrice.ToString(),
                    workSpaceVM.HotelInfo);

                mailWorker.SendMail();

                MessageBoxer.Info($"Место в отеле {workSpaceVM.ChoosenHotel} успешно забронировано!\n" +
                    $"На почту было отправлено письмо с данными регистрации.");
            }
            catch
            {
                MessageBoxer.Error($"Не удалось забронировать отель!" +
                    $"\nПричина:" +
                    $"\nНе удалось отправить письмо с уведомлением по адресу: {workSpaceVM.UserMail}!");
            }
        }
    }
}
