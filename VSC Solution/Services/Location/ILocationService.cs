using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSC.Entityframeworkcore.Models;

namespace VSC_Solution.Services.Location
{
    public interface ILocationService
    {
        public List<Entity> GetLocationsIN100m(double latitude, double longtude);
    }
}
