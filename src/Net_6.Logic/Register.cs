using Microsoft.Extensions.DependencyInjection;
using Net_6.Logic.Queries.Implement;
using Net_6.Logic.Queries.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic
{
    public static class Register
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddScoped<IAuthorQueries, AuthorQueries>();
            return services;
        }
    }
}
