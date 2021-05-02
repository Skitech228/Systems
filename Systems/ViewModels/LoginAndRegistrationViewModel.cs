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
using Systems.Views;

namespace Systems.ViewModels
{
    public class LoginAndRegistrationViewModel:BindableBase
    {
        private readonly ISystemOperations _systemOperations;
        private bool _isEditMode;
        private ObservableCollection<UserEntity> _users;
        private UserEntity _selectedUser;
        private SignInViewModel _sighInUser;
        private RegistrationViewModel _registration;
        private DelegateCommand _addUserCommand;
        private DelegateCommand _navigationCommand;
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
            Users = new ObservableCollection<UserEntity>();

            ReloadUsersAsync()
                    .Wait();
        }

        //public DelegateCommand AddUserCommand => _addUserCommand ??= new DelegateCommand(OnAddUserCommandExecuted);
        public DelegateCommand SignInCommand => _signInUserCommand ??= new DelegateCommand(OnSignInCommandExecuted);
        public DelegateCommand NavigationCommand => _navigationCommand ??= new DelegateCommand(OnSignInCommandExecuted);

        public AsyncRelayCommand RemoveUserCommand => _removeUserCommand ??= new AsyncRelayCommand(OnRemoveUserCommandExecuted,
                                                                                                       CanManipulateOnUser);

        public AsyncRelayCommand ApplyUserChangesCommand => _applyUserChangesCommand ??= new AsyncRelayCommand(OnApplyUserChangesCommandExecuted);

        public DelegateCommand ChangeEditModeCommand => _changeEditModeCommand ??= new DelegateCommand(OnChangeEditModeCommandExecuted,
                                                                                                       CanManipulateOnUser)
                                                                .ObservesProperty(() => SelectedUser);

        public AsyncRelayCommand ReloadUsersCommand => _reloadUserCommand ??= new AsyncRelayCommand(ReloadUsersAsync);

        public ObservableCollection<UserEntity> Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
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
                Users.Insert(0,
                               new UserEntity(new User
                                              {
                                                      Password = Registration.Password,
                                                      Email = Registration.Email
                                              }));

                SelectedUser = Users.First();

                return true;
            }
            else
            {
                MessageBox.Show("Passwords don't match");
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
            if (user is null) 
                MessageBox.Show("Email or password isn't correct");
            else
            {
                MessageBox.Show("Success");
                System.Threading.Thread.Sleep(1000);

                if (user.Email == "admin@gmail.com" &&
                    user.Password == "12345")
                {
                    var frame = new MainWindow();

                    frame.Frame1.Source = new Uri(@"AdminPage.xaml",
                                                  System.UriKind.RelativeOrAbsolute);

                    foreach (Window w in App.Current.Windows)
                        w.Hide();

                    frame.Show();
                }
                else
                {
                    var frame = new MainWindow();

                    frame.Frame1.Source = new Uri(@"RegisteredUserPage.xaml",
                                                  System.UriKind.RelativeOrAbsolute);

                    foreach (Window w in App.Current.Windows)
                        w.Hide();

                    frame.Show();
                }
            }
        }

        private async Task OnRemoveUserCommandExecuted()
        {
            if (SelectedUser.Entity.Id == 0)
                Users.Remove(SelectedUser);

            await _systemOperations.RemoveUserAsync(SelectedUser.Entity);
            Users.Remove(SelectedUser);
            SelectedUser = null;
        }

        private async Task OnApplyUserChangesCommandExecuted()
        {
            if (OnAddUserCommandExecuted())
            {
                User user = _systemOperations.GetByEmail(Registration.Email);
                if (user is null)
                {
                    if (SelectedUser.Entity.Id == 0)
                        await _systemOperations.AddUserAsync(SelectedUser.Entity);
                    else
                        await _systemOperations.UpdateUserAsync(SelectedUser.Entity);

                    await ReloadUsersAsync();
                    MessageBox.Show("Success");
                }
                else
                {
                    MessageBox.Show("Email address is exists");
                }
            }
        }

        private async Task ReloadUsersAsync()
        {
            var dbPreOrders = await _systemOperations.GetAllUsersAsync();
            Users.Clear();

            foreach (var preOrder in dbPreOrders)
                Users.Add(new UserEntity(preOrder));
        }
    }
}
