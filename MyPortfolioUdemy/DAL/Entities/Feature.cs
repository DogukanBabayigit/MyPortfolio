namespace MyPortfolioUdemy.DAL.Entities
{
	public class Feature
	{
		public int FeatureId { get; set; }
		public string Title { get; set; } = string.Empty; // Initialize non-nullable property
		public string Description { get; set; } = string.Empty; // Initialize non-nullable property
	}
}
