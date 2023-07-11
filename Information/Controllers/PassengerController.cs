using Information.Data;
using Information.Entity;
using Information.Repositories;
using Information.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Information.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        DataContext _context;
        private readonly IPassengerRepository _passengerRepository;
        //private readonly ITripRepository _tripRepository;
        public PassengerController( IPassengerRepository passengerRepository, ITripRepository tripRepository)
        {
            //_context = context;
            _passengerRepository = passengerRepository;
            //_tripRepository = tripRepository;
        }
        [HttpGet("getprods")]
        public ActionResult<Entity.Passenger> GetInPassenger(int passengerId)
        {
            //var passenger = _context.passengers.Where(s => s.Id == passengerId).FirstOrDefault();
            var passenger = _passengerRepository.GetPassengerById(passengerId);
            if (passenger is null)
                return NotFound($"notfound PassengerPerson with {passengerId}");
            else
                return Ok(passenger);
        }
        [HttpPut("UpdatePassenger")]
        public IActionResult UpdatePassenger(int PassengerPoint, UpdatePassengerRequest request)
        {
            if (ModelState.IsValid)
            {
                var updatePassenger = _context.passengers.Where(S => S.PassengerPoint == PassengerPoint).FirstOrDefault();
                if (updatePassenger is not null)
                {
                    if (request.FirstName != null)
                        updatePassenger.FirstName = request.FirstName;
                    if (request.LastName != null)
                        updatePassenger.LastName = request.LastName;
                    if (request.PassengerPoint != null)
                        updatePassenger.PassengerPoint = request.PassengerPoint;
                    if (request.Kilometr != null)
                        updatePassenger.Kilometr = request.Kilometr;
                    if (request.TotalAmount != null)
                        updatePassenger.TotalAmount = request.TotalAmount;

                    var newPassenger = _context.passengers.Update(updatePassenger);
                    _context.SaveChanges();
                    return Ok(newPassenger.Entity);
                }
                return NotFound("مسافری با همچین امتیازی یافت نشد");
            }
            return BadRequest("اطلاعات ارسالی صحیح نمی باشد");
        }
        [HttpPost("AddPassenger")]
        public IActionResult InsertPassenger(InsertPassengerRequest request) 
        {
            var insertPassenger = _context.passengers.Where(s => s.PassengerPoint == request.PassengerPoint).FirstOrDefault();
            if (insertPassenger is null) 
            {
                insertPassenger.PassengerPoint = request.PassengerPoint;
                insertPassenger.FirstName = request.FirstName;
                insertPassenger.LastName = request.LastName;
                insertPassenger.NationalCode = request.NationalCode;
                insertPassenger.TotalAmount = request.TotalAmount;
                insertPassenger.Kilometr = request.Kilometr;
                var newPassenger = _context.passengers.Add(insertPassenger);
                _context.SaveChanges();
                return Ok(newPassenger);
            }
            return BadRequest("مسافری با این امتیاز سفر ثبت نشده است");
        }
        [HttpDelete("DeletePassenger")]
        public IActionResult DeletePassenger(DeletePassengerRequest request) 
        {
            var deletePassenger = _context.passengers.Where(s => s.PassengerPoint == request.PassengerPoint).FirstOrDefault();
            if (deletePassenger is not null)
            {
                _context.passengers.Remove(deletePassenger);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound("مسافری با امتیاز مسافر یافت نشد");
        }
        [HttpPost("RandomTravelDistance")]
        public IActionResult insertPassenger(InsertPassengerRequest request)
        {
            var existPassenger = _context.passengers.Where(s => s.PassengerPoint == request.PassengerPoint).FirstOrDefault();
            if (existPassenger is null)
            {
                Entity.Passenger newPassenger = new Entity.Passenger()
                {
                    PassengerPoint = request.PassengerPoint,
                    LastName = request.LastName,
                    FirstName = request.FirstName,
                    NationalCode = request.NationalCode,
                    Kilometr = request.Kilometr,
                    TotalAmount = request.TotalAmount,
                };

                var insertedPassenger = _context.passengers.Add(newPassenger);
                _context.SaveChanges();

                Trip newtrip = new Trip()

                {
                    StartTime = "0",
                    EndTime = "0",
                    TravelDistance = "0",
                    TravelNumber = "0",
                    Kilometr = 0,
                };
                Random rnd = new Random();
                var rand = new Random().Next(2,11);
                for (int Kilometr = 2; Kilometr <= 11; Kilometr++) 
                {
                    
                    newtrip.TravelDistance = newtrip.StartTime;
                }

                var insertTrip = _context.trips.Add(newtrip);
                _context.SaveChanges();
                return Ok();
            }
            return Ok();
        }
    }
}
