

using System.Collections.Generic;
using System.Threading.Tasks;
using Adesso.ViewModel;

namespace Adesso.Services
{
    public interface ITravelService
    {
        string AddTravelPlan(TravelPlanAddViewModel model);
        string SetTravelPlanStatus(TravelPlanSetStatusViewModel model);
        List<TravelPlanGetViewModel> GetTravelPlans(string startCity, string destinationCity);
        string SendRequest(SendRequestViewModel model);
        string FindPossibleRoutes(string startCity, string destinationCity);
    }
}