using ems_backend.Service.Implements;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemindersController : ControllerBase
    {
        private readonly ReminderService _reminderService;

        public RemindersController(ReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReminders()
        {
            try
            {
                var reminders = await _reminderService.GetAllRemindersAsync();
                return Ok(reminders);
            }
            catch (Exception ex)
            {
                // Log the exception and return an error response
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
