using DatingApp.API.DTOs;
using DatingApp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/members")]
    public class MemberController : BaseController
    {
        private readonly IMemberService _memberService;
        [HttpGet]
        public ActionResult<IEnumerable<MemberDto>> Get()
        {
            return new List<MemberDto>();
        }
        [HttpGet("Username")]
        public ActionResult<MemberDto> Get(string username)
        {
            var member = _memberService.GetMemberByUsernam(username);
            if(member == null) return NotFound();
            return new MemberDto();
        }
    }
}