using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Models.Entitys;
using Systems.Operations.Intefases;
using Prism.Mvvm;

namespace Systems.ViewModels
{
    public class SignInViewModel:BindableBase
    {
        #region Password Property

        private String _login = null;


        public String Password
        {
            get
            {
                return _login;
            }
            set { SetProperty(ref _login, value); }
        }

        #endregion

        #region Email Property

        /// <summary>
        /// Private member backing variable for <see cref="Email" />
        /// </summary>
        private String _email = null;

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public String Email
        {
            get
            {
                return _email;
            }
            set { SetProperty(ref _email, value); }
        }

        #endregion

    }
}
