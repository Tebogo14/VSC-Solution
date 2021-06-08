using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VSC.Entityframeworkcore.Models;
using VSC_Solution.Services.Location;

namespace VSC_Solution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistanceController : ControllerBase
    {

        private readonly ILocationService _locationService;

        public DistanceController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        [Route("GetPlaceIn100m")]
        public List<Entity> GetPlaceIn100m(double latitude , double longitude)
        {
            return _locationService.GetLocationsIN100m(latitude, longitude);
        }
    }
}
