using Information.Data;
using Information.Entity;

namespace Information.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly DataContext _dataContext;
        public PassengerRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }
        public Passenger GetPassengerById(int id)
        {
            return _dataContext.passengers.Find(id);
        }
        public Passenger GetPassengerByPassengerPoint(int PassengerPoint) 
        {
            return _dataContext.passengers.Where(p => p.PassengerPoint == PassengerPoint).FirstOrDefault();
        }
    }
}
