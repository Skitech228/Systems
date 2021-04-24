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

namespace Systems.ViewModels.Pages
{
    class UnregisteredUserPageViewModel:BindableBase
    {
        private MainWindowViewModel _mainWindowFrame;
        public UnregisteredUserPageViewModel(MainWindowViewModel main)
        {
            _mainWindowFrame=main;
        }

        public MainWindowViewModel MainWindowFrame
        {
            get { return _mainWindowFrame; }

            set { SetProperty(ref _mainWindowFrame, value); }
        }

        private DelegateCommand _openLoginOrRegistrationPage;

        public DelegateCommand OpenLoginOrRegistrationPageCommand =>
                _openLoginOrRegistrationPage ??= new DelegateCommand(OpenLoginOrRegistrationPage);

        private void OpenLoginOrRegistrationPage()
        {
        }
    }
}
