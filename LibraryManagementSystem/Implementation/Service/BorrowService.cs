using LibraryManagementSystem.Dto;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Implementation.Repository;
using LibraryManagementSystem.Interface.Repository;
using LibraryManagementSystem.Interface.Service;
using System.Runtime.InteropServices;

namespace LibraryManagementSystem.Implementation.Service
{
    public class BorrowService : IBorrowService
    {
        private readonly IBorrowRepository _borrowRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public BorrowService(IBorrowRepository borrowRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            _borrowRepository = borrowRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public async Task<BaseResponse<BorrowDto>> DeleteBorrowedBook(string BorrowedBookId)
        {
            var borrow = await _borrowRepository.Get(BorrowedBookId);
           
            if (borrow is not null) 
            {
                return new BaseResponse<BorrowDto>
                {
                    Mesage = "Book is yet to be borrowed",
                    Status = false
                };
            }
            await _borrowRepository.Delete(borrow);
            await _borrowRepository.SaveAsync();

            return new BaseResponse<BorrowDto>
            {
                Mesage = $"Sorry the borrowed book with the {borrow.Id} Id has been Deleted",
                Status = true,
                //Data = new BorrowDto
                //{
                //   UserId = book.user
                //}
            };
        }

        public async Task<BaseResponse<ICollection<BorrowDto>>> GetAllBorrowedBook()
        {
            var getAllBorrowedBook = await _borrowRepository.GetAll();
            if(getAllBorrowedBook is null)
            {
                return new BaseResponse<ICollection<BorrowDto>>
                {
                    Mesage = "No record Found",
                    Status = false
                };
            }

            return new BaseResponse<ICollection<BorrowDto>>
            {
                Data = getAllBorrowedBook.Select(b => new BorrowDto
                {
                    Id = b.Id,
                    BookId = b.BookId,
                    ReturnDate = b.ReturnDate,

                }).ToList(),
            };
        }

        public async Task<BaseResponse<BorrowDto>> GetBorrowedBook(string id)
        {
            var getBorrowedBook = await _borrowRepository.Get(id);
            if(getBorrowedBook is null)
            {
                return new BaseResponse<BorrowDto>
                {
                    Mesage = "Borrow record not found",
                    Status = false
                };
            }

            return new BaseResponse<BorrowDto>
            {
                Mesage = "Borrowed book successful",
                Status = true,
                Data = new BorrowDto
                {
                    Id = getBorrowedBook.Id,
                    UserId = getBorrowedBook.UserId,
                    BookId = getBorrowedBook.BookId,
                    ReturnDate = getBorrowedBook.ReturnDate,
                    BorrowDate = getBorrowedBook.BorrowDate,
                    Book = new BookDto
                    {
                        Author = getBorrowedBook.Book.Author,
                        Title = getBorrowedBook.Book.Title
                    }
                }
            };
        }

        public Task<BaseResponse<BookDto>> GetBorrowedBookByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<BorrowDto>> Register(CreateBorrowRequestModel model)
        {
            var book  = await _bookRepository.Get(model.BookId);
            if (book == null || !book.IsAvailable)
            {
                return new BaseResponse<BorrowDto>
                {
                    Mesage = $"Book Currently Not Available",
                    Status = false,
                };
            }

            

            //var user = await _userRepository.Get(model.UserId);
            //if (user == null)
            //{
            //    return new BaseResponse<BorrowDto>
            //    {
            //        Status = false,
            //        Mesage = "User not found."
            //    };
            //}


            var user = new User
            {
                Id = model.UserId,
                FirstName = model.user.FirstName,
                LastName = model.user.LastName,
            };

            await _userRepository.CreateAsync(user);
            await _userRepository.SaveAsync();

            book.IsAvailable = false;

            var borrow = new Borrow
            {
                UserId = user.Id,
                BookId = model.BookId,
                Book = model.Book,
                BorrowDate = DateTime.Now,
                ReturnDate = model.BorrowDate.AddHours(48d),
            };

            await _borrowRepository.CreateAsync(borrow);
            await _borrowRepository.SaveAsync();

            return new BaseResponse<BorrowDto>
            {
                Mesage = "Book Borrowed Successfully",
                Status = true,
                Data = new BorrowDto
                {
                    Id = borrow.Id,
                    BookId = book.Id,
                    UserId = model.UserId,
                    Book = new BookDto
                    {
                        Author = book.Author,
                        Title = book.Title,

                    }

                }
            };
        }

        public async Task<BaseResponse<BorrowDto>> UpdateAllBorrowed(string id, UpdateBorrowRequestModel model)
        {
            var UpdateBorrowedBook = await _borrowRepository.Get(id);
            if (UpdateBorrowedBook is null)
            {
                return new BaseResponse<BorrowDto>
                {
                    Status = false,
                    Mesage = "Borrow record not found "
                };
            }

            UpdateBorrowedBook.Id = id;
            UpdateBorrowedBook.UserId = model.UserId;
            UpdateBorrowedBook.BookId = model.BookId;
            UpdateBorrowedBook.BorrowDate = model.BorrowDate;
            UpdateBorrowedBook.ReturnDate = model.ReturnDate;


            await _borrowRepository.Update(UpdateBorrowedBook);
            await _borrowRepository.SaveAsync();

            return new BaseResponse<BorrowDto>
            {
                Status = true,
                Mesage = "Book Updated",
                Data = new BorrowDto
                {
                    Id = UpdateBorrowedBook.Id,
                    UserId = UpdateBorrowedBook.UserId,
                    BookId = UpdateBorrowedBook.BookId,
                    BorrowDate = UpdateBorrowedBook.BorrowDate,
                    ReturnDate = UpdateBorrowedBook.ReturnDate,
                    Book = new BookDto
                    {
                        Author = UpdateBorrowedBook.Book.Author,
                        Title = UpdateBorrowedBook.Book.Title,

                    }
                }

            };
        }

        
    }
}
