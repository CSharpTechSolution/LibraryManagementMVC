using LibraryManagementSystem.Context;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Implementation.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context) 
        {
            _context = context;
        }

        public Task<bool> Check(Expression<Func<User, bool>> predicate)
        {
            var IsUser = _context.Users.AnyAsync(predicate);
            return IsUser;
        }

        public async Task<User> CreateAsync(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Users.AnyAsync(e => e.Equals(email) & e.IsDeleted == false);
        }

        public async Task<bool> ExistsByPassWordAsync(string passWord)
        {
            return await _context.Users.AnyAsync(e => e.Equals(passWord) & e.IsDeleted == false);
        }

        public async Task<User> Get(string id)
        {
           var getUser = await _context.Users.Include(x => x.UserRoles).SingleOrDefaultAsync(e => e.Id == id);
            return getUser;

        }

        public async Task<User> Get(Expression<Func<User, bool>> predicate)
        {
            var getIsUser = await _context.Users
                         .Include(l => l.UserRoles)
                         .SingleOrDefaultAsync(predicate);
            return getIsUser;
        }

        public async Task<ICollection<User>> GetAll()
        {
            var getAll = await _context.Users
                .Include(e => e.UserRoles)
                .ToListAsync();
            return getAll;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<User> Update(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
