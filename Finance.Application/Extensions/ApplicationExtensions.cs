using Finance.Application.UseCases.CreateTransaction;
using Finance.Application.UseCases.GetAllTransactions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICreateTransaction, CreateTransaction>();
            services.AddScoped<IGetAllTransactions, GetAllTransactions>();

            return services;
        }

    }
}
