using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SavingPlatformApplication.Controllers;
using SavingPlatformApplication.Data.DatabaseInitializer;
using SavingPlatformApplication.Data.Models;
using SavingPlatformApplication.Mapping;
using SavingPlatformApplication.Services.Contracts;
using SavingPlatformApplication.ViewModels;
using SavingPlatformApplication.ViewModels.MemberViews;
using Xunit;
using Xunit.Abstractions;

namespace SavingsPlatformApplication.Test.Controllers
{
    public class MembersControllerTests
    {
        private readonly Mock<IMemberService> _memberServiceMock;
        private readonly Guid _requestId = Guid.NewGuid();
        private readonly List<Member> _memberList;
        private readonly List<MemberViewModel> _viewModelList;
        private readonly MemberViewModel _viewModel;
        private readonly MembersController _controller;
        private readonly SearchRequest _searchRequest = TestHelpers.GetTestSearchRequest();
        private readonly MemberSearchResponse _searchResponse;

        public MembersControllerTests(ITestOutputHelper testOutputHelper)
        {
            _memberServiceMock = new Mock<IMemberService>();

            _memberList = GenerateFakeData.GetSampleMembers();

            _viewModel = MapperProfiles.MapMemberModelToMemberViewModel(_memberList[0]);
            _viewModel.Id = _requestId;

            _viewModelList = new List<MemberViewModel>() 
            { 
                _viewModel
            };

            _searchResponse = TestHelpers.GetTestMemberSearchResponseResults();

            _controller = new MembersController(_memberServiceMock.Object) { };

            _memberServiceMock.Setup(x => x.GetMemberAsync(It.IsAny<Guid>()))
                .ReturnsAsync(_viewModel);
            
            _memberServiceMock.Setup(x => x.GetPagedMembersAsync(It.IsAny<SearchRequest>()))
                .ReturnsAsync(_searchResponse);
        }

        [Fact]
        public async Task GetAsync_ShouldNotThrowExceptionAsync()
        {
            await _controller.GetAsync(_requestId);
        }

        [Fact]
        public async Task GetAsync_ShouldCallService()
        {
            await _controller.GetAsync(_requestId);

            _memberServiceMock.Verify(x => 
                x.GetMemberAsync(
                    It.Is<Guid>(y => 
                    y == _requestId)), Times.Once);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResponseAndValidStatus()
        {
            var response = await _controller.GetAsync(_requestId);

            Assert.NotNull(response);
            Assert.IsType<MemberViewModel>(response);
        }

        [Fact]
        public async Task SearchAsync_ShouldNotThrowExceptionAsync()
        {
            await _controller.GetAsync(_searchRequest);
        }

        [Fact]
        public async Task SearchAsync_ShouldCallService()
        {
            await _controller.GetAsync(_searchRequest);

            _memberServiceMock.Verify(x =>
                x.GetPagedMembersAsync(
                    It.Is<SearchRequest>(y =>
                    y.Pagination.ItemsPerPage == _searchResponse.Pagination.ItemsPerPage &&
                    y.Pagination.Page == _searchResponse.Pagination.Page )), Times.Once);
        }

        [Fact]
        public async Task SearchAsync_ShouldReturnResponseAndValidStatus()
        {
            var response = await _controller.GetAsync(_searchRequest);

            Assert.NotNull(response);
            Assert.IsType<MemberSearchResponse>(response);
        }
    }
}
