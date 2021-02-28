using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavingPlatformApplication.Data.Models;
using SavingPlatformApplication.ViewModels.MemberViews;

namespace SavingPlatformApplication.Services.Contracts
{
    public interface IMemberService
    {
        Task<List<Member>> GetMembersAsync();
        
        Task<MemberViewModel> GetMemberAsync(Guid id);
        
        Task<int> GetTotalMemberCountAsync();
        
        Task<Member> DoesMemberExistAsync();

        Task<MemberViewModel> AddMemberAsync(MemberPostModel postModel);

        Task<Member> FindMemberAsync();

        Task<Member> UpdateMemberAsync();

        Task<Member> DeleteMemberAsync();

    }
}
