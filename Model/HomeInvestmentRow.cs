namespace BlazorApp.Model
{
    public class HomeInvestmentRow
    {
        public string PM {get; set;}
        public string AssetClass {get; set;}
        public string Sector {get; set;}
        public string Ticker {get; set;}
        public string Issuer {get; set;}
        public double NetExposure {get; set;}
        public double GrossExposure {get; set;}
        public double ExposurePct {get; set;}
        public double Delta1Exposure {get; set;}
        public double OptionExposure {get; set;}
    }
}