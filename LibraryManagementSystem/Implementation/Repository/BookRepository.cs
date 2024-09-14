using LibraryManagementSystem.Context;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading;

namespace LibraryManagementSystem.Implementation.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationContext _context;
        public BookRepository(ApplicationContext context) 
        {
            _context = context;
        }
        
        public Task<bool> Check(Expression<Func<Book, bool>> predicate)
        {
            return _context.Books.AnyAsync(predicate);

        }

        public async Task<Book> CreateAsync(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> Delete(string id)
        {
            var delBook = await _context.Books.FindAsync(id);
            if (delBook is not null)
            {
                delBook.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
            return delBook;
        }

        public async Task Delete(Book book)
        {
           if(book is not null)
            {
                book.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Book> Get(string id)
        {
            var book = await _context.Books
                .Include(l => l.Library)
                .SingleOrDefaultAsync(e => e.Id == id);
            return book;
        }

        public async Task<Book> Get(Expression<Func<Book, bool>> predicate)
        {
            var getBook = await _context.Books
                         .Include(l => l.Library).SingleOrDefaultAsync(predicate);
                         return getBook;
        }

        public async Task<ICollection<Book>> GetAll()
        {
            var getAllBooks = await _context.Books
                .Include( e => e.Library)
                .ToListAsync();
            return getAllBooks;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Book> Update(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}
