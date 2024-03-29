﻿using CustomerOnboarding.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarding.Services.Service
{
    public static class CustomerOnboardingStartupMock
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ILendingHistoryService, LendingHistoryService>();
            //optionsBuilder.UseSqlServer("Server=10.0.41.101; Database=SpectaCreditCardDb; User=sa; Password=tylent; Connection Timeout=30;");
        }
    }
}
