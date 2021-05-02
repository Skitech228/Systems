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

        #region OpenLoginOrRegistrationPageCommand

        private DelegateCommand _openLoginOrRegistrationPage;

        public DelegateCommand OpenLoginOrRegistrationPageCommand => _openLoginOrRegistrationPage ??= new DelegateCommand(ToAytorization);

        private void ToAytorization()
        {
            var frame = new MainWindow();
            frame.Frame1.Source = new Uri(@"LogInAndRegistrationPage.xaml",
                                                     System.UriKind.RelativeOrAbsolute);

            foreach (Window w in App.Current.Windows)
                w.Hide();
            frame.Show();
        }

        #endregion
    }
}
