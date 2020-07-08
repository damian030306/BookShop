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
    public class BookViewModel : Screen
    {
        IBookEndPoint _bookEndPoint;
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _window;
        public BookViewModel(IBookEndPoint bookEndPoint,
            StatusInfoViewModel status, IWindowManager window)
        {
            _bookEndPoint = bookEndPoint;
            _status = status;
            _window = window;

        }
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            try
            {
                await LoadBook();
            }
            catch (Exception ex)
            {
                //

                _status.UpdateMessage("Brak dostępu", "Nie masz pozwolenia aby wejść w tą sekcje danych");
                _window.ShowDialog(_status);

                TryClose();

            }
        }
        public async Task LoadBook()
        {
            var BookList = await _bookEndPoint.GetAll();
            Books = new BindingList<Book>(BookList);
        }
        private BindingList<Book> _books;
        public BindingList<Book> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                NotifyOfPropertyChange(() => Books);
            }
        }


    }
}
