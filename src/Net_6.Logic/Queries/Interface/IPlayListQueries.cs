using Net_6.Common.Shared.Model;
using Net_6.Logic.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Queries.Interface
{
    public interface IPlayListQueries
    {
        BasePagingData<PlayListSummaryModel> GetPaging(BaseQuery query);
        List<PlayListSummaryModel> GetAll();
        PlayListDetailModel? GetDetail(int id);
        Task<PlayListDetailModel?> GetDetailAsync(int id);
        Task<BasePagingData<PlayListSummaryModel>> GetPagingAsync(BaseQuery query);
        Task<List<PlayListSummaryModel>> GetAllAsync();
    }
}
