namespace CarBookProject.WebUI.Areas.Admin.Models
{
    public class DashboardStatisticsViewModel
    {
        public int CarCount { get; set; }
        public int CarCountRandom { get; set; }

        public int LocationCount { get; set; }
        public int LocationCountRandom { get; set; }

        public int AuthorCount { get; set; }
        public int AuthorCountRandom { get; set; }

        public int BlogCount { get; set; }
        public int BlogCountRandom { get; set; }

        public int BrandCount { get; set; }
        public int BrandCountRandom { get; set; }

        public int CarCountByFuelElectric { get; set; }
        public int CarCountByFuelElectricRandom { get; set; }

        public int CarCountByFuelGasolineOrDiesel { get; set; }
        public int CarCountByFuelGasolineOrDieselRandom { get; set; }

        public int CarCountByKmSmallerThen1000 { get; set; }
        public int CarCountByKmSmallerThen1000Random { get; set; }

        public int CarCountByTransmissionIsAuto { get; set; }
        public int CarCountByTransmissionIsAutoRandom { get; set; }

        public decimal AvgRentpriceForMonthly { get; set; }
        public int AvgRentpriceForMonthlyRandom { get; set; }

        public decimal AvgRentpriceForWeekly { get; set; }
        public int AvgRentpriceForWeeklyRandom { get; set; }

        public decimal AvgRentpriceForDaily { get; set; }
        public int AvgRentpriceForDailyRandom { get; set; }

        public string BrandNameByMaxCar { get; set; }
        public int BrandNameByMaxCarRandom { get; set; }

        public string BlogTitleByMaxBlogComment { get; set; }
        public int BlogTitleByMaxBlogCommentRandom { get; set; }

        public string CarBrandAndModelByRentPriceDailyMin { get; set; }
        public int CarBrandAndModelByRentPriceDailyMinRandom { get; set; }

        public string CarBrandAndModelByRentPriceDailyMax { get; set; }
        public int CarBrandAndModelByRentPriceDailyMaxRandom { get; set; }
    }

}
