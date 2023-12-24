using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace practicalTask.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly AppDbContext _context;

		public StudentsController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet("GetAllAsync")]
		public async Task<IActionResult> GetAllAsync()
		{

            var activeStudents = await _context.Students
				.Where(m => m.Activated)
				.OrderBy(m => m.Name)
				.ToListAsync();

			return Ok(activeStudents);
		}

		[HttpPost("CreateAsync")]
		public async Task<IActionResult> CreateAsync(CreateStudentDto dto)
		{
			var student = new Student
			{
				Name = dto.Name,
				Activated = true
			};

			await _context.Students.AddAsync(student);
			await _context.SaveChangesAsync();

			return Ok(student);
		}

		[HttpDelete("DeleteAsync/{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var student = await _context.Students.SingleOrDefaultAsync(m => m.Id == id);

			if(student == null)
			{
				return NotFound($"There is no student with ID: {id}");
			}
			//To apply soft delete
			student.Activated = false;
			_context.Students.Update(student);
			await _context.SaveChangesAsync();

			return Ok(student);
		}
	}
}
