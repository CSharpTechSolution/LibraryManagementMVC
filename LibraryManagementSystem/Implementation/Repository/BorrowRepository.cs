using LibraryManagementSystem.Context;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Implementation.Repository
{
    public class BorrowRepository : IBorrowRepository
    {
        private readonly ApplicationContext _context;

        public BorrowRepository(ApplicationContext context) 
        {
            _context = context;
        }

        public Task<bool> Check(Expression<Func<Borrow, bool>> predicate)
        {
            var IsCorrect = _context.Borrows.AnyAsync(predicate);
            return IsCorrect;
        }

        public async Task<Borrow> CreateAsync(Borrow borrow)
        {
            if (borrow == null) throw new ArgumentNullException(nameof(borrow));
            await _context.Borrows.AddAsync(borrow);
            await _context.SaveChangesAsync();
            return borrow;
        }

        public async Task<Borrow> Delete(string id)
        {
            var del = await _context.Borrows.FindAsync(id);
            if(del != null)
            {
               del.IsDeleted= true;
                await _context.SaveChangesAsync();
            }
            return del;
           
        }

        public async Task Delete(Borrow borrow)
        {
            if(borrow is not null)
            {
                borrow.IsDeleted = true; 
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Borrow> Get(string id)
        {
            var borrow = await _context.Borrows
                .Include(l => l.User)
                .Include(b => b.Book)
                .SingleOrDefaultAsync(e => e.Id == id);
            return borrow;
        }

        public async Task<Borrow> Get(Expression<Func<Borrow, bool>> predicate)
        {
            var getBorrow = await _context.Borrows
                         .Include(l => l.User)
                         .Include(b => b.Book)
                         .SingleOrDefaultAsync(predicate);
            return getBorrow;
        }

        public async Task<ICollection<Borrow>> GetAll()
        {
            var getAll = await _context.Borrows
                .Include(e => e.User)
                .Include(b => b.Book)
                .ToListAsync();
            return getAll;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Borrow> Update(Borrow borrow)
        {
            if (borrow == null) throw new ArgumentNullException(nameof(borrow));
            _context.Borrows.Update(borrow);
            await _context.SaveChangesAsync();
            return borrow;
        }
    }
}
