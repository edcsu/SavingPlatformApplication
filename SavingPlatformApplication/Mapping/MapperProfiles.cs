using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavingPlatformApplication.Data.Models;
using SavingPlatformApplication.ViewModels.AddressViews;
using SavingPlatformApplication.ViewModels.MemberViews;
using SavingPlatformApplication.ViewModels.SavingsGroupViews;

namespace SavingPlatformApplication.Mapping
{
    public static class MapperProfiles
    {
        public static Address MapAddressPostModelToMemberModel(AddressPostModel postModel)
        {
            var model = new Address() {
                Country = postModel.Country,
                StreetName = postModel.StreetName,
                Town = postModel.Town
            };
            return model;
        }
        
        public static Address MapAddressUpdateModelToMemberModel(Guid id, AddressUpdateModel updateModel)
        {
            var model = new Address()
            {
                Id = id,
                Country = updateModel.Country,
                StreetName = updateModel.StreetName,
                Town = updateModel.Town
            };
            return model;
        }
        
        public static AddressViewModel MapAddressModelToAddressViewModel(Address address)
        {
            var viewModel = new AddressViewModel() {
                Id = address.Id,
                Country = address.Country,
                DateCreated = address.DateCreated,
                DateUpdated = address.DateUpdated,
                StreetName = address.StreetName,
                Town = address.Town
            };
            return viewModel;
        }

        public static SavingsGroupViewModel MapSavingsGroupModelToSavingsGroupViewModel(SavingsGroup model)
        {
            var viewModel = new SavingsGroupViewModel()
            {
                Id = model.Id,
                Balance = model.Balance,
                DateCreated = model.DateCreated,
                DateFounded = model.DateFounded,
                DateUpdated = model.DateUpdated,
                Email = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber
            };
            return viewModel;
        }

        public static SavingsGroup MapSavingsGroupPostModelToSavingsGroupModel(SavingsGroupPostModel postModel)
        {
            var model = new SavingsGroup()
            {
                Balance = postModel.Balance,
                DateFounded = postModel.DateFounded,
                Email = postModel.Email,
                FullName = postModel.FullName,
                PhoneNumber = postModel.PhoneNumber,
                Address = new Address
                {
                    Country = postModel.Address.Country,
                    StreetName = postModel.Address.StreetName,
                    Town = postModel.Address.Town
                }
            };
            return model;
        }
        
        public static SavingsGroup MapSavingsGroupUpdateModelToSavingsGroupModel(Guid id, SavingsGroupUpdateModel updateModel)
        {
            var model = new SavingsGroup()
            {
                Id = id,
                Balance = updateModel.Balance,
                DateFounded = updateModel.DateFounded,
                Email = updateModel.Email,
                FullName = updateModel.FullName,
                PhoneNumber = updateModel.PhoneNumber,
                Address = new Address
                {
                    Country = updateModel.Address.Country,
                    StreetName = updateModel.Address.StreetName,
                    Town = updateModel.Address.Town
                }
            };
            return model;
        }

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
        
        public static Member MapMemberUpdateModelToMemberModel(Guid id, MemberUpdateModel updateModel)
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
        
        public static MemberViewModel MapMemberModelToMemberViewModel(Member member)
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
