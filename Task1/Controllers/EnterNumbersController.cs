using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Data;
using Task1.Models;

namespace Task1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnterNumberController : Controller
    {
        private readonly AssignmentDbContext assignmentDbContext;

        public EnterNumberController(AssignmentDbContext assignmentDbContext)
        {
            this.assignmentDbContext = assignmentDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetNumbers()
        {
            var numbers = await assignmentDbContext.EnterNumbers.ToListAsync();
            return Ok(numbers);
        }

        [HttpPost]
        public async Task<IActionResult> PostNumber([FromBody] int number)
        {
            if (number <= 0)
            {
                return BadRequest("Enter a valiid positive integer.");
            }
            if (await assignmentDbContext.EnterNumbers.AnyAsync(n => n.Number == number))
            {
                return BadRequest("Number already exist.");
            }

            var enterNumber = new EnterNumber
            {
                Number = number
            };
            assignmentDbContext.EnterNumbers.Add(enterNumber);
            await assignmentDbContext.SaveChangesAsync();
            return Ok(enterNumber);
        
        }
    }
}
