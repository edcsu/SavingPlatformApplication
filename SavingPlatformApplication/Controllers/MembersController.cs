using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SavingPlatformApplication.Data.Models;
using SavingPlatformApplication.Services.Contracts;

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

        // GET: api/<MembersController>
        [HttpGet]
        public async Task<IEnumerable<Member>> GetAsync()
        {
            return await _memberService.GetMembersAsync();
        }

        // GET api/<MembersController>/5
        [HttpGet("{id:Guid}")]
        public string Get(Guid id)
        {
            return "value";
        }

        // POST api/<MembersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MembersController>/5
        [HttpPut("{id:Guid}")]
        public void Put(Guid id, [FromBody] string value)
        {
        }

        // DELETE api/<MembersController>/5
        [HttpDelete("{id:Guid}")]
        public void Delete(Guid id)
        {
        }
    }
}
