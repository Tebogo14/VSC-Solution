using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSC.Entityframeworkcore.EntityFramework;
using VSC.Entityframeworkcore.Models;

namespace VSC_Solution.Services.Location
{
    public class LocationService :ILocationService
    {

        private readonly VSCDbContext _context;

        public LocationService(VSCDbContext context)
        {
            _context = context;
        }

        public List<Entity> GetLocationsIN100m(double latitude , double longtude)
        {

            var entities = new List<Entity>();

            var sCoord = new GeoCoordinate(latitude, longtude);

            var customers = _context.Entities.ToList();


            foreach (var customer in customers)
            {
                var location = customer.Location.Split(',');

                var customerLatitude = double.Parse(location[0].Replace(".",",").Trim());
                var customerLongtude = double.Parse(location[1].Replace(".", ",").Trim());

                var eCoord = new GeoCoordinate(customerLatitude, customerLongtude);

                var distance = sCoord.GetDistanceTo(eCoord);

                if(distance <= 100)
                {
                    entities.Add(customer);
                }
            }

            return entities;

        }
    }
}
