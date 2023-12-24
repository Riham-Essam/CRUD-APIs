namespace practicalTask.DTOs
{
	public class CreateStudentDto
	{
		[MaxLength(100)]
		public string Name { get; set; }
		public bool Activated { get; set; }
	}
}
