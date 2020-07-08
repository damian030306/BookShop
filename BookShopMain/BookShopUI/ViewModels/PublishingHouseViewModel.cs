using BookShopUI.Helpers;
using BookShopUI.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopUI.ViewModels
{
    public class PublishingHouseViewModel : Screen
    {
        IPublishingHouseEndPoint _publishingHouseEndPoint;
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _window;
        public PublishingHouseViewModel(IPublishingHouseEndPoint publishingHouseEndPoint, 
            StatusInfoViewModel status, IWindowManager window)
        {
            _publishingHouseEndPoint = publishingHouseEndPoint;
            _status = status;
            _window = window;

        }
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            try
            {
                await LoadPublishingHouse();
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
                TryClose();

            }
        }
        public async Task LoadPublishingHouse()
        {
            var authorList = await _publishingHouseEndPoint.GetAll();
            PublishingHouses = new BindingList<PublishingHouse>(authorList);
        }
        private BindingList<PublishingHouse> _authors;
        public BindingList<PublishingHouse> PublishingHouses
        {
            get { return _authors; }
            set
            {
                _authors = value;
                NotifyOfPropertyChange(() => PublishingHouses);
            }
        }

    }
}
