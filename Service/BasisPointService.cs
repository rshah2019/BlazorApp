using BlazorApp.Model;

namespace BlazorApp.Data
{
    public interface IBasisPointService
    {
        Task<TradingData> GetShares(string ticker, IEnumerable<double> bpsList);
        Task<HoldingsData> GetBasisPoint(string ticker, double shares);
    }

    public class BasisPointService : IBasisPointService
    {
        private ICapitalService _capitalService;
        private IPriceService _priceService;

        public BasisPointService(ICapitalService capitalService, IPriceService priceService)
        {
            _capitalService = capitalService;
            _priceService = priceService;
        }

        public async Task<HoldingsData> GetBasisPoint(string ticker, double shares)
        {
            var price = await _priceService.GetPriceAsync(ticker);
            var capital = await _capitalService.GetCapitalNumberASync();
            return new HoldingsData()
            {
                Ticker = ticker,
                LastPrice = Math.Round(price, 2),
                Shares = shares,
                BasisPoints = Math.Abs(Math.Round((shares * price * 10000) / capital, 1)),
                UpdateTime = DateTime.Now
            };
        }

        public async Task<TradingData> GetShares(string ticker, IEnumerable<double> bpsList)
        {
            var price = await _priceService.GetPriceAsync(ticker);
            var capital = await _capitalService.GetCapitalNumberASync();

            var shares = bpsList.Select(bps => new BasisPointShares
            {
                BasisPoints = bps,
                Shares = Math.Round(bps * capital / (price * 10000), 0),
                OrderValue = bps * capital / 10000
            });

            return new TradingData() { BpsShares = shares, Price = Math.Round(price, 2), Capital = capital, UpdateTime = DateTime.Now };
        }

    }
}