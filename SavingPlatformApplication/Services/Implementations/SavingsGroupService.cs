using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavingPlatformApplication.Data.Models;
using SavingPlatformApplication.Mapping;
using SavingPlatformApplication.Repositories.Contracts;
using SavingPlatformApplication.Services.Contracts;
using SavingPlatformApplication.ViewModels.SavingsGroupViews;

namespace SavingPlatformApplication.Services.Implementations
{
    public class SavingsGroupService : ISavingsGroupService
    {
        private readonly ISavingsGroupRepository _savingsGroupRepository;

        public SavingsGroupService(ISavingsGroupRepository savingsGroupRepository)
        {
            _savingsGroupRepository = savingsGroupRepository;
        }

        public async Task<SavingsGroupViewModel> AddSavingsGroupAsync(SavingsGroupPostModel postModel)
        {
            var model = MapperProfiles.MapSavingsGroupPostModelToSavingsGroupModel(postModel);

            var member = await _savingsGroupRepository.AddAsync(model);
            return MapperProfiles.MapSavingsGroupModelToSavingsGroupViewModel(member);
        }

        public async Task<Guid> DeleteSavingsGroupAsync(Guid id)
        {
            return await _savingsGroupRepository.DeleteAsync<SavingsGroup>(id);
        }

        public async Task<bool> DoesSavingsGroupExistAsync(Guid id)
        {
            return await _savingsGroupRepository.ExistsAsync<SavingsGroup>(id);
        }

        public async Task<SavingsGroup> GetSavingsGroupAsync(Guid id)
        {
            return await _savingsGroupRepository.FindAsync<SavingsGroup>(id);
        }

        public async Task<List<SavingsGroup>> GetSavingsGroupsAsync()
        {
            return await _savingsGroupRepository.GetAllAsync<SavingsGroup>();
        }

        public async Task<int> GetTotalSavingsGroupCountAsync()
        {
            return await _savingsGroupRepository.GetCountAsync<SavingsGroup>();
        }

        public async Task<SavingsGroupViewModel> UpdateSavingsGroupAsync(Guid id, SavingsGroupUpdateModel updateModel)
        {
            var model = MapperProfiles.MapSavingsGroupUpdateModelToSavingsGroupModel(id, updateModel);

            var member = await _savingsGroupRepository.AddAsync(model);
            return MapperProfiles.MapSavingsGroupModelToSavingsGroupViewModel(member);
        }
    }
}
