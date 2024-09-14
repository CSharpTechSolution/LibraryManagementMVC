using LibraryManagementSystem.Context;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Implementation.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationContext _context;
        public ReservationRepository(ApplicationContext context) 
        {
            _context = context;
        }

        public Task<bool> Check(Expression<Func<Reservation, bool>> predicate)
        {
            var IsCorrect = _context.Reservations.AnyAsync(predicate);
            return IsCorrect;
        }

        public async Task<Reservation> CreateAsync(Reservation reservation)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation));
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task Delete(Reservation reservation)
        {
            if(reservation is not null)
            {
                reservation.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task<Reservation> Get(string id)
        {
            var reserve = await _context.Reservations
                .Include(u => u.User)
                .Include(b => b.Book)
                .SingleOrDefaultAsync(e => e.Id == id);
            return reserve;
        }

        public async Task<Reservation> Get(Expression<Func<Reservation, bool>> predicate)
        {
            var getReservation = await _context.Reservations
                         .Include(u => u.User)
                         .Include(b => b.Book)
                         .SingleOrDefaultAsync(predicate);
            return getReservation;
        }

        public async Task<ICollection<Reservation>> GetAll()
        {
            var getAllReservations = await _context.Reservations
                .Include(u => u.User)
                .Include(b => b.Book)
                .ToListAsync();
            return getAllReservations;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Reservation> Update(Reservation reservation)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation));
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }
    }
}
