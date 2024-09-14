using LibraryManagementSystem.Entities;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Interface.Repository
{
    public interface IEmailRepository
    {
        Task<Email> Get(string id);
        Task<Email> Get(Expression<Func<Email, bool>> predicate);
        Task<ICollection<Email>> GetAll();
        Task<Email> CreateAsync(Email email);
        Task<Email> Update(Email borrow);
        Task<bool> Check(Expression<Func<Email, bool>> predicate);
        Task<int> SaveAsync();
    }
}
