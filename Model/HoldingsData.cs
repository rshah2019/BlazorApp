namespace BlazorApp.Model
{
    public class HoldingsData
    {
        public string Ticker { get; set; }
        public double Shares { get; set; }
        public double BasisPoints { get; set; }
        public double LastPrice { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}