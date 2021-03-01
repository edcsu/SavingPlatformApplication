using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using SavingPlatformApplication.Data.DatabaseInitializer;
using SavingPlatformApplication.Data.Models;
using SavingPlatformApplication.Mapping;
using SavingPlatformApplication.Repositories.Contracts;
using SavingPlatformApplication.Services.Implementations;
using SavingPlatformApplication.ViewModels;
using SavingPlatformApplication.ViewModels.MemberViews;
using Xunit;

namespace SavingsPlatformApplication.Test.Services
{
    public class IMemberServiceTests
    {
        private readonly Mock<IMemberRepository> _mockMemberRepository;
        private readonly Guid _requestId = Guid.NewGuid();
        private readonly Member _member;
        private readonly List<Member> _memberList;
        private readonly MemberViewModel _viewModel;
        private readonly MemberPostModel _postModel;
        private readonly MemberUpdateModel _updateModel; 
        private readonly MemberService _memberService;
        private readonly SearchRequest _searchRequest = TestHelpers.GetTestSearchRequest();

        public IMemberServiceTests()
        {
            _memberList = GenerateFakeData.GetSampleMembers();

            _member = _memberList[0];

            _viewModel = MapperProfiles.MapMemberModelToMemberViewModel(_memberList[0]);
            _viewModel.Id = _requestId;

            _postModel = new MemberPostModel
            {
                FullName = _viewModel.FullName,
                Balance = _viewModel.Balance,
                BirthDate = _viewModel.BirthDate,
                Email = _viewModel.Email,
                Gender = _viewModel.Gender,
                PhoneNumber = _viewModel.PhoneNumber
            };

            _updateModel = new MemberUpdateModel
            {
                FullName = _viewModel.FullName,
                Balance = _viewModel.Balance,
                BirthDate = _viewModel.BirthDate,
                Email = _viewModel.Email,
                Gender = _viewModel.Gender,
                PhoneNumber = _viewModel.PhoneNumber
            };

            _mockMemberRepository = new Mock<IMemberRepository>();

            _mockMemberRepository.Setup(mr => mr.AddAsync(It.IsAny<Member>(), 
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(_member);

            _mockMemberRepository.Setup(mr => mr.DeleteAsync<Member>(It.IsAny<Guid>(), 
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(_requestId);

            _mockMemberRepository.Setup(mr => mr.ExistsAsync<Member>(It.IsAny<Guid>(), 
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            _mockMemberRepository.Setup(mr => mr.FindAsync<Member>(It.IsAny<Guid>(), 
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(_member);

            _mockMemberRepository.Setup(mr => mr.GetAllAsync<Member>(It.IsAny<CancellationToken>()))
                .ReturnsAsync(_memberList);
            
            _mockMemberRepository.Setup(mr => mr.GetAllPagedListAsync<Member>(It.IsAny<SearchRequest>(), 
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(_memberList);

            _mockMemberRepository.Setup(mr => mr.GetCountAsync<Member>(It.IsAny<CancellationToken>()))
                .ReturnsAsync(_memberList.Count);

            _mockMemberRepository.Setup(mr => mr.UpdateAsync(It.IsAny<Member>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(_member);

            _memberService = new MemberService(_mockMemberRepository.Object);
        }

        [Fact]
        public async Task GetMember_ShouldNotThrowExceptionAsync()
        {
            await _memberService.GetMemberAsync(_requestId);
        }
        
        [Fact]
        public async Task DeleteMember_ShouldNotThrowExceptionAsync()
        {
            await _memberService.DeleteMemberAsync(_requestId);
        }

        [Fact]
        public async Task DeleteMember_ShouldReturnRequestId()
        {
            var result = await _memberService.DeleteMemberAsync(_requestId);

            Assert.IsType<Guid>(result);
        }

        [Fact]
        public async Task DoesMemberExist_ShouldNotThrowExceptionAsync()
        {
            await _memberService.DoesMemberExistAsync(_requestId);
        }

        [Fact]
        public async Task DoesMemberExist_ShouldReturnABoolean()
        {
            var result = await _memberService.DoesMemberExistAsync(_requestId);

            Assert.IsType<bool>(result);
        }

        [Fact]
        public async Task AddMember_ShouldNotThrowExceptionAsync()
        {
            await _memberService.AddMemberAsync(_postModel);
        }

        [Fact]

        public async Task Service_ShouldSaveMember()
        {
            await _memberService.AddMemberAsync(_postModel);

            _mockMemberRepository.Verify(
                mr => mr.AddAsync(
                    It.Is<Member>( y =>
                    y.Balance == _postModel.Balance &&
                    y.BirthDate == _postModel.BirthDate &&
                    y.Email == _postModel.Email &&
                    y.FullName == _postModel.FullName &&
                    y.Gender == _postModel.Gender),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetMembers_ShouldNotThrowExceptionAsync()
        {
            await _memberService.GetMembersAsync();
        }

        [Fact]
        public async Task GetPagedMembers_ShouldNotThrowExceptionAsync()
        {
            await _memberService.GetPagedMembersAsync(_searchRequest);
        }

        [Fact]
        public async Task GetTotalMembersCount_ShouldNotThrowExceptionAsync()
        {
            await _memberService.GetTotalMemberCountAsync();
        }

        [Fact]
        public async Task UpdateMember_ShouldNotThrowExceptionAsync()
        {
            await _memberService.UpdateMemberAsync(_requestId, _updateModel);
        }

        [Fact]
        public async Task Service_ShouldUpdateMember()
        {
            await _memberService.UpdateMemberAsync(_requestId, _updateModel);

            _mockMemberRepository.Verify(
                mr => mr.UpdateAsync(
                   It.Is<Member>(y =>
                   y.Id == _requestId &&
                   y.Balance == _postModel.Balance &&
                   y.BirthDate == _postModel.BirthDate &&
                   y.Email == _postModel.Email &&
                   y.FullName == _postModel.FullName &&
                   y.Gender == _postModel.Gender),
                    It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
