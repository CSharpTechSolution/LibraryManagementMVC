using LibraryManagementSystem.Entities;
using System.Linq.Expressions;
using System.Net;

namespace LibraryManagementSystem.Interface.Repository
{
    public interface IBookRepository
    {
        Task<Book> Get(string id);
        Task<Book> Get(Expression<Func<Book, bool>> predicate);
        Task<ICollection<Book>> GetAll();
        Task<Book> CreateAsync(Book book);
        Task<Book> Update(Book book);
        Task<bool> Check(Expression<Func<Book, bool>> predicate);
        Task<int> SaveAsync();
        Task<Book> Delete(string id);
        Task Delete(Book book); //(void)

    }
}
