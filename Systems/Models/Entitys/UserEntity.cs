using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Prism.Mvvm;

namespace Systems.Models.Entitys
{
    public class UserEntity:BindableBase
    {
        public UserEntity(User _user)
        {
            Entity = _user;
        }

        #region Entity Property
        private User _Entity = null;
        public User Entity
        {
            get
            {
                return _Entity;
            }
            set { SetProperty(ref _Entity, value); }
        }

        #endregion

    }
}
