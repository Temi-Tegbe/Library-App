using CustomerOnboarding.Domain.Model;
using CustomerOnboarding.Helpers;
using CustomerOnboarding.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NEWCustomerOnboarding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

  
    public class LendingHistoryController: ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILendingHistoryService _lendingHistoryService;

        public LendingHistoryController(AppDbContext context, ILendingHistoryService lendingHistoryService)
        {
            _context = context;
            _lendingHistoryService = lendingHistoryService;
        }

        [HttpPost]
        [Route("Get-Lending-History")]
        public async Task <PagedQueryResult<LendingHistory>> GetLendingHistory(PagedQueryRequest request)
        {
            var getLendingHistory = await _lendingHistoryService.GetLendingHistory(request);
            return getLendingHistory;
        }

        [HttpPost]
        [Route("Get-Customer-Lending-History")]
        public async Task<PagedQueryResult<LendingHistory>> CustomerLendingHistory(PagedQueryRequest request, long customerId)
        {
            var getCustomerLendingHistory = await _lendingHistoryService.GetCustomerLendingHistory(request, customerId);
            return getCustomerLendingHistory;
        }
    }
}
