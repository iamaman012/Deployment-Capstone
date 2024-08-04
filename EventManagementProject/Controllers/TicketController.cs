using EventManagementProject.DTOs.TicketDTO;
using EventManagementProject.Interfaces.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCors")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTicket(AddTicketDTO ticketDTO)
        {
            try
            {
                await _ticketService.AddTicket(ticketDTO);
                return Ok("Ticket added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get/byUserId")]
        public async Task<IActionResult> GetTicketByUserId(int userId)
        {
            try
            {
                var tickets = await _ticketService.GetTicketByUserId(userId);
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
