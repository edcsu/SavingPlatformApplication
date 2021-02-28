using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavingPlatformApplication.Data.Models;
using SavingPlatformApplication.ViewModels.MemberViews;

namespace SavingPlatformApplication.Mapping
{
    public static class MapperProfiles
    {
        public static Member MapMemberPostModeltoMemberModel(MemberPostModel postModel)
        {
            var model = new Member() {
                Email = postModel.Email,
                Balance = postModel.Balance,
                BirthDate = postModel.BirthDate,
                FullName = postModel.FullName,
                Gender = postModel.Gender,
                PhoneNumber = postModel.PhoneNumber
            };
            return model;
        }
        
        public static Member MapMemberUpdateModeltoMemberModel(Guid id, MemberUpdateModel updateModel)
        {
            var model = new Member() {
                Id = id,
                Email = updateModel.Email,
                Balance = updateModel.Balance,
                BirthDate = updateModel.BirthDate,
                DateUpdated = DateTime.UtcNow,
                FullName = updateModel.FullName,
                Gender = updateModel.Gender,
                PhoneNumber = updateModel.PhoneNumber
            };
            return model;
        }
        
        public static MemberViewModel MapMemberModeltoMemberViewModel(Member member)
        {
            var viewModel = new MemberViewModel() {
                Id = member.Id,
                Email = member.Email,
                Balance = member.Balance,
                BirthDate = member.BirthDate,
                DateCreated = member.DateCreated,
                DateUpdated = member.DateUpdated,
                FullName = member.FullName,
                Gender = member.Gender,
                PhoneNumber = member.PhoneNumber
            };
            return viewModel;
        }
    }
}
