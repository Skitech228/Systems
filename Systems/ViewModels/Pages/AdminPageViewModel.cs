using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Operations.Intefases;
using Prism.Mvvm;

namespace Systems.ViewModels.Pages
{
    class AdminPageViewModel :BindableBase
    {
        private AdminViewModel _users;

        public AdminPageViewModel(ISystemOperations user)
        {
            UsersContext = new AdminViewModel(user);
        }

        public AdminViewModel UsersContext
        {
            get => _users;
            set { SetProperty(ref _users, value); }
        }
    }
}
