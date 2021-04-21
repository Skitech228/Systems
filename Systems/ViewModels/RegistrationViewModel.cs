using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace Systems.ViewModels
{
    public class RegistrationViewModel:BindableBase
    {
        #region Active Property

        /// <summary>
        /// Private member backing variable for <see cref="Active" />
        /// </summary>
        private bool _active = true;

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public bool Active
        {
            get { return _active; }
            set { SetProperty (ref _active, value); }
        }

        #endregion

        #region Email Property

        private String _email = null;

        public String Email
        {
            get
            {
                if (_email == null)
                { _email = String.Empty; }

                return _email;
            }
            set { SetProperty( ref _email, value); }
        }

        #endregion

        #region Password Property

        private String _password = null;

        public String Password
        {
            get
            {
                if (_password == null)
                { _password = String.Empty; }

                return _password;
            }
            set { SetProperty( ref _password, value); }
        }

        #endregion

        #region ConfirmPassword Property

        /// <summary>
        /// Private member backing variable for <see cref="ConfirmPassword" />
        /// </summary>
        private String _confirmPassword = null;

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public String ConfirmPassword
        {
            get
            {
                if (_confirmPassword == null)
                { _confirmPassword = String.Empty; }

                return _confirmPassword;
            }
            set { SetProperty( ref _confirmPassword, value); }
        }

        #endregion

    }
}
