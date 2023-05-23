using Finance.Domain.Interfaces;
using Finance.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.Extensions
{
    public static class InfraExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITransactionRepository, TransactionRepository>();

            return services;
        }

    }
}
