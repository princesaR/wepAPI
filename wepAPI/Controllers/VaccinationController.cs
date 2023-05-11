using Microsoft.AspNetCore.Mvc;
using Dto;
using Bll;

namespace wepAPI.Controllers
{

    [ApiController]
    [Route("api/vaccination/")]
    public class VaccinationController : ControllerBase
    {

        private readonly IVaccinationBll _vaccinationBll;
        private readonly IMemberBll _memberBll;

        public VaccinationController(IVaccinationBll vaccinationBll, IMemberBll memberBll)
        {
            this._vaccinationBll = vaccinationBll;
            this._memberBll = memberBll;
        }

        [HttpGet]
        public IActionResult GetVaccinations()
        {
            try
            {
                var vaccinations = _vaccinationBll.GetVaccinations();
                return Ok(vaccinations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetVaccinationById(string id)
        {
            try
            {
                var member = _memberBll.GetMemberById(id);
                if (member == null)
                {
                    return NotFound("Not found member with the specific ID");
                }

                var vaccinationById = _vaccinationBll.GetVaccinationById(id);
                if (vaccinationById == null)
                {
                    return NotFound("The member with this specific ID does not have vaccinations");
                }

                return Ok(vaccinationById);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<VaccinationDto> AddVaccination([FromBody] VaccinationDto vaccinationDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdVaccination = _vaccinationBll.AddVaccination(vaccinationDto);
                return CreatedAtAction(nameof(GetVaccinationById), new { id = createdVaccination.Id }, createdVaccination);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
