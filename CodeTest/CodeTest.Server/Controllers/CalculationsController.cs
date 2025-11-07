using CodeTest.Application.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeTest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController(ISender sender, ILogger<CalculationsController> logger) : ControllerBase
    {
        private readonly ILogger<CalculationsController> _logger = logger;
        private readonly ISender _sender = sender;

        [HttpGet("CalculateTimeAngle")]
        public async Task<ActionResult> Get(TimeSpan time)
        {
            try
            {
                var result = await _sender.Send(new CalculateTimeAngleQuery(time));
                return Ok(result);
            }
            catch (Exception ex)
            {
                var error = $"Error occurred while calculating time angle. Error:{ex.Message}";
                _logger.LogError(ex, error);
                return BadRequest(error);
                
            }
        }

    }
}
