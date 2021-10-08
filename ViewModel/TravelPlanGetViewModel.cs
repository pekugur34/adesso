

using System;

namespace Adesso.ViewModel
{
    public sealed class TravelPlanGetViewModel
    {
        public string StartCity { get; set; }
        public string DestinationCity { get; set; }
        public string Date { get; set; }
        public int SeatCount { get; set; }
        public int EmptySeatCount { get; set; }

    }
}