using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pets.Dto;
using Pets.Services;

namespace Pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        [HttpGet(Name = "GetAllOwners")]
        public IActionResult GetAll()
        {
            var owners = _ownerService.GetAllOwners();
            if (owners.Any())
                return Ok(owners);
            else
                return NoContent();
        }

        [HttpGet("{id}", Name = "GetOwnerById")]
        public IActionResult Get(int id)
        {
            var desiredOwner = _ownerService.GetOwnerById(id);

            if (desiredOwner != null)
                return Ok(desiredOwner);
            else
                return NotFound();
        }

        [HttpPost(Name = "CreateOwner")]
        public IActionResult Create([FromBody] CreateOwnerDto owner)
        {
            if (owner == null)
                return BadRequest();
           
            _ownerService.AddOwner(owner);
            
            return Ok(owner);
        }

        [HttpPut(Name = "UpdateOwner")]
        public IActionResult Update([FromBody] OwnerDto owner)
        {
            if (owner == null)
                return BadRequest();

            var updatedOrCreatedOwner = _ownerService.Update(owner);

            return Ok(updatedOrCreatedOwner);
        }

        [HttpDelete("{id}", Name = "DeleteOwner")]
        public IActionResult Delete(int id)
        {
            try
            {
                _ownerService.Delete(id);
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }

            return NoContent();
        }
    }
}
