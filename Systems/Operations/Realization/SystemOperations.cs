using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Models;
using Systems.Operations.Intefases;
using Microsoft.EntityFrameworkCore;

namespace Systems.Operations.Realization
{
    public class SystemOperations:ISystemOperations
    {
        private readonly ServiceContext _context;

        public SystemOperations(ServiceContext context) => _context = context;

        public User GetSignInUser(string email, string password) => _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);

        public async Task<bool> AddUserAsync(User user)
        {
            _context.Users.Add(user);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveUserAsync(User user)
        {
            _context.Users.Attach(user);
            _context.Users.Remove(user);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            _context.Users.Attach(user);
            _context.Entry(user).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User> GetByIdAsync(int id) => await _context.Users.FindAsync(id);

        public async Task<IEnumerable<User>> GetAllUsersAsync() => await _context.Users
                                                                           .ToListAsync();
    }
}
