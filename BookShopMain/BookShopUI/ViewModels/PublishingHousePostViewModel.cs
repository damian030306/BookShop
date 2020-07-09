using BookShopUI.Helpers;
using BookShopUI.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopUI.ViewModels
{
    class PublishingHousePostViewModel : Screen
    {
        IPublishingHousePostEndPoint _publishingHousePostEndPoint;
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _window;
        public PublishingHousePostViewModel(IPublishingHousePostEndPoint publishingHousePostEndPoint, StatusInfoViewModel status, IWindowManager window)
        {
            _publishingHousePostEndPoint = publishingHousePostEndPoint;
            _status = status;
            _window = window;

        }
    
        
        private string _name;
        private DateTime _openingDate;
        public string Name2
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name2);

            }
        }
        public DateTime OpeningDate
        {
            get { return _openingDate; }
            set
            {
                _openingDate = value;
                NotifyOfPropertyChange(() => OpeningDate);

            }
        }
        public async Task AddButton()
        {
            PublishingHouse publishingHouse = new PublishingHouse();
            publishingHouse.Name = Name2;
            publishingHouse.OpeningDate = OpeningDate;

            try
            {
                await _publishingHousePostEndPoint.PostAuthor(publishingHouse);
                _status.UpdateMessage("Dodano rekord", "Rekord został dodany do bazy danych");
                _window.ShowDialog(_status);
            }
            catch (Exception ex)
            {
                //
                if (ex.Message == "Unauthorized")
                {
                    _status.UpdateMessage("Brak dostępu", "Nie masz pozwolenia aby wejść w tą sekcje danych");
                    _window.ShowDialog(_status);
                }
                else
                {
                    _status.UpdateMessage("Błąd", ex.Message);
                    _window.ShowDialog(_status);
                }


            }
        }
    }
}
