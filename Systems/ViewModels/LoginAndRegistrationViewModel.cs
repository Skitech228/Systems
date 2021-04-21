using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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
        private ObservableCollection<UserEntity> _users;
        private UserEntity _selectedUser;
        private DelegateCommand _addUserCommand;
        private AsyncRelayCommand _removeUserCommand;
        private AsyncRelayCommand _applyUserChangesCommand;
        private DelegateCommand _changeEditModeCommand;
        private AsyncRelayCommand _reloadUserCommand;

        public LoginAndRegistrationViewModel(ISystemOperations systemOperations)
        {
            _systemOperations = systemOperations;
            Users = new ObservableCollection<UserEntity>();

            ReloadUsersAsync()
                    .Wait();
        }

        public DelegateCommand AddUserCommand => _addUserCommand ??= new DelegateCommand(OnAddUserCommandExecuted);

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

        private void OnAddUserCommandExecuted()
        {
            Users.Insert(0,
                            new UserEntity(new User
                                           {
                                              Password = String.Empty,
                                              Email = String.Empty
                                           }));

            SelectedUser = Users.First();
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
            if (SelectedUser.Entity.Id == 0)
                await _systemOperations.AddUserAsync(SelectedUser.Entity);
            else
                await _systemOperations.UpdateUserAsync(SelectedUser.Entity);

            await ReloadUsersAsync();
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
