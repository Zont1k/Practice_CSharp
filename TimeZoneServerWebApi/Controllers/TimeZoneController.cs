using Microsoft.AspNetCore.Mvc;
using System;

namespace TimeZoneServerWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetTime([FromBody] string timeZoneId)
        {
            if (string.IsNullOrEmpty(timeZoneId))
            {
                return BadRequest("Id of time zone can't be empty");
            }

            try
            {
                TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                DateTime currentTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, timeZone);
                string responseString = $"Current time in this time zone {timeZoneId}: {currentTime}";

                return Ok(responseString);
            }
            catch (TimeZoneNotFoundException)
            {
                return BadRequest("Not a valid time zone Id");
            }
        }
    }
}
