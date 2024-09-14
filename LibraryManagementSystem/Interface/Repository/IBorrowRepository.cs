using LibraryManagementSystem.Entities;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Interface.Repository
{
    public interface IBorrowRepository
    {
        Task<Borrow> Get(string id);
        Task<Borrow> Get(Expression<Func<Borrow, bool>> predicate);
        Task<ICollection<Borrow>> GetAll();
        Task<Borrow> CreateAsync(Borrow borrow);
        Task<Borrow> Update(Borrow borrow);
        Task<bool> Check(Expression<Func<Borrow, bool>> predicate);
        Task<int> SaveAsync();

        Task<Book> Delete(string id);

        Task Delete(Borrow borrow); //(void)
    }
}
