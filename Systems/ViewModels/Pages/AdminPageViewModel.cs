using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Operations.Intefases;
using Egor92.MvvmNavigation.Abstractions;
using Prism.Mvvm;

namespace Systems.ViewModels.Pages
{
    class AdminPageViewModel :BindableBase
    {

        public AdminPageViewModel(ISystemOperations salesService)
        {
            UsersContext = new AdminViewModel(salesService);
        }

        #region UsersContext Property

        /// <summary>
        /// Private member backing variable for <see cref="UsersContext" />
        /// </summary>
        private AdminViewModel _usersContext ;

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public AdminViewModel UsersContext
        {
            get
            {
                return _usersContext;
            }
            set { SetProperty(ref _usersContext, value); }
        }

        #endregion

    }
}
