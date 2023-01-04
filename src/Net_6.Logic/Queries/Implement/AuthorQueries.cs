using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Net_6.Common.Shared.Model;
using Net_6.Database;
using Net_6.Logic.Queries.Interface;
using Net_6.Logic.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Queries.Implement
{
    public class AuthorQueries : IAuthorQueries
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public AuthorQueries(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public List<AuthorSummaryModel> GetAll()
        {
            return database.Authors.Select(x => mapper.Map<AuthorSummaryModel>(x)).ToList();
        }

        public Task<List<AuthorSummaryModel>> GetAllAsync()
        {
            return database.Authors.Select(x => mapper.Map<AuthorSummaryModel>(x)).ToListAsync();
        }

        public AuthorDetailModel? GetDetail(int id)
        {
            var author = database.Authors.FirstOrDefault(x => x.Id == id);
            if (author != null)
            {
                var result = mapper.Map<AuthorDetailModel>(author);
                var posts = database.Post.Where(x => x.AuthorId == id);

                result.Posts = posts.ToList();
                return result;
            }
            return null;
        }

        public Task<AuthorDetailModel?> GetDetailAsync(int id)
        {
            var author = database.Authors.FirstOrDefault(x => x.Id == id);
            AuthorDetailModel? result = null;
            if (author != null)
            {
                result = mapper.Map<AuthorDetailModel>(author);
                var posts = database.Post.Where(x => x.AuthorId == id);

                result.Posts = posts.ToList();
                return Task.FromResult(result ?? null);
            }
            return Task.FromResult(result);
        }

        public BasePagingData<AuthorSummaryModel> GetPaging(BaseQuery query)
        {
            var authors = database.Authors
                .Where(x => x.FullName!.Contains(query.Keywords ?? string.Empty) ||
                            x.ShortName!.Contains(query.Keywords ?? string.Empty) ||
                            x.Phone!.Contains(query.Keywords ?? string.Empty) ||
                            x.Email!.Contains(query.Keywords ?? string.Empty))
                .Skip((query.PageIndex - 1) * query.PageSize ?? 0)
                .Take((query.PageSize * query.PageIndex) ?? 20)
                .Select(x => mapper.Map<AuthorSummaryModel>(x))
                .ToList();

            var authorCount = database.Authors.Count();

            return new BasePagingData<AuthorSummaryModel>()
            {
                Items = authors,
                PageSize = query.PageSize ?? 1,
                PageIndex = query.PageIndex ?? 20,
                TotalItem = authorCount,
                TotalPage = (int)Math.Ceiling((double)authorCount / query.PageSize ?? 20)
            };
        }

        public Task<BasePagingData<AuthorSummaryModel>> GetPagingAsync(BaseQuery query)
        {
            var authors = database.Authors
                .Where(x => x.FullName!.Contains(query.Keywords ?? string.Empty) ||
                            x.ShortName!.Contains(query.Keywords ?? string.Empty) ||
                            x.Phone!.Contains(query.Keywords ?? string.Empty) ||
                            x.Email!.Contains(query.Keywords ?? string.Empty))
                .Skip((query.PageIndex - 1) * query.PageSize ?? 0)
                .Take((query.PageSize * query.PageIndex) ?? 20)
                .Select(x => mapper.Map<AuthorSummaryModel>(x))
                .ToList();

            var authorCount = database.Authors.Count();

            return Task.FromResult(new BasePagingData<AuthorSummaryModel>()
            {
                Items = authors,
                PageSize = query.PageSize ?? 1,
                PageIndex = query.PageIndex ?? 20,
                TotalItem = authorCount,
                TotalPage = (int)Math.Ceiling((double)authorCount / query.PageSize ?? 20)
            });
        }
    }
}
