namespace Jock.HB.UI.Commands.WorkSpaceCommands
{
    using Jock.HB.UI.ViewModels;
    using Jock.HB.UI.Utilities;

    using Esri.ArcGISRuntime.Mapping;

    /// <summary>
    /// Команда изменения элементов при выборе отеля.
    /// </summary>
    public class ChangeComboBoxCommand : TypedCommand<WorkSpaceVM>
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
            var hotelsFromDataBase = workSpaceVM.HotelDataBaseWorker.GetHotels();
            var choosenHotel = workSpaceVM.ChoosenHotel;

            var map = workSpaceVM.Map;
            var geoInfoHotels = new GeoInfoHotels();

            foreach(var hotel in hotelsFromDataBase)
            {
                if(choosenHotel == hotel.Name)
                {
                    workSpaceVM.HotelName = hotel.Name;
                    workSpaceVM.HotelInfo = hotel.Info;

                    workSpaceVM.HotelPrice = hotel.Price;
                    workSpaceVM.HotelStars = hotel.Stars;

                    workSpaceVM.HotelRooms = hotel.Rooms;
                    workSpaceVM.Scale = 5000;

                    workSpaceVM.HotelMapPoint = geoInfoHotels.GetHotelMapPoint(hotel.Name);

                    break;
                }
            }
        }
    }
}
