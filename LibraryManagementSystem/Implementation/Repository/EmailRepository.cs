using LibraryManagementSystem.Context;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Implementation.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly ApplicationContext _context;

        public EmailRepository(ApplicationContext context) 
        {
            _context = context;
        }

        public Task<bool> Check(Expression<Func<Email, bool>> predicate)
        {
            var email = _context.Emails.AnyAsync(predicate);
            return email;
        }

        public async Task<Email> CreateAsync(Email email)
        {
            if(email==null) throw new ArgumentNullException(nameof(email));
            await _context.Emails.AddAsync(email);
            await _context.SaveChangesAsync();
            return email;
        }

        public async Task<Email> Get(string id)
        {
            var mail = await _context.Emails.SingleOrDefaultAsync(e => e.Id == id);
            return mail;
        }

        public async Task<Email> Get(Expression<Func<Email, bool>> predicate)
        {
            var getMail = await _context.Emails.SingleOrDefaultAsync(predicate);
            return getMail;
        }

        public async Task<ICollection<Email>> GetAll()
        {
            var getAllMails = await _context.Emails.ToListAsync();
            return getAllMails;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Email> Update(Email email)
        {
            if (email == null) throw new ArgumentNullException(nameof(email));
            _context.Emails.Update(email);
            await _context.SaveChangesAsync();
            return email;
        }
    }
}
