using CustomerOnboarding.Domain.Model;
using CustomerOnboarding.Domain.Model.DTO;
using CustomerOnboarding.Helpers;
using CustomerOnboarding.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace NEWCustomerOnboarding.Controllers
{
  
        [Route("api/[controller]")]
        [ApiController]

        public class BookController : ControllerBase
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly RoleManager<ApplicationRole> _roleManager;
            private readonly IConfiguration _configuration;
            private readonly ICustomerService _customerService;
            private readonly AppDbContext _context;
            private readonly Audit _audit;
            private readonly IBookService _bookService;

            public BookController(IConfiguration configuration, ICustomerService customerService, AppDbContext context, Audit audit, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IBookService bookService)
            {
                _configuration = configuration;
                _customerService = customerService;
                _context = context;
                _audit = audit;
                _userManager = userManager;
                _roleManager = roleManager;
                _bookService = bookService;
            }


        [HttpPost]
        [Route("Add-new-book")]
        public async Task<Response<dynamic>> AddBook(AddBooksDTO books)
        {
            var addBooks = await _bookService.AddBooks(books);
            if (addBooks != null)
            {
                return Response<dynamic>.Send(true, "Book Added Succesfully", System.Net.HttpStatusCode.OK, addBooks);
            }
            return Response<dynamic>.Send(false, "Faled", System.Net.HttpStatusCode.InternalServerError);
            
        }

        [HttpPost]
        [Route("Get-All-Books")]
        public async Task <PagedQueryResult<Books>> GetAllBooks(PagedQueryRequest request)
        {
            var allBooks = await _bookService.GetAllBooks(request);
            if (allBooks != null)
            {
                return allBooks;
            }
            return null;
        }


        [HttpGet]
        [Route("Get-Book-by-Id")]
        public async Task <IActionResult> GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            return Ok(book);
        }

        [HttpPatch]
        [Route("Edit-Book-Details")]
        public async Task<IActionResult> EditBookDetails(int id, EditBookDTO editBookDTO)
        {
            var editBook = _bookService.EditBookDetails(id, editBookDTO);
            return Ok(editBook);
        }

        [HttpPost]
        [Route("Borrow-Book")]

        public async Task<IActionResult> BorrowBook(int bookId, BorrowBookDTO borrowBookDTO)
        {
            var borrowBook = _bookService.BorrowBook(bookId, borrowBookDTO);
            return Ok(borrowBook);

        }


        [HttpPost]
        [Route("Return-Book")]
        public async Task<IActionResult> ReturnBook(int bookId)
        {
            var borrowBook = _bookService.ReturnBook(bookId);
            return Ok(borrowBook);

        }

        [HttpPost]
        [Route("Pay-Oustanding-Balance")]
        public async Task<IActionResult> PayOutstandingBalnce(long customerId, decimal balance)
        {
            var payBalance = _bookService.PayOutstandingBalance(balance, customerId );
            return Ok(payBalance);

        }
    }
}
