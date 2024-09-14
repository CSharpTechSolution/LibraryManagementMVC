using LibraryManagementSystem.Context;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Implementation.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly ApplicationContext _context;
        public LibraryRepository(ApplicationContext context) 
        {
            _context = context;
        }

        public Task<bool> Check(Expression<Func<Library, bool>> predicate)
        {
            var IsExist = _context.Library.AnyAsync(predicate);
            return IsExist;
        }

        public async Task<Library> CreateAsync(Library library)
        {
            if (library == null) throw new ArgumentNullException(nameof(library));
            await _context.Library.AddAsync(library);
            await _context.SaveChangesAsync();
            return library;
        }

        public Task<Library> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Library> Get(Expression<Func<Library, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Library>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Library> Update(Library library)
        {
            if (library == null) throw new ArgumentNullException(nameof(library));
            _context.Library.Update(library);
            await _context.SaveChangesAsync();
            return library;
        }
    }
}
