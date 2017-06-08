using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjChallenge.Models
{
    public class Hotel
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Stars { get; set; }

        public string ReviewPoints { get; set; }

        public string TotalReviews { get; set; }

        public string Description { get; set; }

        public List<Hotel> AlternativeHotels { get; set; }

        public List <Room> Rooms{ get; set; }
    }
}