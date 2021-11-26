namespace BlazorApp.Data
{
    public class TradingData
    {
        public IEnumerable<BasisPointShares> BpsShares { get; set; }
        public double Price { get; set; }
        public double Capital { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}