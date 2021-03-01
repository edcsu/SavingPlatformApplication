using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavingPlatformApplication.Data.Models;
using SavingPlatformApplication.ViewModels;
using SavingPlatformApplication.ViewModels.SavingsGroupViews;

namespace SavingPlatformApplication.Services.Contracts
{
    public interface ISavingsGroupService
    {
        Task<List<SavingsGroup>> GetSavingsGroupsAsync();
        Task<SavingsGroupSearchResponse> GetPagedSavingsGroupAsync(SearchRequest searchRequest);

        Task<SavingsGroupViewModel> GetSavingsGroupAsync(Guid id);
        
        Task<int> GetTotalSavingsGroupCountAsync();
        
        Task<bool> DoesSavingsGroupExistAsync(Guid id);

        Task<SavingsGroupViewModel> AddSavingsGroupAsync(SavingsGroupPostModel postModel);

        Task<SavingsGroupViewModel> UpdateSavingsGroupAsync(Guid id, SavingsGroupUpdateModel updateModel);

        Task<Guid> DeleteSavingsGroupAsync(Guid id);

    }
}
