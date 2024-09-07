using LibraryManagementSystem.Context;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Implementation.Repository;

public class BookRepository : IBookRepository
{
    private readonly ApplicationContext _context;
    public BookRepository(ApplicationContext context) 
    {
        _context = context;
    }
    public Task<bool> Check(Expression<Func<Book, bool>> predicate)
    {
        var IsCorrect =  _context.Books.AnyAsync(predicate);
        return IsCorrect;
    }

    public Task<Book> CreateAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public Task<Book> Get(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Book> Get(Expression<Func<Book, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Book>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Book> Update(Book book)
    {
        throw new NotImplementedException();
    }
}
