﻿using BookShopUI.EventModels;
using BookShopUI.Helpers;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName ="teest1";
        private string _password = "Password123!";
        private IAPIHelper apiHelper1;
        IEventAggregator _events;

        public LoginViewModel(IAPIHelper apiHelper, IEventAggregator events)
        {
            apiHelper1 = apiHelper;
            _events = events;
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public bool IsErrorVisible
        {
            get
            {
                bool output = false;

                if (ErrorMessage?.Length > 0)
                {
                    output = true;
                }

                return output;
            }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }


        public bool CanLogIn
        {
            get
            {


                if (UserName?.Length > 0 && Password?.Length > 0)
                {
                    return true;
                }

                return false;
            }
        }

        public async Task LoginButton()
        {
            try
            {
                ErrorMessage = "";
                var result = await apiHelper1.Authenticate(UserName, Password);
                { }//
                await apiHelper1.GetAuthor(result.Access_Token);
                _events.PublishOnUIThread(new LogOnEvent());
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

    }
}
