using LibraryManagementSystem.Entities;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Interface.Repository
{
    public interface ILibraryRepository
    {
        Task<Library> Get(string id);
        Task<Library> Get(Expression<Func<Library, bool>> predicate);
        Task<ICollection<Library>> GetAll();
        Task<Library> CreateAsync(Library library);
        Task<Library> Update(Library library);
        Task<bool> Check(Expression<Func<Library, bool>> predicate);
        Task<int> SaveAsync();
    }
}
