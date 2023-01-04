using Net_6.Common.Shared.Model;
using Net_6.Logic.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Queries.Interface
{
    public interface IUserQueries
    {
        BasePagingData<UserSummaryModel> GetPaging(BaseQuery query);
        List<UserSummaryModel> GetAll();
        UserDetailModel? GetDetail(string userName);
        Task<UserDetailModel?> GetDetailAsync(string userName);
        Task<BasePagingData<UserSummaryModel>> GetPagingAsync(BaseQuery query);
        Task<List<UserSummaryModel>> GetAllAsync();
        bool IsExistUserName(string userName);
    }
}
