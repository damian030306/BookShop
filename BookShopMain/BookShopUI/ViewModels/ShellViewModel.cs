using BookShopUI.EventModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
       // private LoginViewModel loginVM1;
        private IEventAggregator _events;
        private AuthorViewModel _authorVM;
        private SimpleContainer _container;

        // public ShellViewModel(LoginViewModel loginVM, IEventAggregator events, AuthorViewModel authorVM, SimpleContainer container)
        public ShellViewModel( IEventAggregator events, AuthorViewModel authorVM, SimpleContainer container)
        {
            _events = events;
          //  loginVM1 = loginVM;
            _authorVM = authorVM;
            _container = container;

            _events.Subscribe(this);

            // ActivateItem(_container.GetInstance<LoginViewModel>());
            ActivateItem(IoC.Get<LoginViewModel>());
        }
        public void LogIn()
        {
            ActivateItem(IoC.Get<LoginViewModel>());
        }
        public void Authors1()
        {
            ActivateItem(IoC.Get<AuthorViewModel>());
        }
        public void Books1()
        {
            ActivateItem(IoC.Get<BookViewModel>());
        }
        public void Exit()
        {
            TryClose();
        }
        public void LogOut()
        {
            ActivateItem(IoC.Get<LoginViewModel>());
        }
        public void PublishingHouse1()
        {
            ActivateItem(IoC.Get<PublishingHouseViewModel>());
        }
        public void Handle(LogOnEvent message)
        {
            ActivateItem(_authorVM);
           // loginVM1 = _container.GetInstance<LoginViewModel>();
        }
    }
}