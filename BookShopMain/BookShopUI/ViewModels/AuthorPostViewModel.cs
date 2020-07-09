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
    public class AuthorPostViewModel : Screen
    {
        IAuthorPostEndPoint _authorPostEndPoint;
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _window;
        public AuthorPostViewModel(IAuthorPostEndPoint authorPostEndPoint, StatusInfoViewModel status, IWindowManager window)
        {
            _authorPostEndPoint = authorPostEndPoint;
            _status = status;
            _window = window;

        }
        
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);

            }
        }
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                NotifyOfPropertyChange(() => DateOfBirth);

            }
        }
        public async Task AddButton()
        {
            Author author = new Author();
            author.DateOfBirth = DateOfBirth;
            author.FirstName = FirstName;
            author.LastName = LastName;
            
            try
            {
                await _authorPostEndPoint.PostAuthor(author);
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
