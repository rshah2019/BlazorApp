namespace BlazorApp.Data
{
    public interface IPriceService
    {
        Task<double> GetPriceAsync(string ticker);
    }

    public class PriceService : IPriceService
    {
        public double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
        public Task<double> GetPriceAsync(string ticker)
        {
            ticker = ticker.ToUpper();
            var code = Math.Abs(ticker.GetHashCode() % 100);
            var result = GetRandomNumber(0.99 * code, 1.1 * code);
            return Task.FromResult(result);
        }
    }
}