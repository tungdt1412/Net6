using Net_6.Common.Shared.Model;
using Net_6.Logic.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Queries.Interface
{
    public interface ITagQueries
    {
        BasePagingData<TagSummaryModel> GetPaging(BaseQuery query);
        List<TagSummaryModel> GetAll();
        List<TagSummaryModel> GetByPostId(int postId);
        TagDetailModel? GetDetail(int id);
        Task<TagDetailModel?> GetDetailAsync(int id);
        Task<BasePagingData<TagSummaryModel>> GetPagingAsync(BaseQuery query);
        Task<List<TagSummaryModel>> GetAllAsync();
    }
}
