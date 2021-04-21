using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Systems.Models;
using Systems.Operations.Intefases;
using Systems.Operations.Realization;
using Prism.Mvvm;
using Systems.ViewModels;

namespace Systems.ViewModels.Pages
{
    public class LogInAndRegistrationPageViewModel: BindableBase
    {

        public LogInAndRegistrationPageViewModel(ISystemOperations _systemOperations,
                                                 SignInViewModel sign,
                                                 RegistrationViewModel registration)
        {
            SystemOperationsContext = new LoginAndRegistrationViewModel(_systemOperations,sign, registration);
        }


        #region SystemOperationsContext Property

        LoginAndRegistrationViewModel _systemOperationsContext;
        public LoginAndRegistrationViewModel SystemOperationsContext
        {
            get
            {
                return _systemOperationsContext;
            }
            set { SetProperty(ref _systemOperationsContext, value); }
        }
        #endregion

    }
}
