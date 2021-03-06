﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavingPlatformApplication.Core.Exceptions;
using SavingPlatformApplication.Data.Models;
using SavingPlatformApplication.Mapping;
using SavingPlatformApplication.Repositories.Contracts;
using SavingPlatformApplication.Services.Contracts;
using SavingPlatformApplication.ViewModels;
using SavingPlatformApplication.ViewModels.MemberViews;

namespace SavingPlatformApplication.Services.Implementations
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<MemberViewModel> AddMemberAsync(MemberPostModel postModel)
        {
            var model = MapperProfiles.MapMemberPostModeltoMemberModel(postModel);

            var member = await _memberRepository.AddAsync(model);
            return MapperProfiles.MapMemberModelToMemberViewModel(member);
        }

        public async Task<Guid> DeleteMemberAsync(Guid id)
        {
            return await _memberRepository.DeleteAsync<Member>(id);
        }

        public async Task<bool> DoesMemberExistAsync(Guid id)
        {
            return await _memberRepository.ExistsAsync<Member>(id);
        }

        public async Task<MemberViewModel> GetMemberAsync(Guid id)
        {
            var member = await _memberRepository.FindAsync<Member>(id);
            if (member == null)
            {
                throw new NotFoundException($"Failed to find a member with Id: {id}");
            }

            return MapperProfiles.MapMemberModelToMemberViewModel(member);
        }

        public async Task<List<Member>> GetMembersAsync()
        {
            return await _memberRepository.GetAllAsync<Member>();
        }

        public async Task<MemberSearchResponse> GetPagedMembersAsync(SearchRequest searchRequest)
        {

            var memberViewList = new List<MemberViewModel>();

            var memberList = await _memberRepository.GetAllPagedListAsync<Member>(searchRequest);
            foreach (var member in memberList)
            {
                var viewModel = MapperProfiles.MapMemberModelToMemberViewModel(member);
                memberViewList.Add(viewModel);
            }
            return new MemberSearchResponse{
                MembersList =  memberViewList,
                Pagination = new SearchPagination
                {
                    ItemsPerPage = searchRequest.Pagination.ItemsPerPage,
                    Page = searchRequest.Pagination.Page,
                    TotalItems = await _memberRepository.GetCountAsync<Member>()
                },
            };
        }

        public async Task<int> GetTotalMemberCountAsync()
        {
            return await _memberRepository.GetCountAsync<Member>();
        }

        public async Task<MemberViewModel> UpdateMemberAsync(Guid id, MemberUpdateModel updateModel)
        {
            var model = MapperProfiles.MapMemberUpdateModelToMemberModel(id, updateModel);

            var member = await _memberRepository.UpdateAsync(model);
            return MapperProfiles.MapMemberModelToMemberViewModel(member);
        }
    }
}
