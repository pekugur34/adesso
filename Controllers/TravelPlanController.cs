using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adesso.Services;
using Adesso.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Adesso.Controllers
{
    // [ApiController]
    // [Route("[controller]/[action]")]
    public class TravelPlanController : ControllerBase
    {

        private readonly ITravelService _travelService;

        public TravelPlanController(ITravelService travelService)
        {
            _travelService = travelService;
        }

        /* 1. */

        [HttpPost]
        public string Add([FromBody]TravelPlanAddViewModel travelPlanAddViewModel)
        {
            return _travelService.AddTravelPlan(travelPlanAddViewModel);
        }

        public string SetStatus([FromBody]TravelPlanSetStatusViewModel travelPlanSetStatusViewModel)
        {
            return _travelService.SetTravelPlanStatus(travelPlanSetStatusViewModel);
        }

        public List<TravelPlanGetViewModel> GetTravelPlans([FromQuery]string startCity, [FromQuery]string destinationCity)
        {
            return _travelService.GetTravelPlans(startCity, destinationCity);
        }

        public string SendRequest([FromBody]SendRequestViewModel model)
        {
            return _travelService.SendRequest(model);
        }

        /* 2. */
        public string FindPossibleRoutes([FromQuery]string startCity, [FromQuery]string destinationCity)
        {
            return _travelService.FindPossibleRoutes(startCity, destinationCity);
        }

    }
}
