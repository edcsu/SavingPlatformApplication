using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SavingPlatformApplication.Data.Models;
using SavingPlatformApplication.Services.Contracts;
using SavingPlatformApplication.ViewModels;
using SavingPlatformApplication.ViewModels.MemberViews;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SavingPlatformApplication.Controllers
{

    [Route("api/[controller]")]
    public class MembersController : BaseController
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<MemberSearchResponse> GetAsync([FromQuery] SearchRequest searchRequest)
        {
            return await _memberService.GetPagedMembersAsync(searchRequest);
        }

        [HttpGet("{id:Guid}")]
        public async Task<MemberViewModel> GetAsync(Guid id)
        {
            return await _memberService.GetMemberAsync(id);
        }

        [HttpPost]
        public async Task<MemberViewModel> PostAsync([FromBody] MemberPostModel postModel)
        {
            return await _memberService.AddMemberAsync(postModel);
        }

        [HttpPut("{id:Guid}")]
        public async Task<MemberViewModel> PutAsync(Guid id, [FromBody] MemberUpdateModel updateModel)
        {
            return await _memberService.UpdateMemberAsync(id, updateModel);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<Guid> DeleteAsync(Guid id)
        {
            return await _memberService.DeleteMemberAsync(id);
        }
    }
}
