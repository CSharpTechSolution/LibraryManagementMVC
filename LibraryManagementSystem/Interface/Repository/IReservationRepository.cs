using LibraryManagementSystem.Entities;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Interface.Repository
{
    public interface IReservationRepository
    {
        Task<Reservation> Get(string id);
        Task<Reservation> Get(Expression<Func<Reservation, bool>> predicate);
        Task<ICollection<Reservation>> GetAll();
        Task<Reservation> CreateAsync(Reservation reservation);
        Task<Reservation> Update(Reservation reservation);
        Task<bool> Check(Expression<Func<Reservation, bool>> predicate);
        Task<int> SaveAsync();
    }
}
