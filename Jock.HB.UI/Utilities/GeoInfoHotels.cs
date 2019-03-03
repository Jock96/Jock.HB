using Esri.ArcGISRuntime.Geometry;
using Jock.HB.BL.Utilities;

namespace Jock.HB.UI.Utilities
{
    /// <summary>
    /// Класс сравнения координат по названию отеля из базы.
    /// </summary>
    public class GeoInfoHotels
    {
        #region Захардкоженный список отелей.

        private const string ELEGANT_HOTEL = "Elegant Hotel";

        private const string MAGISTRAT = "Магистрат";

        private const string BON_APART = "Bon Apart";

        private const string GOGOL_HOTEL = "Gogol Hotel";

        #endregion

        /// <summary>
        /// Гео-координаты по названию отеля.
        /// </summary>
        /// <param name="hotelName">Имя отеля.</param>
        /// <returns>Возвращает гео-координаты по названию отеля.</returns>
        public MapPoint GetHotelMapPoint(string hotelName)
        {
            var spatialReference = SpatialReferences.Wgs84;

            switch (hotelName)
            {
                case ELEGANT_HOTEL:
                    return new MapPoint(84.97903079, 56.45326321, spatialReference);

                case MAGISTRAT:
                    return new MapPoint(84.95010585, 56.48858029, spatialReference);

                case BON_APART:
                    return new MapPoint(84.95236695, 56.47164736, spatialReference);

                case GOGOL_HOTEL:
                    return new MapPoint(84.9619934, 56.47512581, spatialReference);

                default:
                    return null;
            }
        }
    }
}
