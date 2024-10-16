﻿namespace CarBook.Domain.Entities
{
	public class Location
	{
		public int LocationID { get; set; }
		public string Name { get; set; }
		public string Maps { get; set; }
        public List<RentACar> RentACars { get; set; }
        public List<Reservation> PickUpReservation { get; set; }
        public List<Reservation> DropOffReservation { get; set; }

    }
}
