using Microsoft.AspNetCore.Mvc;
using Dto;
using Bll;


namespace wepAPI.Controllers
{

    [ApiController]
    [Route("api/vaccination/")]
    public class VaccinationController : ControllerBase
    {

        IVaccinationBll _vaccinationBll;
        IMemberBll _memberBll;

        public VaccinationController(IVaccinationBll _vaccinationBll,IMemberBll _memberBll)
        {
            this._vaccinationBll = _vaccinationBll;
            this._memberBll = _memberBll;
        }


        [HttpGet]
        public  IActionResult GetVaccinations()
        {
            var vaccinations = _vaccinationBll.GetVaccinations();
            return Ok(vaccinations);
        }
        [HttpGet("{id}")]
        public IActionResult GetVaccinationById(string id)
        {
            var member = _memberBll.GetMemberById(id);
            if (member == null)
            {
                return NotFound("Not found member with the specific ID");
            }

            var vaccinationById = _vaccinationBll.GetVaccinationById(id);
            if (vaccinationById == null)
            {
                return NotFound("the member with this specific Id doest have vaccinations");
            }

            return Ok(vaccinationById);
        }


        [HttpPost]
        public  ActionResult<VaccinationDto> AddVaccination([FromBody] VaccinationDto vaccinationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdVaccination =  _vaccinationBll.AddVaccination(vaccinationDto);
            return CreatedAtAction(nameof(GetVaccinationById), new { id = createdVaccination.Id }, createdVaccination);
        }


    }
}

