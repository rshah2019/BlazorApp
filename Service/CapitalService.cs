namespace BlazorApp.Data
{

    public interface ICapitalService
    {
        Task<long> GetCapitalNumberASync();
    }

    public class CapitalService : ICapitalService
    {
        public Task<long> GetCapitalNumberASync()
        {
            return Task.FromResult(8000000000);
        }
    }
}