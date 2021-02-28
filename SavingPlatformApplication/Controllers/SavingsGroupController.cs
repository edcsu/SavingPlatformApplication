using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SavingPlatformApplication.Data.Models;
using SavingPlatformApplication.Services.Contracts;
using SavingPlatformApplication.ViewModels.SavingsGroupViews;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SavingPlatformApplication.Controllers
{
    [Route("api/[controller]")]
    public class SavingsGroupController : BaseController
    {
        private readonly ISavingsGroupService _savingsGroupService;

        public SavingsGroupController(ISavingsGroupService savingsGroupService)
        {
            _savingsGroupService = savingsGroupService;
        }

        [HttpGet]
        public async Task<IEnumerable<SavingsGroup>> GetAsync()
        {
            return await _savingsGroupService.GetSavingsGroupsAsync();
        }

        [HttpGet("{id:Guid}")]
        public async Task<SavingsGroup> GetAsync(Guid id)
        {
            return await _savingsGroupService.GetSavingsGroupAsync(id);
        }


        [HttpPost]
        public async Task<SavingsGroupViewModel> PostAsync([FromBody] SavingsGroupPostModel postModel)
        {
            return await _savingsGroupService.AddSavingsGroupAsync(postModel);
        }

        [HttpPut("{id:Guid}")]
        public async Task<SavingsGroupViewModel> PutAsync(Guid id, [FromBody] SavingsGroupUpdateModel updateModel)
        {
            return await _savingsGroupService.UpdateSavingsGroupAsync(id, updateModel);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<Guid> DeleteAsync(Guid id)
        {
            return await _savingsGroupService.DeleteSavingsGroupAsync(id);
        }
    }
}
