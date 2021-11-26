using BlazorApp.Model;

namespace BlazorApp.Service
{
    public interface IReferenceDataService
    {
        public Task<ReferenceData> GetReferenceData(string ticker);
    }

    public class ReferenceDataService : IReferenceDataService
    {
        public Task<ReferenceData> GetReferenceData(string ticker)
        {
            var nameMap = new Dictionary<string, string>
            {
                ["AAPL"] = "Apple",
                ["TSLA"] = "Tesla",
                ["AMZN"] = "Amazon",
                ["IBM"] = "IBM",
                ["SPY"] = "SP500",
                ["THO"] = "Thor Industries",
            };

            var volumeMap = new Dictionary<string, double>
            {
                ["AAPL"] = 10000000,
                ["TSLA"] = 11000000,
                ["AMZN"] = 8000000,
                ["IBM"] = 500000,
                ["SPY"] = 10000000,
                ["THO"] = 185000
            };

            var refData = new ReferenceData();
            if (nameMap.TryGetValue(ticker, out var name)) refData.Name = name;
            if (volumeMap.TryGetValue(ticker, out var vol)) refData.Volume = vol;
            return Task.FromResult(refData);
        }
    }
}