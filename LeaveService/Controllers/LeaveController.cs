using LeaveService.Data;
using LeaveService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveService.Controllers
{
    [Route("api/leave")]
    [ApiController]
    //[Authorize]
    public class LeaveController : ControllerBase
    {
        private readonly LeaveDbContext _context;

        public LeaveController(LeaveDbContext context)
        {
            _context = context;
        }

        // Get All Leave Requests
        [HttpGet]
        public async Task<IActionResult> GetAllLeaves()
        {
            var leaves = await  _context.LeaveRequests.ToListAsync();
            return Ok(leaves);
        }

        // Apply for Leave
        [HttpPost]
        public async Task<IActionResult> ApplyForLeave(LeaveRequest request)
        {
            _context.LeaveRequests.Add(request);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllLeaves), new { id = request.Id }, request);
        }
    }
}
