
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Adesso.Data;
using Adesso.Model;
using Adesso.ViewModel;

namespace Adesso.Services
{
    public sealed class TravelService : ITravelService
    {
        /* 1. */
        public string AddTravelPlan(TravelPlanAddViewModel model)
        {

            if(!DateTime.TryParse(model.Date, out var date))
            {
                return $"Geçerli bir tarih değeri giriniz!";
            }

            var travelPlan = new TravelPlan
            {
                CustomerId = model.CustomerId,
                Date = date,
                DestinationCity = model.DestinationCity,
                StartCity = model.StartCity,
                IsActive = true,
                SeatCount = model.SeatCount,
                EmptySeatCount = model.SeatCount,
                TravelPlanId = TravelPlans.GetTravelPlanId()
            };

            TravelPlans.AddData(travelPlan);

            return $"Başarıyla kaydedilmiştir.";
        }

        public string SetTravelPlanStatus(TravelPlanSetStatusViewModel model)
        {
            return TravelPlans.SetTravelPlanStatus(model);
        }

        public List<TravelPlanGetViewModel> GetTravelPlans(string startCity, string destinationCity)
        {
            return TravelPlans.GetTravelPlans(startCity, destinationCity);
        }

        public string SendRequest(SendRequestViewModel model)
        {
            return TravelPlans.SendRequest(model);
        }

        /* 2. */

        public string FindPossibleRoutes(string startCity, string destinationCity)
        {
            var result = CityCoordinates.GetTravelPlans(startCity, destinationCity);

            return result;
        }
    
    }
}