using BlazorApp.Model;
using BlazorApp.Data;

namespace BlazorApp.Service
{
    public interface ISecurityService
    {
        public Task<SecurityData> GetSecurityData(string ticker);
    }

    public class SecurityService : ISecurityService
    {
        private IReferenceDataService referenceDataService;
        private IPriceService priceService;
        private IBorrrowRateService borrowService;
        public SecurityService(IReferenceDataService refDataService, IPriceService pxService, IBorrrowRateService bService)
        {
            referenceDataService = refDataService;
            priceService = pxService;
            borrowService = bService;
        }

        public async Task<SecurityData> GetSecurityData(string ticker)
        {
            ticker = ticker.ToUpper().Trim();
            Console.WriteLine(ticker);
            var refData = await referenceDataService.GetReferenceData(ticker);
            var priceData = await priceService.GetPriceAsync(ticker);
            var borrowData = await borrowService.GetBorrowRate(ticker);
            var security = new SecurityData();
            security.Ticker = ticker;
            security.Name = refData.Name;
            Console.WriteLine("**test**");
            Console.WriteLine(security.Name);
            security.AvgDailyVolume = refData.Volume;
            security.LastPrice = Math.Round(priceData, 2);
            security.BorrowRate = borrowData;
            security.UpdateTime = DateTime.Now;
            return security;
        }
    }
}