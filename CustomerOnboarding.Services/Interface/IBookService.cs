using CustomerOnboarding.Domain.Model;
using CustomerOnboarding.Domain.Model.DTO;
using CustomerOnboarding.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarding.Services.Interface
{
    public interface IBookService
    {
        Task<Response<dynamic>> AddBooks(AddBooksDTO books);
        Task<PagedQueryResult<Books>> GetAllBooks(PagedQueryRequest request);
        Task<Books> GetBookById(int Id);
        Task<Response<dynamic>> EditBookDetails(int id, EditBookDTO editBookDTO);
        Task<Response<dynamic>> BorrowBook(int bookId, BorrowBookDTO borrowBookDTO);
        Task<Response<dynamic>> ReturnBook(int bookId);
        Task<Response<dynamic>> PayOutstandingBalance(decimal balance, long customerId);

    }
}
