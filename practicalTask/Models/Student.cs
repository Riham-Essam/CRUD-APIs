namespace practicalTask.Models
{
	public class Student
	{
		public int Id { get; set; }
		[MaxLength(100)]
		public string Name { get; set; }
        public bool Activated { get; set; }
    }
}
