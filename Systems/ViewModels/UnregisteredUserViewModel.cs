using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.ViewModels.Windows;
using Prism.Mvvm;

namespace Systems.ViewModels
{
    class UnregisteredUserViewModel:BindableBase
    {
        private MainWindowViewModel _mainWindowFrame;

        public UnregisteredUserViewModel(MainWindowViewModel main)
        {
            _mainWindowFrame = main;
        }

        public MainWindowViewModel MainWindowFrame
        {
            get { return _mainWindowFrame; }

            set { SetProperty(ref _mainWindowFrame, value); }
        }
    }
}
