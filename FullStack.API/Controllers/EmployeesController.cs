using FullStack.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private AppDBContext dbContext;
        public EmployeesController(AppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await dbContext.Employees.ToListAsync();

            return Ok(employees);
        }

        [HttpGet("/{id:guid}")]
        //[Route("/{id:guid}")]
        public async Task<IActionResult> GetEmployeeByName([FromRoute] Guid id)
        {
            var result = await dbContext.Employees.FirstOrDefaultAsync(m => m.Id==id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee) 
        { 
            employee.Id = Guid.NewGuid();

            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();

            return Ok(employee);
        }
    }
}
