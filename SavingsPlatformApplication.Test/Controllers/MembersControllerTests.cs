﻿using System;
using System.Collections.Generic;
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

namespace SavingsPlatformApplication.Test.Controllers
{
    public class MembersControllerTests
    {
        private readonly Mock<IMemberService> _memberServiceMock;
        private readonly Guid _requestId = Guid.NewGuid();
        private readonly List<Member> _memberList;
        private readonly MemberViewModel _viewModel;
        private readonly MemberPostModel _postModel;
        private readonly MemberUpdateModel _updateModel;
        private readonly MembersController _controller;
        private readonly SearchRequest _searchRequest = TestHelpers.GetTestSearchRequest();
        private readonly MemberSearchResponse _searchResponse;

        public MembersControllerTests()
        {
            _memberServiceMock = new Mock<IMemberService>();

            _memberList = GenerateFakeData.GetSampleMembers();

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

            _searchResponse = TestHelpers.GetTestMemberSearchResponseResults();

            _controller = new MembersController(_memberServiceMock.Object) { };

            _memberServiceMock.Setup(x => x.GetMemberAsync(It.IsAny<Guid>()))
                .ReturnsAsync(_viewModel);
            
            _memberServiceMock.Setup(x => x.AddMemberAsync(It.IsAny<MemberPostModel>()))
                .ReturnsAsync(_viewModel);

            _memberServiceMock.Setup(x => x.UpdateMemberAsync(It.IsAny<Guid>(), It.IsAny<MemberUpdateModel>()))
                .ReturnsAsync(_viewModel);
            
            _memberServiceMock.Setup(x => x.GetPagedMembersAsync(It.IsAny<SearchRequest>()))
                .ReturnsAsync(_searchResponse);

            _memberServiceMock.Setup(x => x.DeleteMemberAsync(It.IsAny<Guid>()))
                .ReturnsAsync(_requestId);
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

        [Fact]
        public async Task PostAsync_ShouldNotThrowExceptionAsync()
        {
            await _controller.PostAsync(_postModel);
        }

        [Fact]
        public async Task PostAsync_ShouldCallService()
        {
            await _controller.PostAsync(_postModel);

            _memberServiceMock.Verify(x =>
                x.AddMemberAsync(
                    It.Is<MemberPostModel>(y =>
                    y.Balance == _postModel.Balance &&
                    y.BirthDate == _postModel.BirthDate &&
                    y.Email == _postModel.Email &&
                    y.FullName == _postModel.FullName &&
                    y.Gender == _postModel.Gender)), Times.Once);
        }

        [Fact]
        public async Task PostAsync_ShouldReturnResponseAndValidStatus()
        {
            var response = await _controller.PostAsync(_postModel);

            Assert.NotNull(response);
            Assert.IsType<MemberViewModel>(response);
        }

        [Fact]
        public async Task UpdateAsync_ShouldNotThrowExceptionAsync()
        {
            await _controller.PutAsync(_requestId, _updateModel);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallService()
        {
            await _controller.PutAsync(_requestId, _updateModel);

            _memberServiceMock.Verify(x =>
                x.UpdateMemberAsync(
                    It.Is<Guid>(g => g == _requestId),
                    It.Is<MemberUpdateModel>(y =>
                    y.Balance == _updateModel.Balance &&
                    y.BirthDate == _updateModel.BirthDate &&
                    y.Email == _updateModel.Email &&
                    y.FullName == _updateModel.FullName &&
                    y.Gender == _updateModel.Gender)), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnResponseAndValidStatus()
        {
            var response = await _controller.PutAsync(_requestId, _updateModel);

            Assert.NotNull(response);
            Assert.IsType<MemberViewModel>(response);
        }


        [Fact]
        public async Task DeleteAsync_ShouldNotThrowExceptionAsync()
        {
            await _controller.DeleteAsync(_requestId);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallService()
        {
            await _controller.DeleteAsync(_requestId);

            _memberServiceMock.Verify(x =>
                x.DeleteMemberAsync(
                    It.Is<Guid>(y =>
                    y == _requestId)), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnResponseAndValidStatus()
        {
            var response = await _controller.DeleteAsync(_requestId);

            Assert.IsType<Guid>(response);
            Assert.Equal(_requestId, response);
        }
    }
}
