using LibraryManagementSystem.Context;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interface.Repository;
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
            throw new NotImplementedException();
        }

        public Task<Role> CreateAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Role> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> Get(Expression<Func<Role, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Role>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Role> Update(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
