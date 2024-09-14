using LibraryManagementSystem.Dto;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interface.Repository;
using LibraryManagementSystem.Interface.Service;
using System.Net;

namespace LibraryManagementSystem.Implementation.Service
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationsRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public ReservationService(IReservationRepository reservationsRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            _reservationsRepository = reservationsRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public async Task<BaseResponse<ReservationDto>> AddReservation(CreateReservationRequestModel model)
        {
            var user = await _userRepository.Get(model.UserId);
            var book = await _bookRepository.Get(model.BookId);
            if(user == null) 
            {
                return new BaseResponse<ReservationDto>
                {
                    Mesage = "User not found",
                    Status = false
                };
            }
            if(book == null)
            {
                return new BaseResponse<ReservationDto>
                {
                    Mesage = "Book not found",
                    Status = false
                };
            }
            var reserveBook = new Reservation
            {
                BookId = model.BookId,
                UserId = model.UserId,
                ReservationDate = DateTime.Now,
                ReservationStatus = Enum.ReservationStatus.Pending,
                Book = model.Book
            };

            await _reservationsRepository.CreateAsync(reserveBook);
            
            reserveBook.ReservationStatus = Enum.ReservationStatus.Confirmed;
            await _reservationsRepository.Update(reserveBook);
            await _reservationsRepository.SaveAsync();

            return new BaseResponse<ReservationDto>
            {
                Mesage = "Book Reserved ",
                Status = true,
                Data = new ReservationDto
                {
                    ReservationStatus = Enum.ReservationStatus.Confirmed,
                    BookId = model.BookId,
                    UserId = model.UserId,
                    Book = new BookDto
                    {
                        Author = book.Author,
                        Title = model.Book.Title
                    },
                   ReservationDate = DateTime.Now,
                }
            };

        }

        public async Task<BaseResponse<ReservationDto>> Delete(string id)
        {
            var reserve = await _reservationsRepository.Get(b => b.Id == id);
            if (reserve is null)
            {
                return new BaseResponse<ReservationDto>
                {
                    Status = false,
                    Mesage = "Reservation Not Found"
                };
            }
            await _reservationsRepository.Delete(reserve);
            return new BaseResponse<ReservationDto>
            {
                Status = true,
                Mesage = "Reservation successfully deleted",
                Data = new ReservationDto
                {
                    ReservationStatus = Enum.ReservationStatus.Canceled,
                    ReservationDate= DateTime.Now,

                }
            };
        }

        public async Task<BaseResponse<ICollection<ReservationDto>>> GetAll()
        {
            var getAll = await _reservationsRepository.GetAll();
            if(getAll is null)
            {
                return new BaseResponse<ICollection<ReservationDto>>
                {
                    Status = false,
                    Mesage = " Not Found"
                };
            }
            return new BaseResponse<ICollection<ReservationDto>>
            {
                Status = true,
                Mesage = " Success",
                Data = getAll.Select(n => new ReservationDto
                {
                    ReservationStatus = n.ReservationStatus,
                }).ToList()
                
            };
        }

        public async Task<BaseResponse<ReservationDto>> GetByDate(DateTime date)
        {
            var getAReserve = await _reservationsRepository.Get(d => d.ReservationDate == date);
            if (getAReserve is null)
            {
                return new BaseResponse<ReservationDto>
                {
                    Mesage = $"{getAReserve.Id} does not exist",
                    Status = false,
                };
            }
            return new BaseResponse<ReservationDto>
            {
                Mesage = $"Book with the particular {getAReserve.Id} Available",
                Status = true,
                Data = new ReservationDto
                {
                    ReservationDate = DateTime.Now
                }

            };
        }

        public async Task<BaseResponse<ReservationDto>> Update(string id, UpdateReservationRequestModel model)
        {
            var updateReserve = await _reservationsRepository.Get(id);
            if(updateReserve is null)
            {
                return new BaseResponse<ReservationDto>
                {
                    Status = false,
                    Mesage = "Reservation record not found "
                };
            }
            
            updateReserve.Id = id;
            updateReserve.ReservationDate = DateTime.Now;
            updateReserve.BookId = model.BookId;
            await _reservationsRepository.Update(updateReserve);
            await _reservationsRepository.SaveAsync();

            return new BaseResponse<ReservationDto>
            {
                Status = true,
                Mesage = "Reservation Updated Successfully",
                Data = new ReservationDto
                {
                    ReservationDate = DateTime.Now,
                    BookId = model.BookId,
                    UserId = model.UserId
                }
            };
        }
    }
}
