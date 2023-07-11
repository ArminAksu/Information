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
        [HttpPost("TravelDistance")]
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
                    Kilometr = request.Kilometr,
                };

                var insertedTrip = _context.trips.Add(newTrip);
                _context.SaveChanges();

                Factor newFactor = new Factor()
                {
                    TravelAmount = 10000,
                    Travel = "0",
                    FactorData = "0",
                    CustomerId = "0",
                    AmountTrip = 0,
                    Kilometr = 20,
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
                    if (TravelDistance == null)
                        return BadRequest("مسافت سفر را وارد کنید");

                    var newTrip = _context.trips.Update(updateTrip);
                    _context.SaveChanges();
                    return Ok(newTrip.Entity);
                }
                return NotFound("شخص برای سفر یافت نشد");
            }
            return BadRequest("اطلاعات ارسالی صحیح نمی باشد");
        }
        [HttpPost("PassengerPoint")]
        public IActionResult insertTrip(InsertTripRequest request)
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
                    Kilometr = request.Kilometr,
                };

                var insertedTrip = _context.trips.Add(newTrip);
                _context.SaveChanges();

                Passenger newPassenger = new Passenger()

                {
                    FirstName = "o",
                    LastName = "o",
                    NationalCode = 0,
                    TotalAmount = 0,
                    Kilometr = 0,
                    PassengerPoint = 0,
                };
                newPassenger.Kilometr = newPassenger.PassengerPoint * 10;

                var insertTrip = _context.trips.Add(newTrip);
                _context.SaveChanges();
                return Ok();
            }
            return Ok();

        }
        [HttpDelete("DeleteTrip")]
        public IActionResult DeleteTrip(DeleteTripRequest request)
        {
            var deleteTrip = _context.trips
                .Where(s => s.TravelDistance == request.TravelDistance).FirstOrDefault();
            if (deleteTrip is not null)
            {
                _context.trips.Remove(deleteTrip);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound("هنرجویی با کد ملی وارد شده یافت نشد");
        }
        [HttpGet("AddGetsets")]
        public ActionResult<Trip> GetProduct(String TravelDistance)
        {
            var Trip = _context.trips.Where(s => s.TravelDistance == TravelDistance).FirstOrDefault();
            if (Trip is null)
                return NotFound($"not found trip with {TravelDistance}");
            else
                return Ok(Trip);
        }
        [HttpPut("UpdateTrip")]
        public IActionResult updateTrip(string TravelDistance, UpdateTripRequest request)
        {
            if (ModelState.IsValid)
            {
                var updateTrip = _context.trips.Where(s => s.TravelDistance == TravelDistance).FirstOrDefault();
                if (updateTrip is not null)
                {
                    if (request.TravelDistance != null)
                        updateTrip.TravelDistance = request.TravelDistance;
                    if (request.TravelNumber != null)
                        updateTrip.TravelNumber = request.TravelNumber;
                    if (request.StaretTime != null)
                        updateTrip.StartTime = request.StaretTime;
                    if (request.EndTime != null)
                        updateTrip.EndTime = request.EndTime;

                    var newTrip = _context.trips.Update(updateTrip);
                    _context.SaveChanges();
                    return Ok(newTrip.Entity);
                }
                return NotFound("سفری با همچین مسافت سفری در خواستی یافت نشد");
            }
            return BadRequest("اطاعات ارسالی صحیح نمی باشد");
        }
    }
}




