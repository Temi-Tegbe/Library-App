using CustomerOnboarding.Domain.Model;
using CustomerOnboarding.Helpers;
using CustomerOnboarding.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarding.Services.Service
{
    public class LendingHistoryService : ILendingHistoryService
    {
        private readonly AppDbContext _context;

        public LendingHistoryService(AppDbContext context)
        {
            _context = context;
        }



        public async Task<PagedQueryResult<LendingHistory>> GetLendingHistory(PagedQueryRequest request)
        {
            try
            {
                var lendingHistory = _context.LendingHistory.OrderByDescending(x => x.Date);
                return lendingHistory.ToPagedResult(request.PageNumber, request.PageSize);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PagedQueryResult<LendingHistory>> GetCustomerLendingHistory(PagedQueryRequest request, long customerId)
        {
            try
            {
                var getCustomerLendingHistory = _context.LendingHistory.Where(x => x.Customer.CustomerId == customerId);
                return getCustomerLendingHistory.ToPagedResult(request.PageNumber, request.PageSize);
            }
            catch (Exception)
            {

                throw;
            }
        }




    }
}
