namespace BlazorApp.Service
{
    public interface IBorrrowRateService
    {
        public Task<double?> GetBorrowRate(string ticker);
    }

    public class BorrrowRateService : IBorrrowRateService
    {
        public Task<double?> GetBorrowRate(string ticker)
        {
            var borrowMap = new Dictionary<string, double>
            {
                ["IBM"] = 0.08,
                ["SPY"] = 0.00025,
                ["THO"] = 0.002
            };
            double? result = null;
            if (borrowMap.ContainsKey(ticker))
            {
                result = borrowMap[ticker];
            }
            return Task.FromResult(result);
        }
    }
}