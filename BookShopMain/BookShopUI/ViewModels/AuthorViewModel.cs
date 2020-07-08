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
        public AuthorViewModel(IAuthorEndPoint authorEndPoint)
        {
            _authorEndPoint = authorEndPoint;
           
        }
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadAuthor();
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
