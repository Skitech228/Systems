using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Systems.Models;
using Systems.Models.Entitys;
using Systems.Operations.Intefases;
using Prism.Commands;
using Prism.Mvvm;
using Systems.AsyncCommands;

namespace Systems.ViewModels
{
    public class LoginAndRegistrationViewModel:BindableBase
    {
        private readonly ISystemOperations _systemOperations;
        private bool _isEditMode;
        private ObservableCollection<UserEntity> _userses;
        private UserEntity _selectedUser;
        private SignInViewModel _sighInUser;
        private RegistrationViewModel _registration;
        private DelegateCommand _addUserCommand;
        private AsyncRelayCommand _removeUserCommand;
        private DelegateCommand _signInUserCommand;
        private AsyncRelayCommand _applyUserChangesCommand;
        private DelegateCommand _changeEditModeCommand;
        private AsyncRelayCommand _reloadUserCommand;

        public LoginAndRegistrationViewModel(ISystemOperations systemOperations,
                                             SignInViewModel signIn,
                                             RegistrationViewModel registration)
        {
            _registration = registration;
            _sighInUser = signIn;
            _systemOperations = systemOperations;
            Userses = new ObservableCollection<UserEntity>();

            ReloadUsersAsync()
                    .Wait();
        }

        //public DelegateCommand AddUserCommand => _addUserCommand ??= new DelegateCommand(OnAddUserCommandExecuted);
        public DelegateCommand SignInCommand => _signInUserCommand ??= new DelegateCommand(OnSignInCommandExecuted);

        public AsyncRelayCommand RemoveUserCommand => _removeUserCommand ??= new AsyncRelayCommand(OnRemoveUserCommandExecuted,
                                                                                                       CanManipulateOnUser);

        public AsyncRelayCommand ApplyUserChangesCommand => _applyUserChangesCommand ??= new AsyncRelayCommand(OnApplyUserChangesCommandExecuted);

        public DelegateCommand ChangeEditModeCommand => _changeEditModeCommand ??= new DelegateCommand(OnChangeEditModeCommandExecuted,
                                                                                                       CanManipulateOnUser)
                                                                .ObservesProperty(() => SelectedUser);

        public AsyncRelayCommand ReloadUsersCommand => _reloadUserCommand ??= new AsyncRelayCommand(ReloadUsersAsync);

        public ObservableCollection<UserEntity> Userses
        {
            get => _userses;
            set => SetProperty(ref _userses, value);
        }

        public UserEntity SelectedUser
        {
            get => _selectedUser;
            set
            {
                SetProperty(ref _selectedUser, value);
                RemoveUserCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsEditMode
        {
            get => _isEditMode;
            set => SetProperty(ref _isEditMode, value);
        }

        private bool CanManipulateOnUser() => SelectedUser is not null;

        private void OnChangeEditModeCommandExecuted() => IsEditMode = !IsEditMode;

        private bool OnAddUserCommandExecuted()
        {
            if (Registration.Password == Registration.ConfirmPassword)
            {
                Userses.Insert(0,
                               new UserEntity(new User
                                              {
                                                      Password = Registration.Password,
                                                      Email = Registration.Email
                                              }));

                SelectedUser = Userses.First();

                return true;
            }
            else
            {
                MessageBox.Show("Лох");

                return false;
            }
        }

        #region SingInUser & Registration Property

        public SignInViewModel SighInUser
        {
            get
            {
                return _sighInUser;
            }
            set { SetProperty(ref _sighInUser, value); }
        }

        public RegistrationViewModel Registration
        {
            get { return _registration; }
            set { SetProperty(ref _registration, value); }
        }
        #endregion

        private void OnSignInCommandExecuted()
        {
            User user=_systemOperations.GetSignInUser(SighInUser.Email, SighInUser.Password);
            if (user is null) MessageBox.Show("govno");
        }
        private async Task OnRemoveUserCommandExecuted()
        {
            if (SelectedUser.Entity.Id == 0)
                Userses.Remove(SelectedUser);

            await _systemOperations.RemoveUserAsync(SelectedUser.Entity);
            Userses.Remove(SelectedUser);
            SelectedUser = null;
        }

        private async Task OnApplyUserChangesCommandExecuted()
        {
            if (OnAddUserCommandExecuted())
            {
                if (SelectedUser.Entity.Id == 0)
                    await _systemOperations.AddUserAsync(SelectedUser.Entity);
                else
                    await _systemOperations.UpdateUserAsync(SelectedUser.Entity);

                await ReloadUsersAsync();
            }
        }

        private async Task ReloadUsersAsync()
        {
            var dbPreOrders = await _systemOperations.GetAllUsersAsync();
            Userses.Clear();

            foreach (var preOrder in dbPreOrders)
                Userses.Add(new UserEntity(preOrder));
        }
    }
}
