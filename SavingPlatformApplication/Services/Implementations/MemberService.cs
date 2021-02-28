using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavingPlatformApplication.Data.Models;
using SavingPlatformApplication.Repositories.Contracts;
using SavingPlatformApplication.Services.Contracts;

namespace SavingPlatformApplication.Services.Implementations
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public Task<Member> AddMemberAsync()
        {
            throw new NotImplementedException();
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

        public Task<Member> GetMemberAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Member>> GetMembersAsync()
        {
            return _memberRepository.GetAllAsync<Member>();
        }

        public Task<Member> GetTotalMemberCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Member> UpdateMemberAsync()
        {
            throw new NotImplementedException();
        }
    }
}
