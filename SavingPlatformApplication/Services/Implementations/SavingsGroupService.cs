using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavingPlatformApplication.Core.Exceptions;
using SavingPlatformApplication.Data.Models;
using SavingPlatformApplication.Mapping;
using SavingPlatformApplication.Repositories.Contracts;
using SavingPlatformApplication.Services.Contracts;
using SavingPlatformApplication.ViewModels;
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

        public async Task<SavingsGroupSearchResponse> GetPagedSavingsGroupAsync(SearchRequest searchRequest)
        {
            var savingsGroupViewList = new List<SavingsGroupViewModel>();

            var savingsGroupList = await _savingsGroupRepository.GetAllPagedListAsync<SavingsGroup>(searchRequest);
            foreach (var savingsGroup in savingsGroupList)
            {
                var viewModel = MapperProfiles.MapSavingsGroupModelToSavingsGroupViewModel(savingsGroup);
                savingsGroupViewList.Add(viewModel);
            }
            return new SavingsGroupSearchResponse
            {
                SavingsGroupList = savingsGroupViewList,
                Pagination = new SearchPagination
                {
                    ItemsPerPage = searchRequest.Pagination.ItemsPerPage,
                    Page = searchRequest.Pagination.Page,
                    TotalItems = await _savingsGroupRepository.GetCountAsync<SavingsGroup>()
                },
            };
        }

        public async Task<SavingsGroupViewModel> GetSavingsGroupAsync(Guid id)
        {
            var savingsGroup = await _savingsGroupRepository.FindAsync<SavingsGroup>(id);
            if (savingsGroup == null)
            {
                throw new NotFoundException($"Failed to find savingsgroup with Id: {id}");
            }

            return MapperProfiles.MapSavingsGroupModelToSavingsGroupViewModel(savingsGroup);
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

            var member = await _savingsGroupRepository.UpdateAsync(model);
            return MapperProfiles.MapSavingsGroupModelToSavingsGroupViewModel(member);
        }
    }
}
