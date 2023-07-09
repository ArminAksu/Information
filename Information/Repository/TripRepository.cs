using Information.Data;
using Information.Entity;

namespace Information.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly DataContext _dataContext;
        public TripRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Trip GetTrip(int id)
        {
            var result = _dataContext.trips.Find(id);
            return result;
        }
        public IEnumerable<Trip> GetTrips() 
        {
            return _dataContext.trips.ToList();
        }
        public Trip UpdateTrip(Trip trip)
        {
            var result = _dataContext.trips.Update(trip).Entity;
            return result;
        }

    }
}
