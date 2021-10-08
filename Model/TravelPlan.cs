
using System;

namespace Adesso.Model
{
    public sealed class TravelPlan
    {
        public int TravelPlanId { get; set; }
        public string StartCity { get; set; }
        public string DestinationCity { get; set; }
        public DateTime Date { get; set; }
        public int SeatCount { get; set; }
        public int EmptySeatCount { get; set; }

        public int CustomerId { get; set; }
        public bool IsActive { get; set; }

    }
}