#region Using derectives

using System.Windows;
using Systems.Models;
using Systems.Operations.Intefases;
using Systems.Operations.Realization;
using Systems.ViewModels.Pages;
using Prism.Ioc;
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

            containerRegistry.RegisterForNavigation<LogInAndRegistrationPage, LogInAndRegistrationPageViewModel>("AdministratorPage");
        }
        protected override Window CreateShell() => Container.Resolve<LogInAndRegistrationPage>();
        #endregion
    }
}