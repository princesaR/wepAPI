using Microsoft.AspNetCore.Mvc;
using Dto;
using Bll;
using Dal;
using Microsoft.AspNetCore.Hosting;

namespace wepAPI.Controllers
{
    [ApiController]
    [Route("api/coronaPatient/")]
    public class CoronaPatientController : ControllerBase
    {
        private readonly ICoronaPatientBll _coronaPatientBll;
        private readonly IMemberBll _memberBll;

        public CoronaPatientController(ICoronaPatientBll coronaPatientBll, IMemberBll memberBll)
        {
            _coronaPatientBll = coronaPatientBll;
            _memberBll = memberBll;
        }

        [HttpGet]
        public IActionResult GetCoronaPatients()
        {
            try
            {
                var coronaPatients = _coronaPatientBll.GetCoronaPatients();
                return Ok(coronaPatients);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return StatusCode(500, "An error occurred while retrieving corona patients");
            }
        }

        [HttpGet("getInMonth")]
        public IActionResult GetAllCoronaPatientInLastMonth()
        {
            try
            {
                var coronaPatients = _coronaPatientBll.GetAllCoronaPatientInLastMonth();
                return Ok(coronaPatients);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return StatusCode(500, "An error occurred while retrieving corona patients");
            }
        }

        [HttpGet("getInMonthPerDay")]
        public IActionResult GetActivePatientsPerDayLastMonth()
        {
            try
            {
                var coronaPatients = _coronaPatientBll.GetActivePatientsPerDayLastMonth();
                return Ok(coronaPatients);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return StatusCode(500, "An error occurred while retrieving active patients");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCoronaPatient(string id)
        {
            try
            {
                var member = _memberBll.GetMemberById(id);
                if (member == null)
                {
                    return NotFound("Not found member with the specific ID");
                }

                var coronaPatient = _coronaPatientBll.GetCoronaPatientById(id);
                if (coronaPatient == null)
                {
                    return NotFound("Not found corona patient with the specific ID");
                }
                return Ok(coronaPatient);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return StatusCode(500, "An error occurred while retrieving corona patient");
            }
        }

        [HttpPost]
        public ActionResult<CoronaPatientDto> AddCoronaPatient([FromBody] CoronaPatientDto coronaPatientDto)
        {
            try
            {
                if (coronaPatientDto.RecoveryDate <= coronaPatientDto.PositiveResult)
                    return BadRequest("the recovery date must be after the positive result day");

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdCoronaPatient = _coronaPatientBll.AddCoronaPatient(coronaPatientDto);
                return CreatedAtAction(nameof(GetCoronaPatient), new { id = createdCoronaPatient.Id }, createdCoronaPatient);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return StatusCode(500, "An error occurred while adding corona patient");
            }
        }
    }
}
