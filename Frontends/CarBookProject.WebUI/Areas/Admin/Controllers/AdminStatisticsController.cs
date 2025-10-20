using System.Globalization;
using System.Text;
using CarBook.Dto.StatisticsDtos;
using CarBookProject.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7013/api/Statistics/");

            var random = new Random();
            var culture = new CultureInfo("tr-TR");
            var model = new DashboardStatisticsViewModel();

            // Ortak yardımcı fonksiyon (local function)
            async Task<ResultStatisticsDto?> GetStatAsync(string endpoint)
            {
                var response = await client.GetAsync(endpoint);
                if (!response.IsSuccessStatusCode)
                    return null;

                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ResultStatisticsDto>(json);
            }

            // 1) Araç sayısı
            var carCountDto = await GetStatAsync("GetCarCount");
            if (carCountDto != null)
            {
                model.CarCount = carCountDto.carCount;
                model.CarCountRandom = random.Next(0, 100);
            }

            // 2) Lokasyon sayısı
            var locationCountDto = await GetStatAsync("GetLocationCount");
            if (locationCountDto != null)
            {
                model.LocationCount = locationCountDto.locationCount;
                model.LocationCountRandom = random.Next(0, 100);
            }

            // 3) Yazar sayısı
            var authorCountDto = await GetStatAsync("GetAuthorCount");
            if (authorCountDto != null)
            {
                model.AuthorCount = authorCountDto.authorCount;
                model.AuthorCountRandom = random.Next(0, 100);
            }

            // 4) Blog sayısı
            var blogCountDto = await GetStatAsync("GetBlogCount");
            if (blogCountDto != null)
            {
                model.BlogCount = blogCountDto.blogCount;
                model.BlogCountRandom = random.Next(0, 100);
            }

            // 5) Marka sayısı
            var brandCountDto = await GetStatAsync("GetBrandCount");
            if (brandCountDto != null)
            {
                model.BrandCount = brandCountDto.brandCount;
                model.BrandCountRandom = random.Next(0, 100);
            }

            // 6) Elektrikli araç sayısı
            var electricDto = await GetStatAsync("GetCarCountByFuelElectric");
            if (electricDto != null)
            {
                model.CarCountByFuelElectric = electricDto.carCountByFuelElectric;
                model.CarCountByFuelElectricRandom = random.Next(0, 100);
            }

            // 7) Benzin/Dizel araç sayısı
            var gasDto = await GetStatAsync("GetCarCountByFuelGasolineOrDiesel");
            if (gasDto != null)
            {
                model.CarCountByFuelGasolineOrDiesel = gasDto.carCountByFuelGasolineOrDiesel;
                model.CarCountByFuelGasolineOrDieselRandom = random.Next(0, 100);
            }

            // 8) Km < 1000 araç sayısı
            var kmDto = await GetStatAsync("GetCarCountByKmSmallerThen1000");
            if (kmDto != null)
            {
                model.CarCountByKmSmallerThen1000 = kmDto.carCountByKmSmallerThen1000;
                model.CarCountByKmSmallerThen1000Random = random.Next(0, 100);
            }

            // 9) Otomatik vites araç sayısı
            var autoDto = await GetStatAsync("GetCarCountByTransmissionIsAuto");
            if (autoDto != null)
            {
                model.CarCountByTransmissionIsAuto = autoDto.carCountByTransmissionIsAuto;
                model.CarCountByTransmissionIsAutoRandom = random.Next(0, 100);
            }

            // 10) Aylık ortalama kira
            var monthlyDto = await GetStatAsync("GetAvgRentpriceForMonthly");
            if (monthlyDto != null)
            {
                model.AvgRentpriceForMonthly = monthlyDto.avgRentpriceForMonthly;
                model.AvgRentpriceForMonthlyRandom = random.Next(0, 100);
            }

            // 11) Haftalık ortalama kira
            var weeklyDto = await GetStatAsync("GetAvgRentpriceForWeekly");
            if (weeklyDto != null)
            {
                model.AvgRentpriceForWeekly = weeklyDto.avgRentpriceForWeekly;
                model.AvgRentpriceForWeeklyRandom = random.Next(0, 100);
            }

            // 12) Günlük ortalama kira
            var dailyDto = await GetStatAsync("GetAvgRentpriceForDaily");
            if (dailyDto != null)
            {
                model.AvgRentpriceForDaily = dailyDto.avgRentpriceForDaily;
                model.AvgRentpriceForDailyRandom = random.Next(0, 100);
            }

            // 13) En çok araca sahip marka
            var brandMaxDto = await GetStatAsync("GetBrandNameByMaxCar");
            if (brandMaxDto != null)
            {
                model.BrandNameByMaxCar = brandMaxDto.brandNameByMaxCar;
                model.BrandNameByMaxCarRandom = random.Next(0, 100);
            }

            // 14) En çok yorum alan blog
            var blogMaxCommentDto = await GetStatAsync("GetBlogTitleByMaxBlogComment");
            if (blogMaxCommentDto != null)
            {
                model.BlogTitleByMaxBlogComment = blogMaxCommentDto.blogTitleByMaxBlogComment;
                model.BlogTitleByMaxBlogCommentRandom = random.Next(0, 100);
            }

            // 15) Günlük en ucuz araç
            var dailyMinDto = await GetStatAsync("GetCarBrandAndModelByRentPriceDailyMin");
            if (dailyMinDto != null)
            {
                model.CarBrandAndModelByRentPriceDailyMin = dailyMinDto.carBrandAndModelByRentPriceDailyMin;
                model.CarBrandAndModelByRentPriceDailyMinRandom = random.Next(0, 100);
            }

            // 16) Günlük en pahalı araç
            var dailyMaxDto = await GetStatAsync("GetCarBrandAndModelByRentPriceDailyMax");
            if (dailyMaxDto != null)
            {
                model.CarBrandAndModelByRentPriceDailyMax = dailyMaxDto.carBrandAndModelByRentPriceDailyMax;
                model.CarBrandAndModelByRentPriceDailyMaxRandom = random.Next(0, 100);
            }

            return View(model);
        }

    }
}
