using Net_6.Common.Shared.Model;
using Net_6.Logic.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Queries.Interface
{
    public interface IPostQueries
    {
        BasePagingData<PostSummaryModel> GetPaging(BaseQuery query);
        List<PostSummaryModel> GetAll();
        PostDetailModel? GetDetail(int id);
        Task<PostDetailModel?> GetDetailAsync(int id);
        Task<BasePagingData<PostSummaryModel>> GetPagingAsync(BaseQuery query);
        Task<List<PostSummaryModel>> GetAllAsync();
    }
}
