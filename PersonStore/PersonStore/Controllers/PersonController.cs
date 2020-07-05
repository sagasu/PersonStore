using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PersonStore.Config;
using PersonStore.Services.DTO;
using PersonStore.Services.Services;

namespace PersonStore.Controllers
{
    [ApiController]
    [Route("persons")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        [EnableCors(CORSConfig.ALLOW_ORIGIN)]
        public async Task<CreatedAtActionResult> CreatePerson(PersonDTO personDto)
        {
            var newlyCreatedId = await _personService.CreatePerson(personDto);
            personDto.Id = newlyCreatedId;
            return CreatedAtAction(nameof(GetById), new { id = newlyCreatedId}, personDto);
        }

        [HttpGet]
        [EnableCors(CORSConfig.ALLOW_ORIGIN)]
        public async Task<OkObjectResult> GetAllPeople()
        {
            var allPeople = await _personService.GetAllPeople();
            return Ok(allPeople);
        }

        [HttpGet("{id}")]
        [EnableCors(CORSConfig.ALLOW_ORIGIN)]
        public async Task<OkObjectResult> GetById(int id)
        {
            var allPeople = await _personService.GetById(id);
            return Ok(allPeople);
        }
    }
}
