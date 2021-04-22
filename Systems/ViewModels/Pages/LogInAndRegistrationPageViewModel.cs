using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Systems.Models;
using Systems.Operations.Intefases;
using Systems.Operations.Realization;
using Systems.View;
using Prism.Mvvm;
using Systems.ViewModels;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;

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

        #region Commands

        private DelegateCommand _navigationCommand;
        public DelegateCommand NavigationCommand => _navigationCommand ??= new DelegateCommand(OnNavigate);

        private void OnNavigate()
        {
            if (LoginUI=="Visible")
            {
                LoginUI = "Hidden";
                RegistrationUI = "Visible";
                RegistrationColor = new SolidColorBrush(Color.FromRgb(25, 188, 156));
                LoginColor = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            else
            {
                LoginUI = "Visible";
                RegistrationUI = "Hidden";
                LoginColor = new SolidColorBrush(Color.FromRgb(25, 188, 156));
                RegistrationColor = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
        }

        #endregion


        #region LoginColor Property

        /// <summary>
        /// Private member backing variable for <see cref="LoginColor" />
        /// </summary>
        private SolidColorBrush _loginColor;

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public SolidColorBrush LoginColor
        {
            get
            {
                return _loginColor ??= new SolidColorBrush(Color.FromRgb(25, 188, 156));
            }
            set { SetProperty(ref _loginColor, value); }
        }

        #endregion

        #region RegistrationColor Property

        /// <summary>
        /// Private member backing variable for <see cref="LoginColor" />
        /// </summary>
        private SolidColorBrush _registrationColor = new SolidColorBrush(Color.FromRgb(255, 255, 255));

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public SolidColorBrush RegistrationColor
        {
            get { return _registrationColor; }
            set { SetProperty(ref _registrationColor, value); }
        }

        #endregion

        #region LoginUI Property

        /// <summary>
        /// Private member backing variable for <see cref="UI" />
        /// </summary>
        private string _loginui = "Visible";

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public string LoginUI
        {
            get
            {
                return _loginui;
            }
            set { SetProperty( ref _loginui, value); }
        }

        #endregion

        #region RegistrationUI Property

        /// <summary>
        /// Private member backing variable for <see cref="RegistrationUI" />
        /// </summary>
        private string _registrationUI = "Hidden";

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public string RegistrationUI
        {
            get
            {
                return _registrationUI;
            }
            set { SetProperty(ref _registrationUI, value); }
        }

        #endregion


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
