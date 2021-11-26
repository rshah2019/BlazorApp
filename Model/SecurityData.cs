namespace BlazorApp.Model
{
    //Should display the ticker, name, last price, average daily volume, and borrow rate (or N/A).
    public class SecurityData
    {
        public string Ticker { get; set; }
        public string? Name { get; set; }
        public double? LastPrice { get; set; }

        public double? AvgDailyVolume { get; set; }

        public double? BorrowRate { get; set; }

        public DateTime UpdateTime { get; set; }

    }
}