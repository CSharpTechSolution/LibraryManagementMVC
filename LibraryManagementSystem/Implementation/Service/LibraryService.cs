using LibraryManagementSystem.Dto;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interface.Repository;
using LibraryManagementSystem.Interface.Service;

namespace LibraryManagementSystem.Implementation.Service
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _libraryRepository;

        public LibraryService(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        public async Task<BaseResponse<LibraryDto>> Register(CreateLibraryRequestModel model)
        {
            var library = await _libraryRepository.Get(model.Name);
            if (library is not null)
            {
                return new BaseResponse<LibraryDto>
                {
                    Mesage = " Library Already Exist",
                    Status = false
                };
            }
            var libry = new Library
            {
                Name = model.Name,
                ContactNumber = model.ContactNumber,
                Adress = model.Adress,

            };
            await _libraryRepository.CreateAsync(libry);
            await _libraryRepository.SaveAsync();

            return new BaseResponse<LibraryDto>
            {
                Mesage = " Library Successfully Created",
                Status = true,
                Data = new LibraryDto
                {
                    Name = model.Name,
                    ContactNumber= model.ContactNumber,
                    Adress= model.Adress

                }
            };
        }
}   }
