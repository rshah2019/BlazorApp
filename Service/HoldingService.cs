using BlazorApp.Model;
using BlazorApp.Data;
using Newtonsoft.Json;

namespace BlazorApp.Service
{
    public interface IHoldingService
    {
        public Task<HoldingsData> GetPosition(string ticker);
    }

    public class HoldingService : IHoldingService
    {
        private IBasisPointService basisPointService;
        public HoldingService(IBasisPointService service)
        {
            basisPointService = service;
        }

        public Task<HoldingsData> GetPosition(string ticker)
        {
            ticker = ticker.ToUpper().Trim();
            var positionMap = new Dictionary<string, double>
            {
                ["AAPL"] = 1000000,
                ["TSLA"] = 500000,
                ["AMZN"] = 275000,
                ["IBM"] = -50000,
                ["SPY"] = -20000,
                ["THO"] = -119000
            };
            return positionMap.ContainsKey(ticker) ?
                basisPointService.GetBasisPoint(ticker, positionMap[ticker]) :
                Task.FromResult(new HoldingsData());
        }
    }
    public class MockServerHoldingService : IHoldingService
    {
        private IBasisPointService basisPointService;
        private static readonly HttpClient httpClient = new HttpClient();
        public MockServerHoldingService(IBasisPointService service)
        {
            basisPointService = service;
        }

        public async Task<HoldingsData> GetPosition(string ticker)
        {
            ticker = ticker.ToUpper().Trim();
            var response = await httpClient.GetStringAsync("https://da0b46af-e56d-4f3c-b681-bba590b2bd0e.mock.pstmn.io/GetPositions");
            Console.WriteLine(response);
            var positionMap = JsonConvert.DeserializeObject<Dictionary<string, double>>(response);
            return positionMap.ContainsKey(ticker) ?
                basisPointService.GetBasisPoint(ticker, positionMap[ticker]).Result :
                new HoldingsData();
        }
    }
}