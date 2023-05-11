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

        ICoronaPatientBll _coronaPatientBll;
        IMemberBll _memberBll;
        public CoronaPatientController(ICoronaPatientBll _coronaPatientBll, IMemberBll memberBll)
        {
            this._coronaPatientBll = _coronaPatientBll;
            _memberBll = memberBll;
        }

        [HttpGet]
        public IActionResult GetCoronaPatients()
        {
            var coronaPatients = _coronaPatientBll.GetCoronaPatients();
            return Ok(coronaPatients);
        }

        [HttpGet("getInMonth")]
        public IActionResult GetAllCoronaPatientInLastMonth()
        {
            var coronaPatients = _coronaPatientBll.GetAllCoronaPatientInLastMonth();
            return Ok(coronaPatients);
        }

        [HttpGet("getInMonthPerDay")]
        
        public IActionResult GetActivePatientsPerDayLastMonth()
        {
            var coronaPatients = _coronaPatientBll.GetActivePatientsPerDayLastMonth();
            return Ok(coronaPatients);
        }
        

        [HttpGet("{id}")]
        public IActionResult GetCoronaPatient(string id)
        {
            var member = _memberBll.GetMemberById(id);
            if (member == null)
            {
                return NotFound("Not found member with the specific ID");
            }

            var coronaPatient = _coronaPatientBll.GetCoronaPatientById(id);
            if(coronaPatient == null)
            {
                return NotFound("Not found corona patient with the specific ID");
            }
            return Ok(coronaPatient);
        }

        [HttpPost]
        public ActionResult<CoronaPatientDto> AddCoronaPatient([FromBody] CoronaPatientDto coronaPatientDto)
        {
            if (coronaPatientDto.RecoveryDate <= coronaPatientDto.PositiveResult)
                return BadRequest("the recovery date must be after the postive Result day");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

            var createdCoronaPatient = _coronaPatientBll.AddCoronaPatient(coronaPatientDto);
            return CreatedAtAction(nameof(GetCoronaPatient), new { code = createdCoronaPatient.Id }, createdCoronaPatient);
        }



        


    }
}

