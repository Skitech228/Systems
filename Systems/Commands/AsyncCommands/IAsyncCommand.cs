﻿#region Using derectives

using System.Threading.Tasks;
using System.Windows.Input;

#endregion

namespace Systems.AsyncCommands
{
    internal interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();

        bool CanExecute();
    }
}