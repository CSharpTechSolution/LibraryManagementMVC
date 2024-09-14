using LibraryManagementSystem.Entities;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Interface.Repository
{
    public interface IRoleRepository
    {
        Task<Role> Get(string id);
        Task<Role> Get(Expression<Func<Role, bool>> predicate);
        Task<ICollection<Role>> GetAll();
        Task<Role> CreateAsync(Role role);
        Task<Role> Update(Role role);
        Task<bool> Check(Expression<Func<Role, bool>> predicate);
        Task<int> SaveAsync();
        Task<bool> ExistsByNameAsync(string name);
    }
}
