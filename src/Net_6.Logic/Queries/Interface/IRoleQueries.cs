using Net_6.Common.Shared.Model;
using Net_6.Logic.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Queries.Interface
{
    public interface IRoleQueries
    {
        BasePagingData<RoleSummaryModel> GetPaging(BaseQuery query);
        List<RoleSummaryModel> GetAll();
        RoleDetailModel? GetDetail(string id);
        Task<RoleDetailModel?> GetDetailAsync(string id);
        Task<BasePagingData<RoleSummaryModel>> GetPagingAsync(BaseQuery query);
        Task<List<RoleSummaryModel>> GetAllAsync();
    }
}
