namespace Jock.HB.UI.ViewModels
{
    using Jock.HB.UI.Commands.WorkSpaceCommands;
    using Jock.HB.BL.Utilities;

    using System;
    using System.Windows;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Esri.ArcGISRuntime.Mapping;
    using Esri.ArcGISRuntime.Geometry;


    /// <summary>
    /// Вью-модель рабочего пространства.
    /// </summary>
    public class WorkSpaceVM : BaseVM
    {
        /// <summary>
        /// Вью-модель рабочего пространства.
        /// </summary>
        public WorkSpaceVM(HotelDataBaseWorker hotelDataBaseWorker)
        {
            ToBookHotelCommand = new ToBookHotelCommand();
            ChangeComboBoxCommand = new ChangeComboBoxCommand();

            HotelDataBaseWorker = hotelDataBaseWorker;

            Hotels = FillHotels();
            HotelMapPoint = new MapPoint(84.96620178, 56.48183291, SpatialReferences.Wgs84);
        }

        /// <summary>
        /// Почта пользователя.
        /// </summary>
        private string _userMail { get; set; }

        /// <summary>
        /// Почта пользователя.
        /// </summary>
        public string UserMail
        {
            get => _userMail;
            set
            {
                _userMail = value;
                OnPropertyChanged();
            }
        }

        public HotelDataBaseWorker HotelDataBaseWorker { get; set; }

        /// <summary>
        /// Команда бронирования отеля.
        /// </summary>
        public ToBookHotelCommand ToBookHotelCommand { get; set; }

        /// <summary>
        /// Видимость элемента.
        /// </summary>
        private Visibility _visibility { get; set; } = Visibility.Hidden;

        /// <summary>
        /// Видимость элемента.
        /// </summary>
        public Visibility Visibility
        {
            get => _visibility;
            set
            {
                _visibility = value;
                OnPropertyChanged();
            }
        }

        #region Работа с информацией об отелях.

        /// <summary>
        /// Команда обновления информации по отелю.
        /// </summary>
        public ChangeComboBoxCommand ChangeComboBoxCommand { get; set; }

        /// <summary>
        /// Выбранный отель.
        /// </summary>
        private string _choosenHotel { get; set; }

        /// <summary>
        /// Выбранный отель.
        /// </summary>
        public string ChoosenHotel
        {
            get => _choosenHotel;
            set
            {
                _choosenHotel = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Вывод списка отелей из базы данных.
        /// </summary>
        /// <returns>Возвращает список отелей.</returns>
        private List<string> FillHotels()
        {
            var hotels = HotelDataBaseWorker.GetHotels();
            var hotelsList = new List<string>();

            foreach (var hotel in hotels)
            {
                hotelsList.Add(hotel.Name);
            }

            return hotelsList;
        }


        #endregion

        #region Информация об отелях.

        /// <summary>
        /// Список отелей.
        /// </summary>
        private List<string> _hotels { get; set; }

        /// <summary>
        /// Список отелей.
        /// </summary>
        public List<string> Hotels
        {
            get => _hotels;
            set
            {
                _hotels = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Имя отеля.
        /// </summary>
        private string _hotelName { get; set; }

        /// <summary>
        /// Имя отеля.
        /// </summary>
        public string HotelName
        {
            get => _hotelName;
            set
            {
                _hotelName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Количество звёзд отеля.
        /// </summary>
        private int _hotelStars { get; set; }

        /// <summary>
        /// Количество звёзд отеля.
        /// </summary>
        public int HotelStars
        {
            get => _hotelStars;
            set
            {
                _hotelStars = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Стоимость бронирования номера.
        /// </summary>
        private int _hotelPrice { get; set; }

        /// <summary>
        /// Стоимость бронирования номера.
        /// </summary>
        public int HotelPrice
        {
            get => _hotelPrice;
            set
            {
                _hotelPrice = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Количество свободных мест.
        /// </summary>
        private int _hotelRooms { get; set; }

        /// <summary>
        /// Количество свободных мест.
        /// </summary>
        public int HotelRooms
        {
            get => _hotelRooms;
            set
            {
                _hotelRooms = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Контактная информация.
        /// </summary>
        private string _hotelInfo { get; set; }

        /// <summary>
        /// Контактная информация.
        /// </summary>
        public string HotelInfo
        {
            get => _hotelInfo;
            set
            {
                _hotelInfo = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Работа с картой.

        /// <summary>
        /// Карта.
        /// </summary>
        private Map _map { get; set; }

        /// <summary>
        /// Карта.
        /// </summary>
        public Map Map
        {
            get => _map;
            set
            {
                _map = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Масштаб карты.
        /// </summary>
        private double _scale { get; set; } = 500000;

        /// <summary>
        /// Масштаб карты.
        /// </summary>
        public double Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Точка геолокации отеля на карте.
        /// </summary>
        private MapPoint _hotelMapPoint { get; set; }

        /// <summary>
        /// Точка геолокации отеля на карте.
        /// </summary>
        public MapPoint HotelMapPoint
        {
            get => _hotelMapPoint;
            set
            {
                _hotelMapPoint = value;
                OnPropertyChanged();
                Task.Run(async () => Map = await LoadWebMap(HotelMapPoint, Scale));
            }
        }

        /// <summary>
        /// Асинхронная загрузка карты.
        /// </summary>
        /// <returns>Возвращает карту.</returns>
        public async Task<Map> LoadWebMap(MapPoint MapPoint, double scale)
        {
            var itemId = "5b3c7166bbb14482b8a7f9201c452cad";
            var webMapUrl = string.Format("https://www.arcgisonline.com/sharing/rest/content/items/{0}/data", itemId);

            var webMap = new Map(new Uri(webMapUrl))
            {
                InitialViewpoint = new Viewpoint(MapPoint, scale)
            };

            return webMap;
        }

        #endregion
    }
}
