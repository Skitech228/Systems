using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using Systems.ViewModels;
using Systems.ViewModels.Windows;
using Systems.Views;
using Egor92.MvvmNavigation.Abstractions;

namespace Systems.ViewModels.Pages
{
    class UnregisteredUserPageViewModel:BindableBase
    {

        #region MainWindowContext Property

        /// <summary>
        /// Private member backing variable for <see cref="MainWindowContext" />
        /// </summary>
        private MainWindowViewModel _mainWindowContext = null;

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public MainWindowViewModel MainWindowContext
        {
            get
            {
                return _mainWindowContext;
            }
            set { SetProperty(ref _mainWindowContext, value); }
        }

        #endregion

        private readonly INavigationManager _navigationManager;

        public UnregisteredUserPageViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        private void GoToSecondPage()
        {
            // Сменить интерфейс
            _navigationManager.Navigate("LogInAndRegistrationKey");
        }
        #region OpenLoginOrRegistrationPageCommand

        private DelegateCommand _openLoginOrRegistrationPage;

        public DelegateCommand OpenLoginOrRegistrationPageCommand =>
                _openLoginOrRegistrationPage ??= new DelegateCommand(GoToSecondPage);

        #endregion
    }
}
