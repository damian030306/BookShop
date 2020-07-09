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
    public class BookPostViewModel : Screen
    {
        IBookPostEndPoint _bookPostEndPoint;
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _window;
        public BookPostViewModel(IBookPostEndPoint bookPostEndPoint, StatusInfoViewModel status, IWindowManager window)
        {
            _bookPostEndPoint = bookPostEndPoint;
            _status = status;
            _window = window;

        }
        private int _id;
        private string _name;
        private string _description;
        private int _publishingHouseId;
        private int _authorId;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyOfPropertyChange(() => id);

            }
        }
        public string Name2
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name2);

            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);

            }
        }
        public int PublishingHouseId
        {
            get { return _publishingHouseId; }
            set
            {
                _publishingHouseId = value;
                NotifyOfPropertyChange(() => PublishingHouseId);

            }
        }
        public int AuthorId
        {
            get { return _authorId; }
            set
            {
                _authorId = value;
                NotifyOfPropertyChange(() => AuthorId);

            }
        }
        public async Task AddButton()
        {
            Book book = new Book();
            book.AuthorId = AuthorId;
            book.Description = Description;
            
            book.Name = Name2;
            book.PublishingHouseId = PublishingHouseId;
           

            try
            {
                await _bookPostEndPoint.PostBook(book);
                _status.UpdateMessage("Dodano rekord", "Rekord został dodany do bazy danych");
                _window.ShowDialog(_status);
            }
            catch (Exception ex)
            {
                //
                if (ex.Message == "Not Found")
                {
                    _status.UpdateMessage("Błędne dane", "Sprawdz czy id autora oraz id wydawnictwa istnieje");
                    _window.ShowDialog(_status);
                }
                else
                {
                    _status.UpdateMessage("Brak dostępu", "Nie masz pozwolenia aby wejść w tą sekcje danych");
                    _window.ShowDialog(_status);
                }
                

            }
        }
    }
}
