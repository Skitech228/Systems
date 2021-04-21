using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Models;

namespace Systems.Operations.Intefases
{
    public interface ISystemOperations
    {
        public Task<bool> AddUserAsync(User user);

        public Task<bool> RemoveUserAsync(User customer);

        public Task<bool> UpdateUserAsync(User user);

        public Task<User> GetByIdAsync(int id);

        public Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
