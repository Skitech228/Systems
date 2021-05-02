using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Systems.ViewModels.Pages;
using Systems.Views;
using Egor92.MvvmNavigation.Abstractions;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;

namespace Systems.ViewModels.Windows
{
    public class MainWindowViewModel:BindableBase
    {

        private readonly INavigationManager _navigationManager;

        public MainWindowViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

    }
}
