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
using SavingPlatformApplication.ViewModels.AddressViews;
using SavingPlatformApplication.ViewModels.SavingsGroupViews;
using Xunit;

namespace SavingsPlatformApplication.Test.Controllers
{
    public class SavingsGroupControllerTests
    {

        private readonly Mock<ISavingsGroupService> _savingsGroupServiceMock;
        private readonly Guid _requestId = Guid.NewGuid();
        private readonly List<SavingsGroup> _savingsGroupList;
        private readonly SavingsGroupViewModel _viewModel;
        private readonly SavingsGroupPostModel _postModel;
        private readonly SavingsGroupUpdateModel _updateModel;
        private readonly Address _address = GenerateFakeData.GetSampleAddress();
        private readonly AddressPostModel _postAddress;
        private readonly AddressUpdateModel _updateAddress;
        private readonly SavingsGroupController _controller;
        private readonly SearchRequest _searchRequest = TestHelpers.GetTestSearchRequest();
        private readonly SavingsGroupSearchResponse _searchResponse;


        public SavingsGroupControllerTests()
        {
            _savingsGroupServiceMock = new Mock<ISavingsGroupService>();

            _savingsGroupList = GenerateFakeData.GetSampleSavingsGroups();

            _viewModel = MapperProfiles.MapSavingsGroupModelToSavingsGroupViewModel(_savingsGroupList[0]);
            _viewModel.Id = _requestId;

            _postAddress = new AddressPostModel
            {
                Country = _address.Country,
                StreetName = _address.StreetName,
                Town = _address.Town
            };

            _updateAddress = new AddressUpdateModel
            {
                Country = _address.Country,
                StreetName = _address.StreetName,
                Town = _address.Town
            };

            _postModel = new SavingsGroupPostModel
            {
                FullName = _viewModel.FullName,
                Balance = _viewModel.Balance,
                DateFounded = _viewModel.DateFounded,
                Email = _viewModel.Email,
                PhoneNumber = _viewModel.PhoneNumber,
                Address = _postAddress        
            };

            _updateModel = new SavingsGroupUpdateModel
            {
                FullName = _viewModel.FullName,
                Balance = _viewModel.Balance,
                DateFounded = _viewModel.DateFounded,
                Email = _viewModel.Email,
                PhoneNumber = _viewModel.PhoneNumber,
                Address = _updateAddress
            };

            _searchResponse = TestHelpers.GetTestSavingsGroupSearchResponseResults();

            _controller = new SavingsGroupController(_savingsGroupServiceMock.Object) { };

            _savingsGroupServiceMock.Setup(x => x.GetSavingsGroupAsync(It.IsAny<Guid>()))
                .ReturnsAsync(_viewModel);

            _savingsGroupServiceMock.Setup(x => x.AddSavingsGroupAsync(It.IsAny<SavingsGroupPostModel>()))
                .ReturnsAsync(_viewModel);

            _savingsGroupServiceMock.Setup(x => x.UpdateSavingsGroupAsync(It.IsAny<Guid>(), It.IsAny<SavingsGroupUpdateModel>()))
                .ReturnsAsync(_viewModel);

            _savingsGroupServiceMock.Setup(x => x.GetPagedSavingsGroupAsync(It.IsAny<SearchRequest>()))
                .ReturnsAsync(_searchResponse);

            _savingsGroupServiceMock.Setup(x => x.DeleteSavingsGroupAsync(It.IsAny<Guid>()))
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

            _savingsGroupServiceMock.Verify(x =>
                x.GetSavingsGroupAsync(
                    It.Is<Guid>(y =>
                    y == _requestId)), Times.Once);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResponseAndValidStatus()
        {
            var response = await _controller.GetAsync(_requestId);

            Assert.NotNull(response);
            Assert.IsType<SavingsGroupViewModel>(response);
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

            _savingsGroupServiceMock.Verify(x =>
                x.GetPagedSavingsGroupAsync(
                    It.Is<SearchRequest>(y =>
                    y.Pagination.ItemsPerPage == _searchResponse.Pagination.ItemsPerPage &&
                    y.Pagination.Page == _searchResponse.Pagination.Page)), Times.Once);
        }

        [Fact]
        public async Task SearchAsync_ShouldReturnResponseAndValidStatus()
        {
            var response = await _controller.GetAsync(_searchRequest);

            Assert.NotNull(response);
            Assert.IsType<SavingsGroupSearchResponse>(response);
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

            _savingsGroupServiceMock.Verify(x =>
                x.AddSavingsGroupAsync(
                    It.Is<SavingsGroupPostModel>(y =>
                    y.Balance == _postModel.Balance &&
                    y.DateFounded == _postModel.DateFounded &&
                    y.Email == _postModel.Email &&
                    y.FullName == _postModel.FullName &&
                    y.PhoneNumber == _postModel.PhoneNumber)), Times.Once);
        }

        [Fact]
        public async Task PostAsync_ShouldReturnResponseAndValidStatus()
        {
            var response = await _controller.PostAsync(_postModel);

            Assert.NotNull(response);
            Assert.IsType<SavingsGroupViewModel>(response);
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

            _savingsGroupServiceMock.Verify(x =>
                x.UpdateSavingsGroupAsync(
                    It.Is<Guid>(g => g == _requestId),
                    It.Is<SavingsGroupUpdateModel>(y =>
                    y.Balance == _updateModel.Balance &&
                    y.DateFounded == _updateModel.DateFounded &&
                    y.Email == _updateModel.Email &&
                    y.FullName == _updateModel.FullName &&
                    y.PhoneNumber == _updateModel.PhoneNumber)), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnResponseAndValidStatus()
        {
            var response = await _controller.PutAsync(_requestId, _updateModel);

            Assert.NotNull(response);
            Assert.IsType<SavingsGroupViewModel>(response);
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

            _savingsGroupServiceMock.Verify(x =>
                x.DeleteSavingsGroupAsync(
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
