using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private LoginViewModel loginVM1;

        public ShellViewModel(LoginViewModel loginVM)
        {
            loginVM1 = loginVM;
            ActivateItem(loginVM1);
        }
    }
}