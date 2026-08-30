namespace CaseManagementApi.Models
{
	// Denne klassen representerer en sak i systemet
	public class Case
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Status { get; set; }
		public DateTime CreatedAt { get; set; }

	}
}
