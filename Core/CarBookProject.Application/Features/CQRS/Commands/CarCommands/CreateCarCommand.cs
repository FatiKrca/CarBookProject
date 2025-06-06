﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Commands.CarCommands
{
    public class CreateCarCommand
    {
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
