using LibraryManagementSystem.Dto;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interface.Repository;
using LibraryManagementSystem.Interface.Service;
using System.Threading;

namespace LibraryManagementSystem.Implementation.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILibraryRepository _libraryRepository;

        public BookService(IBookRepository bookRepository, ILibraryRepository libraryRepository)
        {
            _bookRepository = bookRepository;
            _libraryRepository = libraryRepository;
        }

        public async Task<BaseResponse<BookDto>> Delete(string BookId)
        {
            var book = await _bookRepository.Get(b => b.Id == BookId);
            if (book is null)
            {
                return new BaseResponse<BookDto>
                {
                    Status = false,
                    Mesage = "Book does not exist in our Library"   
                };
            }
            await _bookRepository.Delete(book);
            return new BaseResponse<BookDto>
            {
                Status = true,
                Mesage = "Book successfully deleted",
                Data = new BookDto
                {
                    Title = book.Title,
                    ISBN = book.ISBN,
                    LibraryId = book.Library.Id,
                    Author = book.Author,
                    Category = book.Category,
                    PublishedYear = book.PublishedYear
                }
            };
        }

        public async Task<BaseResponse<ICollection<BookDto>>> GetAll()
        {
            var books = await _bookRepository.GetAll();
            if (books.Count == 0) 
            return new BaseResponse<ICollection<BookDto>>
            {
                Mesage = "No Available Book",
                Status = false
            };
            return new BaseResponse<ICollection<BookDto>>
            {
                Data = books.Select(b => new BookDto
                {
                    Id = b.Id,
                    Author = b.Author,
                    ISBN = b.ISBN,
                    LibraryId = b.Library.Id

                }).ToList(),
                Mesage = "Successful",
                Status = true
            };
        }

        public async Task<BaseResponse<BookDto>> Get(string id)
        {
            var getABook = await _bookRepository.Get(id);
            if(getABook is null)
            {
                return new BaseResponse<BookDto>
                {
                    Mesage = $"{getABook.Id} does not exist",
                    Status = false,
                };
            }
            return new BaseResponse<BookDto>
            {
                Mesage = $"Book with the particular {getABook.ISBN} Available",
                Status = true,
                Data = new BookDto
                {
                    Author = getABook.Author,
                }

            };

        }


        public async Task<BaseResponse<BookDto>> Register(CreateBookRequestModel model)
        {
            

            var library = await _libraryRepository.Get(model.LibraryId);

            //var library = new Library
            //{
            //    Name = model.Name,
            //    Adress = model.Adress,
            //    ContactNumber = model.ContactNumber
            //};
            //await _libraryRepository.CreateAsync(library);
            //await _libraryRepository.SaveAsync();

            var isbn = "";
            do
            {
                isbn = "978-" + new Random().Next(1000000, 999999).ToString();
            } while (await _bookRepository.Check(b => b.ISBN == isbn));
            
            var book = new Book
            {
                ISBN = isbn, //model.ISBN,
                Author = model.Author,
                Title = model.Title,
                Category = model.Category,
                PublishedYear = model.PublishedYear,
                IsAvailable = true,
                LibraryId = library.Id
            };
            await _bookRepository.CreateAsync(book);
            await _bookRepository.SaveAsync();

            return new BaseResponse<BookDto>
            {
                Mesage = "Book Successfully Created",
                Status = true,
                Data = new BookDto
                {
                    Id = book.Id,
                    ISBN = model.ISBN,
                    Author = model.Author,
                    Title = model.Title,
                    Category = model.Category,
                    PublishedYear = model.PublishedYear,
                    IsAvailable = true,

                }
            };
        }

        public async Task<BaseResponse<BookDto>> Update(string id, UpdateBookRequestModel model)
        {
            var UpdateBook = await _bookRepository.Get(id);
            if (UpdateBook is null)
            {
                return new BaseResponse<BookDto>
                {
                    Status = false,
                    Mesage = " Not available"
                };
            }
            var updateBook = new Book
            {
                Id = id,
                Author = UpdateBook.Author,
                Title = model.Title,
            };


            await _bookRepository.Update(updateBook);
            await _bookRepository.SaveAsync();

            return new BaseResponse<BookDto>
            {
                Status = true,
                Mesage = "Book Updated",
                Data = new BookDto
                {
                    Author = model.Author,
                }
                
            };
        }

        public async Task<BaseResponse<BookDto>> GetByName(string name)
        {
            var getABook = await _bookRepository.Get(n => n.Author == name);
            if (getABook is null)
            {
                return new BaseResponse<BookDto>
                {
                    Mesage = $"{getABook.Author} does not exist",
                    Status = false,
                };
            }
            return new BaseResponse<BookDto>
            {
                Mesage = $"Book with the particular {getABook.Author} Available",
                Status = true,
                Data =  new BookDto
                {
                    Author = getABook.Author,

                }

            };

        }
    }
}
