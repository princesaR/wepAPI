using Microsoft.AspNetCore.Mvc;
using Dto;
using Bll;
using Entity;
using System;


namespace wepAPI.Controllers
{

    [ApiController]
    [Route("api/member/")]
    public class MemberController : ControllerBase
    {

        IMemberBll _memberBll;

        public MemberController(IMemberBll memberBll)
        {
            this._memberBll = memberBll;
        }

        [HttpGet]
        public IActionResult GetAllMembers()
        {
            var members = _memberBll.GetMembers();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public IActionResult GetMember(string id)
        {
            var member = _memberBll.GetMemberById(id);
            if (member == null)
            {
                return NotFound("Not found member with the specific ID");
            }

            return Ok(member);
        }

        [HttpPost]
        public ActionResult<MemberDto> AddMember([FromBody] MemberDto memberDto)
        {
           if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
           }
            var createdMember = _memberBll.AddMember(memberDto);
            return CreatedAtAction(nameof(GetAllMembers), new { id = createdMember.Id }, createdMember);
        }

        [HttpGet("getNotVaccinated")]
        public int GetNotVaccinatedMembersCount() {
            return _memberBll.GetNotVaccinatedCount();
        }

        


    }
}
