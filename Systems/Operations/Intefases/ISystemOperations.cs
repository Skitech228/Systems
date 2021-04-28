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
         Task<bool> AddUserAsync(User user);

         Task<bool> RemoveUserAsync(User customer);

         Task<bool> UpdateUserAsync(User user);

         User GetSignInUser(string email, string password);

         User GetByEmail(string email);

         Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
