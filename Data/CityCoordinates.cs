
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adesso.Data
{
    public static class CityCoordinates
    {
        private static IDictionary<string, CityCoordinate> CityCoordinatesData = new Dictionary<string, CityCoordinate>()
        {


            { "adn", new CityCoordinate { X = 0, Y = 0 } },
            { "ist", new CityCoordinate { X = 1, Y = 0 } },
            { "ank", new CityCoordinate { X = 2, Y = 0 } },
            { "mns", new CityCoordinate { X = 3, Y = 0 } },
            { "svs", new CityCoordinate { X = 4, Y = 0 } },
            { "grs", new CityCoordinate { X = 5, Y = 0 } },
            { "tnc", new CityCoordinate { X = 6, Y = 0 } },
            { "dyb", new CityCoordinate { X = 7, Y = 0 } },

            { "edr", new CityCoordinate { X = 0, Y = 1 } },
            { "tkr", new CityCoordinate { X = 0, Y = 2 } },
            { "cnk", new CityCoordinate { X = 0, Y = 3 } },
            { "ord", new CityCoordinate { X = 0, Y = 4 } },
            { "crm", new CityCoordinate { X = 0, Y = 5 } },
            { "dzc", new CityCoordinate { X = 0, Y = 6 } },
            { "kce", new CityCoordinate { X = 0, Y = 7 } },

            // ...
        };

        private static CityCoordinate GetCoordinate(string cityName)
        {
            var cityCoordinate = CityCoordinatesData.FirstOrDefault(p => p.Key == cityName);

            return new CityCoordinate
            {
                X = cityCoordinate.Value.X,
                Y = cityCoordinate.Value.Y
            };
        }


        public static string GetTravelPlans(string startCity, string destinationCity)
        {
            var allRoutes = TravelPlans.GetCityNameViewModel();

            var startCoordinate = GetCoordinate(startCity);
            var destinationCoordinate = GetCoordinate(destinationCity);


            // while (true)
            // {
            //     var routeStartCoordinate = GetCoordinate(route.StartCityName);
            //     var routeDestinationCoordinate = GetCoordinate(route.DestinationCityName);
            // }

            var possibleOnes = new StringBuilder();

            for (int i = startCoordinate.X; i <= destinationCoordinate.X; i++)
            {
                foreach (var route in allRoutes)
                {
                    var routeStartCoordinate = GetCoordinate(route.StartCityName);
                    var routeDestinationCoordinate = GetCoordinate(route.DestinationCityName);

                    if(routeStartCoordinate.X >= i && routeStartCoordinate.X <= destinationCoordinate.X)
                    {
                        possibleOnes.AppendLine($"{route.StartCityName} - {route.DestinationCityName}");
                    }
                }
            }

            for (int i = startCoordinate.Y; i <= destinationCoordinate.Y; i++)
            {
                foreach (var route in allRoutes)
                {
                    var routeStartCoordinate = GetCoordinate(route.StartCityName);
                    var routeDestinationCoordinate = GetCoordinate(route.DestinationCityName);

                    if(routeStartCoordinate.Y >= i && routeStartCoordinate.Y <= destinationCoordinate.Y)
                    {
                        possibleOnes.AppendLine($"{route.StartCityName} - {route.DestinationCityName}");
                    }
                }
            }

            if(possibleOnes.Length < 1)
            {
                return $"Plan bulunamadı!";
            }

            return possibleOnes.ToString();
        }
    }
}