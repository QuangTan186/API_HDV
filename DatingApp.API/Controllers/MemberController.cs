using DatingApp.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/members")]
    public class MemberController : BaseController
    {
        [HttpGet]
        public ActionResult<IEnumerable<MemberDto>> Get()
        {
            return new List<MemberDto>();
        }
        [HttpGet("Username")]
        public ActionResult<MemberDto> Get(string username)
        {
            return new MemberDto();
        }
    }
}