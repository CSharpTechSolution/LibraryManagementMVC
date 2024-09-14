using LibraryManagementSystem.Entities;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Interface.Repository
{
    public interface IUserRepository
    {
        Task<User> Get(string id);
        Task<User> Get(Expression<Func<User, bool>> predicate);
        Task<ICollection<User>> GetAll();
        Task<User> CreateAsync(User user);
        Task<User> Update(User user);
        Task<bool> Check(Expression<Func<User, bool>> predicate);
        Task<bool> ExistsByEmailAsync(string email);
        Task<bool> ExistsByPassWordAsync(string passWord);
        Task<int> SaveAsync();
    }
}
