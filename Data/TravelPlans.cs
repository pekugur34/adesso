
using System.Collections.Generic;
using Adesso.Model;
using System.Linq;
using Adesso.ViewModel;

namespace Adesso.Data
{
    public static class TravelPlans
    {
        private static List<TravelPlan> TravelPlansData = new List<TravelPlan>();

        public static int GetTravelPlanId()
        {
            if(TravelPlansData.Count < 1) return 1;
            return TravelPlansData.Max(p => p.TravelPlanId) + 1;
        }

        public static void AddData(TravelPlan travelPlan)
        {
            TravelPlansData.Add(travelPlan);
        }

        public static string SetTravelPlanStatus(TravelPlanSetStatusViewModel model)
        {
            var entity = TravelPlansData.FirstOrDefault(p => p.TravelPlanId == model.TravelPlanId);

            if(entity is null)
            {
                return $"Seyahat planı bulunamadı!";
            }

            entity.IsActive = model.IsActive;

            return $"Başarıyla kaydedilmiştir.";
        }


        public static List<TravelPlanGetViewModel> GetTravelPlans(string startCity, string destinationCity)
        {
            var list = (from t in TravelPlansData
                        where t.IsActive
                        select new TravelPlanGetViewModel
                        {
                            Date = t.Date.ToShortDateString(),
                            DestinationCity = t.DestinationCity,
                            SeatCount = t.SeatCount,
                            StartCity = t.StartCity,
                            EmptySeatCount = t.EmptySeatCount
                        }).ToList();
            
            return list;
        }

        public static string SendRequest(SendRequestViewModel model)
        {
            var travelPlan = TravelPlansData.FirstOrDefault(p => p.TravelPlanId == model.TravelPlanId && p.IsActive);

            if(travelPlan is null)
            {
                return $"Seyahat planı bulunamadı!";
            }

            if(travelPlan.EmptySeatCount < 1)
            {
                return $"Seyahat planında boş koltuk bulunmamaktadır!";
            }

            travelPlan.EmptySeatCount--;

            return $"Başarıyla kaydedilmiştir.";
        }

        public static List<CityNameGetViewModel> GetCityNameViewModel()
        {
            var list = new List<CityNameGetViewModel>();
            foreach (var item in TravelPlansData.Where(p => p.IsActive).ToList())
            {
                list.Add(new CityNameGetViewModel { StartCityName = item.StartCity, DestinationCityName = item.DestinationCity });
            }

            return list;
        }

    }
}