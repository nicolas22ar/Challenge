using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnicalExercise.Core.AuthModel;
using TechnicalExercise.Core.Domain;
using TechnicalExercise.Core.Processor;

namespace TestExcercise.WebApi.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = UserRoles.Admin)]
    public class VehicleController : Controller
    {
        public readonly IVehicleProcessor _processor;
        public VehicleController(IVehicleProcessor processor)
        {
            _processor = processor;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            return Ok(await _processor.GetAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _processor.GetAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _processor.DeleteAsync(id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] VehicleRequest vehicle)
        {
            await _processor.UpdateAsync(id, vehicle);
            return Ok();
        }

        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] VehicleRequest vehicle)
        {
            return Ok(await _processor.AddAsync(vehicle));
        }


    }
}
