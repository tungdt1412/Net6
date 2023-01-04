using Net_6.Common.Shared.Model;
using Net_6.Logic.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Queries.Interface
{
    public interface ICategoryQueries
    {
        BasePagingData<CategorySummaryModel> GetPaging(BaseQuery query);
        List<CategorySummaryModel> GetAll();
        CategoryDetailModel? GetDetail(int id);
        Task<CategoryDetailModel?> GetDetailAsync(int id);
        Task<BasePagingData<CategorySummaryModel>> GetPagingAsync(BaseQuery query);
        Task<List<CategorySummaryModel>> GetAllAsync();
    }
}
