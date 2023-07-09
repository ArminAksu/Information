using Information.Data;
using Information.Entity;
using Information.Repositories;
using Information.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Information.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        DataContext _context;
        private readonly IPassengerRepository _passengerRepository;
        private readonly ITripRepository _tripRepository;
        public TripController(DataContext context, IPassengerRepository passengerRepository, ITripRepository tripRepository)
        {
            _context = context;
            _passengerRepository = passengerRepository;
            _tripRepository = tripRepository;
        }
        [HttpPost("AddTravelDistance")]
        public IActionResult InsertTrip(InsertTripRequest request)
        {
            var existTrip = _context.trips.Where(s => s.TravelDistance == request.TravelDistance).FirstOrDefault();
            if (existTrip is null)
            {
                Entity.Trip newTrip = new Entity.Trip()
                {
                    TravelDistance = request.TravelDistance,
                    TravelNumber = request.TravelNumber,
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                };

                var insertedTrip = _context.trips.Add(newTrip);
                _context.SaveChanges();

                Factor newFactor = new Factor()
                {
                    TravelAmount = "10000",
                    Travel = "0",
                    FactorData = "0",
                    CustomerId = "0",
                    AmountTrip = 0,
                    Kilometr= 20,
                };
                newFactor.AmountTrip = newFactor.Kilometr * 10000;

                var insertTrip = _context.trips.Add(newTrip);
                _context.SaveChanges();
                return Ok();
            }
            return Ok();
        }
        [HttpPut("trip")]
        public IActionResult UpdateTrip(string TravelDistance, UpdateTripRequest request)
        {
            if (ModelState.IsValid)
            {
                var updateTrip = _context.trips.Where(s => s.TravelDistance == TravelDistance).FirstOrDefault();
                if (updateTrip is not null)
                {

                    var newTrip = _context.trips.Update(updateTrip);
                    _context.SaveChanges();
                    return Ok(newTrip.Entity);
                }
                return NotFound("شخص برای سفر یافت نشد");
            }
            return BadRequest("اطلاعات ارسالی صحیح نمی باشد");
        }

    }
}




