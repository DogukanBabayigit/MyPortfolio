namespace MyPortfolioUdemy.DAL.Entities
{
    /// <summary>
    /// Summary description for Portfolio
    /// </summary>
    public class Portfolio
    {
        public int PortfolioId { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? ImageUrl { get; set; }
        public string? Url { get; set; }
        public string? Description { get; set; }
    }
}
