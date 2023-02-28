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
            services.AddScoped<ICategoryQueries, CategoryQueries>();
            services.AddScoped<IPostQueries, PostQueries>();
            services.AddScoped<ICommentQueries, CommentQueries>();
            services.AddScoped<IPlayListQueries, PlayListQueries>();
            services.AddScoped<IRoleQueries, RoleQueries>();
            services.AddScoped<ITagQueries, TagQueries>();
            services.AddScoped<IUserQueries, UserQueries>();
            services.AddScoped<IVideoQueries, VideoQueries>();

            return services;
        }
    }
}
