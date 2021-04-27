using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.AsyncCommands;
using Systems.Models;
using Systems.Models.Entitys;
using Systems.Operations.Intefases;
using Systems.ViewModels.Pages;
using Prism.Commands;
using Prism.Mvvm;

namespace Systems.ViewModels
{
    class AdminViewModel:BindableBase
    {
         private readonly ISystemOperations _userService;

        //???
        //private readonly ISalesStatisticsPrinter _salesStatisticsPrinter;
        private bool _isEditMode;
        private ObservableCollection<UserEntity> _users;
        private UserEntity _selectedUser;
        private DelegateCommand _addUserCommand;
        private AsyncRelayCommand _removeUserCommand;
        private AsyncRelayCommand _applyUserChangesCommand;
        private DelegateCommand _changeEditModeCommand;
        private AsyncRelayCommand _reloadUsersCommand;

        public AdminViewModel(ISystemOperations salesService)
        {
            _userService = salesService;
            Users = new ObservableCollection<UserEntity>();

            ReloadServiceContextAsync()
                    .Wait();
        }

        public DelegateCommand AddUserCommand => _addUserCommand ??= new DelegateCommand(OnAddUserCommandExecuted);

        public AsyncRelayCommand RemoveUserCommand => _removeUserCommand ??= new AsyncRelayCommand(OnRemoveUserCommandExecuted,
                                                                                                   CanManipulateOnWaiter);

        public AsyncRelayCommand ApplyUserChangesCommand => _applyUserChangesCommand ??= new AsyncRelayCommand(OnApplyUserChangesCommandExecuted);

        public DelegateCommand ChangeEditModeCommand => _changeEditModeCommand ??= new DelegateCommand(OnChangeEditModeCommandExecuted,
                                                                                                       CanManipulateOnWaiter)
                                                                .ObservesProperty(() => SelectedUser);

        public AsyncRelayCommand ReloadUsersCommand => _reloadUsersCommand ??= new AsyncRelayCommand(ReloadServiceContextAsync);

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

        private bool CanManipulateOnWaiter() => SelectedUser is not null;

        private void OnChangeEditModeCommandExecuted() => IsEditMode = !IsEditMode;

        private string RandomPassword() 
        {  
            //string password="";
            //int count = new Random().Next(6, 11);
            //for (int i = 0; i < count; i++)
            //{
            //    password+= new Random().Next(0, 10).ToString();
            //}

            var password = Guid.NewGuid().ToString().Replace("-", String.Empty).Substring(0, new Random().Next(6, 10));

            return password;
        }

        private void OnAddUserCommandExecuted()
        {
            Users.Insert(0,
                           new UserEntity(new User
                                          {
                                                  Email = String.Empty,
                                                  Password = RandomPassword()
                                          }));

            SelectedUser = Users.First();
        }

        private async Task OnRemoveUserCommandExecuted()
        {
            if (SelectedUser.Entity.Id == 0)
                Users.Remove(SelectedUser);

            await _userService.RemoveUserAsync(SelectedUser.Entity);
            Users.Remove(SelectedUser);
            SelectedUser = null;
        }

        private async Task OnApplyUserChangesCommandExecuted()
        {
            if (SelectedUser.Entity.Id == 0)
                await _userService.AddUserAsync(SelectedUser.Entity);
            else
                await _userService.UpdateUserAsync(SelectedUser.Entity);

            await ReloadServiceContextAsync();
        }

        private async Task ReloadServiceContextAsync()
        {
            var dbSales = await _userService.GetAllUsersAsync();
            Users.Clear();

            foreach (var sale in dbSales)
                Users.Add(new UserEntity(sale));
        }
    }
}
