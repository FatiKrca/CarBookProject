using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Application.Interfaces.StatisticsInterfaces;
using CarBookProject.Domain.Entities;
using CarBookProject.Persistence.Context;

namespace CarBookProject.Persistence.Repositories.StatisticsRpository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }
        public int GetCarCount()
        {
            var values = _context.Cars.Count();
            return values;
        }
        public int GetAuthorCount()
        {
            var values = _context.Authors.Count();
            return values;
        }
        public int GetLocationCount()
        {
            var values = _context.Locations.Count();
            return values;
        }
        public int GetBlogCount()
        {
            var values = _context.Blogs.Count();
            return values;
        }
        public int GetBrandCount()
        {
            var values = _context.Brands.Count();
            return values;
        }
        public int GetCarCountByFuelElectric()
        {
            var values = _context.Cars.Where(c => c.Fuel == "Elektirik").Count();
            return values;
        }
        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var values = _context.Cars.Where(c => c.Fuel == "Benzin" || c.Fuel == "Dizel").Count();
            return values;
        }
        public int GetCarCountByKmSmallerThen1000()
        {
            var values = _context.Cars.Where(c => c.Km < 1000).Count();
            return values;
        }
        public int GetCarCountByTransmissionIsAuto()
        {
            var values = _context.Cars.Where(c => c.Transmission == "Otomatik").Count();
            return values;
        }
        public decimal GetAvgRentpriceForMonthly()
        {
            var monthlyIds = _context.Pricings.Where(p => p.Name == "Aylık").Select(p => p.PricingId).FirstOrDefault();

            var values = _context.CarPricings.Where(x => x.PricingId == monthlyIds).Average(y => y.Amount);


            return values;
        }
        public decimal GetAvgRentpriceForWeekly()
        {
            var weeklyIds = _context.Pricings.Where(p => p.Name == "Haftalık").Select(p => p.PricingId).FirstOrDefault();

            var values = _context.CarPricings.Where(x => x.PricingId == weeklyIds).Average(y => y.Amount);


            return values;
        }
        public decimal GetAvgRentpriceForDaily()
        {
            var dailyIds = _context.Pricings.Where(p => p.Name == "Günlük").Select(p => p.PricingId).FirstOrDefault();

            var values = _context.CarPricings.Where(x => x.PricingId == dailyIds).Average(y => y.Amount);


            return values;
        }
        public string GetCarBrandAndModelByRentPriceMax()
        {

            //SELECT TOP 1                               --> En üstteki (en pahalı) 1 kaydı al
            //    c.CarId,                               --> Aracın benzersiz kimliği
            //    b.Name AS BrandName,                   --> Markanın adı (Brands tablosundan)
            //    c.Model AS ModelName,                  --> Aracın modeli (Cars tablosundan)
            //    cp.Amount AS Price                     --> Fiyat bilgisi (CarPricings tablosundan)
            //FROM CarPricings AS cp                     --> Fiyat bilgilerini içeren temel tablo
            //INNER JOIN Cars AS c ON cp.CarId = c.CarId --> Her fiyat kaydını ilgili araçla eşleştir
            //INNER JOIN Brands AS b ON c.BrandId = b.BrandId --> Aracın markasını eşleştir
            //INNER JOIN Pricings AS p ON cp.PricingId = p.PricingId --> Fiyat türünü (günlük/haftalık) eşleştir
            //WHERE p.Name = 'Günlük'                    --> Sadece "Günlük" fiyat tipine sahip araçlar
            //ORDER BY cp.Amount DESC;                   --> Fiyatı büyükten küçüğe sırala (en pahalısı en üstte)



            // 1) "Günlük" isimli fiyat tipinin PricingId’sini buluyoruz
            var dailyPricingId = _context.Pricings
                .Where(p => p.Name == "Günlük")
                .Select(p => p.PricingId)
                .FirstOrDefault();

            if (dailyPricingId == 0)
                return "Günlük fiyatlandırma bulunamadı.";

            // 2) Günlük fiyatlara sahip araçlardan en pahalı olanı buluyoruz
            var result = _context.CarPricings
                .Where(cp => cp.PricingId == dailyPricingId)    // sadece Günlük fiyatlar
                .OrderByDescending(cp => cp.Amount)              // en pahalıyı en üste getir
                .Select(cp => new
                {
                    cp.Car.CarId,                                // aracın ID’si
                    cp.Car.Brand.Name,                           // markası
                    cp.Car.Model,                                // modeli
                    cp.Amount                                    // fiyatı
                })
                .FirstOrDefault();                               // ilk (en pahalı) kaydı al

            if (result == null)
                return "Veri bulunamadı.";

            // 3) Bilgileri güzelce formatlayarak döndür
            return $"CarId: {result.CarId} | {result.Name} {result.Model} — {result.Amount:0.##} ₺";
        }
        public string GetBrandNameByMaxCar()
        {
            var result = _context.Cars
                .GroupBy(c => c.Brand.Name)
                .Select(g => new
                {
                    BrandName = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(g => g.Count)
                .FirstOrDefault();

            if (result == null)
                return "Veri bulunamadı.";

            return $"{result.BrandName} - {result.Count} araç";
        }
        public string GetBlogTitleByMaxBlogComment()
        {
            var result = (from b in _context.Blogs
                          join c in _context.Comments
                            on b.BlogId equals c.BlogId into blogComments
                          select new
                          {
                              b.Title,
                              CommentCount = blogComments.Count()
                          })
                         .OrderByDescending(x => x.CommentCount)
                         .FirstOrDefault();

            if (result == null || result.CommentCount == 0)
                return "Herhangi bir yorumu olan blog bulunamadı.";

            return $"{result.Title} - {result.CommentCount} yorum";
        }


        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            var result = (from cp in _context.CarPricings
                          join c in _context.Cars on cp.CarId equals c.CarId
                          join b in _context.Brands on c.BrandId equals b.BrandId
                          join p in _context.Pricings on cp.PricingId equals p.PricingId
                          where p.Name == "Günlük"
                          orderby cp.Amount descending          // en pahalı en başa
                          select new
                          {
                              BrandName = b.Name,
                              ModelName = c.Model,
                              DailyPrice = cp.Amount
                          })
                          .FirstOrDefault();

            if (result == null)
                return "Günlük fiyat tanımlı araç bulunamadı.";

            var formattedPrice = result.DailyPrice.ToString("N2",
                new System.Globalization.CultureInfo("tr-TR"));

            return $"{result.BrandName} {result.ModelName} - {formattedPrice} ₺";
        }


        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            var result = (from cp in _context.CarPricings
                          join c in _context.Cars on cp.CarId equals c.CarId
                          join b in _context.Brands on c.BrandId equals b.BrandId
                          join p in _context.Pricings on cp.PricingId equals p.PricingId
                          where p.Name == "Günlük"
                          orderby cp.Amount ascending            // en ucuz en başa
                          select new
                          {
                              BrandName = b.Name,
                              ModelName = c.Model,
                              DailyPrice = cp.Amount
                          })
                          .FirstOrDefault();

            if (result == null)
                return "Günlük fiyat tanımlı araç bulunamadı.";

            var formattedPrice = result.DailyPrice.ToString("N2",
                new System.Globalization.CultureInfo("tr-TR"));

            return $"{result.BrandName} {result.ModelName} - {formattedPrice} ₺";
        }








    }
}
