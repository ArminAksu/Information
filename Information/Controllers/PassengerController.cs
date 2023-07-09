using Information.Data;
using Information.Repositories;
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
        private readonly ITripRepository _tripRepository;
        public PassengerController(DataContext context, IPassengerRepository passengerRepository, ITripRepository tripRepository)
        {
            _context = context;
            _passengerRepository = passengerRepository;
            _tripRepository = tripRepository;
        }
        [HttpGet("getprods")]
        public ActionResult<Entity.Passenger> GetInPassenger(string PassengerPoint)
        {
            var passenger = _context.passengers.Where(s => s.PassengerPoint == PassengerPoint).FirstOrDefault();
            if (passenger is null)
                return NotFound($"notfound PassengerPerson with {PassengerPoint}");
            else
                return Ok(passenger);
        }
    }
}
