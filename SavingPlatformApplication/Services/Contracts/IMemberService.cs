using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavingPlatformApplication.Data.Models;

namespace SavingPlatformApplication.Services.Contracts
{
    public interface IMemberService
    {
        Task<List<Member>> GetMembersAsync();
        
        Task<Member> GetMemberAsync();
        
        Task<Member> GetTotalMemberCountAsync();
        
        Task<Member> DoesMemberExistAsync();

        Task<Member> AddMemberAsync();

        Task<Member> FindMemberAsync();

        Task<Member> UpdateMemberAsync();

        Task<Member> DeleteMemberAsync();

    }
}
