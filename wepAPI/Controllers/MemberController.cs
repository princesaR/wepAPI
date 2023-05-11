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
        private readonly IMemberBll _memberBll;

        public MemberController(IMemberBll memberBll)
        {
            this._memberBll = memberBll;
        }

        [HttpGet]
        public IActionResult GetAllMembers()
        {
            try
            {
                var members = _memberBll.GetMembers();
                return Ok(members);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetMember(string id)
        {
            try
            {
                var member = _memberBll.GetMemberById(id);
                if (member == null)
                {
                    return NotFound("Not found member with the specific ID");
                }

                return Ok(member);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<MemberDto> AddMember([FromBody] MemberDto memberDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var createdMember = _memberBll.AddMember(memberDto);
                return CreatedAtAction(nameof(GetAllMembers), new { id = createdMember.Id }, createdMember);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("getNotVaccinated")]
        public IActionResult GetNotVaccinatedMembersCount()
        {
            try
            {
                var count = _memberBll.GetNotVaccinatedCount();
                return Ok(count);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
