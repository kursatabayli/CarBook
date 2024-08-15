﻿using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarCommands
{
	public class CreateCarCommand:IRequest
	{
        public int BrandID { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public int CarTransmissionID { get; set; }
        public byte Seat { get; set; }
        public int CarLuggageID { get; set; }
        public int CarFuelID { get; set; }
        public string BigImageUrl { get; set; }
    }
}
