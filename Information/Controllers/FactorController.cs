using Amazon.Runtime.Internal.Transform;
using Information.Data;
using Information.Entity;
using Information.Repositories;
using Information.Repository;
using Information.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Text;

namespace Information.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactorController : ControllerBase
    {
        DataContext _context;
        private readonly IFactorRepository _factorRepository;
        private readonly IPassengerRepository _passengerRepository;
        public FactorController(DataContext dataContext, IPassengerRepository passengerRepository, IFactorRepository factorRepository)
        {
            _context = dataContext;
            _factorRepository = factorRepository;
            _passengerRepository = passengerRepository;
        }
        [HttpGet("get")]
        public ActionResult<Entity.Factor> GetInFactor(decimal TravelAmount)
        {
            var Factor = _context.Factors.Where(s => s.TravelAmount == TravelAmount).FirstOrDefault();
            if (Factor is null)
                return NotFound($"notfound FactorStatus with {TravelAmount}");
            else
                return Ok(Factor);
        }
        [HttpPost("AddFacttor")]
        public IActionResult InsertFactor(InsertFactorRequest request)
        {
            var insertFactor = _context.Factors.Where(s => s.TravelAmount == request.TravelAmount).FirstOrDefault();
            if (insertFactor is null)
            {
                insertFactor.CustomerId = request.CustomerId;
                insertFactor.PaymentStatus = request.PaymentStatus;
                insertFactor.Travel = request.Travel;
                insertFactor.FactorData = request.FactorData;
                insertFactor.AmountTrip = request.AmountTrip;
                insertFactor.Kilometr = request.Kilometr;
                insertFactor.TravelAmount = request.TravelAmount;
                var newPassenger = _context.Factors.Add(insertFactor);
                _context.SaveChanges();
                return Ok(newPassenger);
            }
            return BadRequest("فاکتوری با این مبلغ سفر یافت نشد");
        }
        [HttpPost("20%KasrGhaymat")]
        public IActionResult insertFactor(InsertFactorRequest request)
        {
            var existInfactor = _context.Factors.Where(s => s.TravelAmount == request.TravelAmount).FirstOrDefault();
            if (existInfactor is null)
            {
                Entity.Factor newfactor = new Entity.Factor()
                {
                    CustomerId = request.CustomerId,
                    PaymentStatus = request.PaymentStatus,
                    Travel = request.Travel,
                    FactorData = request.FactorData,
                    AmountTrip = request.AmountTrip,
                    TravelAmount = request.TravelAmount,
                    Kilometr = request.Kilometr,
                };

                var insertedFactor = _context.Factors.Add(newfactor);
                _context.SaveChanges();

                Passenger newPassenger = new Passenger()

                {
                    LastName = "",
                    FirstName = "",
                    PassengerPoint = 0,
                    NationalCode = 0,
                    Kilometr = 0,
                    TotalAmount = 0,
                };
                newPassenger.PassengerPoint = newPassenger.Kilometr * 10;
                if (newPassenger.PassengerPoint >= 50)
                {
                    newPassenger.TotalAmount = newPassenger.PassengerPoint * 20 % - newPassenger.TotalAmount;
                }
                else
                {
                    newPassenger.TotalAmount = newPassenger.Kilometr * 10000;
                }
                var insertedPassenger = _context.passengers.Add(newPassenger);
                _context.SaveChanges();
                return Ok();
            }
            return Ok();
        }
        [HttpDelete("DeleteFactor")]
        public IActionResult DeleteFactor(DeleteFactorRequest request) 
        {
            var deleteFactor = _context.Factors.Where(s => s.PaymentStatus == request.PaymentStatus).FirstOrDefault();
            if (deleteFactor != null) 
            {
                _context.Factors.Remove(deleteFactor);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound("فاکتوری با وضعیت پرداخت وارد یافت نشد");
        }
        [HttpPut("UpdateFactor")]
        public IActionResult UpdateFactor(decimal TravelDistance, UpdateFactorRequest request) 
        {
            if (ModelState.IsValid) 
            {
                var updateFactor = _context.Factors.Where(s => s.TravelAmount == request.TravelAmount).FirstOrDefault();
                if (updateFactor is not null) 
                {
                    if (request.FactorData != null) 
                        updateFactor.FactorData = request.FactorData;
                    if (request.CustomerId != null)
                        updateFactor.CustomerId = request.CustomerId;
                    if (request.Travel != null)
                        updateFactor.Travel = request.Travel;
                    if (request.PaymentStatus != null)
                        updateFactor.PaymentStatus = request.PaymentStatus;
                    if (request.TravelAmount != null)
                        updateFactor.TravelAmount = request.TravelAmount;
                    if (request.AmountTrip != null)
                        updateFactor.AmountTrip = request.AmountTrip;
                    if (request.Kilometr != null)
                        updateFactor.Kilometr = request.Kilometr;

                    var newFactor = _context.Factors.Update(updateFactor);
                    _context.SaveChanges();
                    return Ok(newFactor.Entity);
                }
                return NotFound("فاکتوری با وضعیت پرداخت درخواستی یافت نشد");
            }
            return BadRequest("اطلاعات ارسالی صحیح نمی باشد");
        }
    }
}
