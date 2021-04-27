using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.ViewModels.Pages;
using Systems.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;

namespace Systems.ViewModels.Windows
{
    class MainWindowViewModel:BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;

        public MainWindowViewModel(IRegionManager regionManager,
                                   IEventAggregator eventAggregator)
        {
            //_regionManager = regionManager;
            //_eventAggregator = eventAggregator;

            ////_regionManager.RegisterViewWithRegion("Pages", () => ContainerLocator.Container.Resolve<LogInAndRegistrationPage>());

            ////_regionManager.RegisterViewWithRegion("Pages", () => ContainerLocator.Container.Resolve<RegisteredUserPage>());

            ////_regionManager.RegisterViewWithRegion("Pages", () => ContainerLocator.Container.Resolve<UnregisteredUserPage>());

            //regionManager.RequestNavigate("Pages", "UnregisteredUserPage");
        }
    }
}
