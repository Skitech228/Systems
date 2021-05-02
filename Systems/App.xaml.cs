#region Using derectives

using System.Windows;
using Systems.Models;
using Systems.Models.Entitys;
using Systems.Operations.Intefases;
using Systems.Operations.Realization;
using Systems.ViewModels;
using Systems.ViewModels.Pages;
using Systems.ViewModels.Windows;
using Systems.Views;
using Egor92.MvvmNavigation;
using Egor92.MvvmNavigation.Abstractions;
using Microsoft.EntityFrameworkCore;

using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;

#endregion

namespace Systems
{
    public partial class App : PrismApplication
    {
        #region Overrides of PrismApplicationBase

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ServiceContext>(() =>
                                                                {
                                                                    var context = new ServiceContext();

                                                                    return context;
                                                                });

            containerRegistry.RegisterScoped<ISystemOperations, SystemOperations>();

            containerRegistry.RegisterForNavigation<LogInAndRegistrationPage, LogInAndRegistrationPageViewModel>("LogInPage");

            containerRegistry.RegisterForNavigation<AdminPage, AdminPageViewModel>("AdminPage");

            containerRegistry.RegisterForNavigation<RegisteredUserPage, RegisteredUserPageViewModel>("RegisteredUserPage");

            containerRegistry.RegisterForNavigation<UnregisteredUserPage, UnregisteredUserPageViewModel>("UnregisteredUserPage");

            containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>("MainWindow");
            //containerRegistry.Register<MainWindow>(() => new MainWindow
            //                                             {
            //                                                     DataContext =
            //                                                             new MainWindowViewModel(Container
            //                                                                                             .Resolve<
            //                                                                                                     IRegionManager
            //                                                                                                     >(),
            //                                                                                     Container
            //                                                                                             .Resolve<
            //                                                                                                     IEventAggregator
            //                                                                                                     >())
            //                                             });
        }
        protected override Window CreateShell() => Container.Resolve<MainWindow>();
        #endregion
    }
}