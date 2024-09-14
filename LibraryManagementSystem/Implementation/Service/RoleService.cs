using LibraryManagementSystem.Interface.Repository;
using LibraryManagementSystem.Interface.Service;

namespace LibraryManagementSystem.Implementation.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository) 
        {
            _roleRepository = roleRepository;
        }
    }
}
