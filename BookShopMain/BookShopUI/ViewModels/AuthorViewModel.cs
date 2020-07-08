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
    public class AuthorViewModel : Screen
    {
        IAuthorEndPoint _authorEndPoint;
        private readonly StatusInfoViewModel _status;
            private readonly IWindowManager _window;
        public AuthorViewModel(IAuthorEndPoint authorEndPoint, StatusInfoViewModel status, IWindowManager window)
        {
            _authorEndPoint = authorEndPoint;
            _status = status;
            _window = window;
           
        }
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            try
            {
                await LoadAuthor();
            }
           catch(Exception ex)
            {
                //
                if(ex.Message == "Unauthorized")
                {
                    _status.UpdateMessage("Brak dostępu", "Nie masz pozwolenia aby wejść w tą sekcje danych");
                    _window.ShowDialog(_status);
                }
                else
                {
                    _status.UpdateMessage("Błąd", "Wystąpił nieoczekiwany błąd");
                    _window.ShowDialog(_status);
                }
                
            }
        }
        public async Task LoadAuthor()
        {
            var authorList = await _authorEndPoint.GetAll();
            Authors = new BindingList<Author>(authorList);
        }
        private BindingList<Author> _authors;
        public BindingList<Author> Authors
        {
            get { return _authors; }
            set
            {
                _authors = value;
                NotifyOfPropertyChange(() => Authors);
            }
        }
    }
}
