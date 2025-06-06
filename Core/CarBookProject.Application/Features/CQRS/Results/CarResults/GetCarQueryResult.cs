﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Features.CQRS.Results.CarResults
{
    public class GetCarQueryResult
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string CoverImgUrl { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Lugage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
    }
}
