using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavingPlatformApplication.Data.Models;
using SavingPlatformApplication.Mapping;
using SavingPlatformApplication.Repositories.Contracts;
using SavingPlatformApplication.Services.Contracts;
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
            return MapperProfiles.MapMemberModeltoMemberViewModel(member);
        }

        public Task<Member> DeleteMemberAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Member> DoesMemberExistAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Member> FindMemberAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<MemberViewModel> GetMemberAsync(Guid id)
        {
            var member = await _memberRepository.FindAsync<Member>(id);
            return MapperProfiles.MapMemberModeltoMemberViewModel(member);
        }

        public async Task<List<Member>> GetMembersAsync()
        {
            return await _memberRepository.GetAllAsync<Member>();
        }

        public async Task<int> GetTotalMemberCountAsync()
        {
            return await _memberRepository.GetCountAsync<Member>();
        }

        public Task<Member> UpdateMemberAsync()
        {
            throw new NotImplementedException();
        }
    }
}
