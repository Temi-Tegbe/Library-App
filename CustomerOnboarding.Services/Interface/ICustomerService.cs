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
    public interface ICustomerService
    {
        Task<Response<dynamic>> AddAsync(CustomerRegistrationDTO customer, ApplicationUser userInfo);
        Task<Response<dynamic>> Login(CustomerLoginDTO login);
    }
}
