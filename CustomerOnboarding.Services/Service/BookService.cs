using CustomerOnboarding.Domain.Model;
using CustomerOnboarding.Domain.Model.DTO;
using CustomerOnboarding.Helpers;
using CustomerOnboarding.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarding.Services.Service
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Response<dynamic>> AddBooks(AddBooksDTO books)
        {
            var newBook = Utilities.MapTo<Books>(books);
            newBook.DateAdded = DateTime.Now;
            newBook.DateModified = DateTime.Now;
            newBook.IsBorrowed = false;
            await _context.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return Response<dynamic>.Send(true, "Book Added Succesfully");
        }
        public async Task<PagedQueryResult<Books>> GetAllBooks(PagedQueryRequest request)
        {
            try
            {
                var allBooks = _context.Books.OrderByDescending(x => x.DateAdded);
                return allBooks.ToPagedResult(request.PageNumber, request.PageSize);
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public async Task<Books> GetBookById(int Id)
        {
            try
            {
                var book = _context.Books.Where(X => X.BookId == Id).FirstOrDefault();
                return book;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response<dynamic>> EditBookDetails(int id, EditBookDTO editBookDTO)
        {
            try
            {
                var findBook = _context.Books.Where(x => x.BookId == id).FirstOrDefault();
                if (findBook != null)
                {
                   findBook.Name = editBookDTO.Name;
                    findBook.Description = editBookDTO.Description;
                    findBook.Author = editBookDTO.Author;
                    var update = _context.Entry(findBook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Response<dynamic>.Send(true, "Book succesfully borrowed", HttpStatusCode.OK);
                }
                else
                {
                    return Response<dynamic>.Send(false, "An error has occured", HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response<dynamic>> PayOutstandingBalance(decimal balance, long customerId)
        {
            try
            {


                var findCustomer = _context.Customers.Where(x => x.CustomerId == customerId).FirstOrDefault();
                var pay = findCustomer.OutstandingBalance - balance;
                var update = _context.Entry(findCustomer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return Response<dynamic>.Send(true, "Oustanding balance paid successfully");


            }
            catch (Exception)
            {

                throw;
            }

        }
        
        public async Task<Response<dynamic>> ReturnBook(int bookId)
        {
            try
            {
                var findBook = _context.Books.Where(x => x.BookId == bookId).FirstOrDefault();
                if (findBook != null)
                {
                    if (findBook.ExpectedReturnDate > DateTime.Now)
                    {

                        var dayDifference = GetBusinessDays(findBook.ExpectedReturnDate.Value, DateTime.Now);
                         decimal amountowed = (decimal)(dayDifference * 5000);
                        findBook.IsBorrowed = false;
                        findBook.BorrowedBy = null;
                        findBook.BorrowDate = null;
                        findBook.ExpectedReturnDate = null;
                        findBook.Customer.OutstandingBalance = amountowed;
                        var updated = _context.Entry(findBook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _context.SaveChangesAsync();
                        return Response<dynamic>.Send(true, "Book returned successfully");
                    }

                    findBook.IsBorrowed = false;
                    findBook.BorrowedBy = null;
                    findBook.BorrowDate = null;
                    findBook.ExpectedReturnDate = null;
                    var update = _context.Entry(findBook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Response<dynamic>.Send(true, "Book returned successfully");

                }
                return Response<dynamic>.Send(false, "An error has occured");
            }
            catch (Exception)
            {

                throw;
            }
        }
            
        public async Task<Response<dynamic>> BorrowBook (int bookId, BorrowBookDTO borrowBookDTO)
        {
            try
            {
                var firstFindBook = _context.Books.Where(x => x.BookId == bookId).FirstOrDefault();
                if (firstFindBook != null)
                {
                    firstFindBook.IsBorrowed = true;
                    firstFindBook.BorrowedBy = borrowBookDTO.BorrowedBy;
                    firstFindBook.BorrowDate = DateTime.Now;
                    firstFindBook.ExpectedReturnDate = DateTime.Now.AddDays(14);
                    var update = _context.Entry(firstFindBook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Response<dynamic>.Send(true, "Book succesfully borrowed", HttpStatusCode.OK);
                }
                return Response<dynamic>.Send(false, "An error has occured", HttpStatusCode.InternalServerError);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static double GetBusinessDays(DateTime startD, DateTime endD)
        {
            double calcBusinessDays =
                1 + ((endD - startD).TotalDays * 5 -
                (startD.DayOfWeek - endD.DayOfWeek) * 2) / 7;

            if (endD.DayOfWeek == DayOfWeek.Saturday) calcBusinessDays--;
            if (startD.DayOfWeek == DayOfWeek.Sunday) calcBusinessDays--;

            return calcBusinessDays;
        }

    }
}
