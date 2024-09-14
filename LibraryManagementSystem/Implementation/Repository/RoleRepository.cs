using LibraryManagementSystem.Context;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Implementation.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationContext _context;
        public RoleRepository(ApplicationContext context) 
        {
            _context = context;
        }
        public Task<bool> Check(Expression<Func<Role, bool>> predicate)
        {
            var IsRole = _context.Roles.AnyAsync(predicate);
            return IsRole;
        }

        public async Task<Role> CreateAsync(Role role)
        {
            if (role == null) throw new ArgumentNullException(nameof(role));
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Roles.AnyAsync(r => r.Name == name & r.IsDeleted == false);
        }

        public async Task<Role> Get(string id)
        {
            var role = await _context.Roles
                .Include(ur => ur.UserRoles)
                .SingleOrDefaultAsync(u => u.Id == id);
            return role;
        }

        public async Task<Role> Get(Expression<Func<Role, bool>> predicate)
        {
            var getRole = await _context.Roles
                         .Include(l => l.UserRoles)
                         .SingleOrDefaultAsync(predicate);
            return getRole;
        }

        public async Task<ICollection<Role>> GetAll()
        {
            var getAll = await _context.Roles
                .Include(e => e.UserRoles)
                .ToListAsync();
            return getAll;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Role> Update(Role role)
        {
            if (role == null) throw new ArgumentNullException(nameof(role));
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role;
        }
    }
}
