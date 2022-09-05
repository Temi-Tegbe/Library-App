using CustomerOnboarding.Domain.Model;
using CustomerOnboarding.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarding.Services.Interface
{
    public interface ILendingHistoryService
    {
        Task<PagedQueryResult<LendingHistory>> GetLendingHistory(PagedQueryRequest request);
        Task<PagedQueryResult<LendingHistory>> GetCustomerLendingHistory(PagedQueryRequest request, long customerId);
    }
}
