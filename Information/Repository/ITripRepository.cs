using Information.Entity;

namespace Information.Repositories
{
    public interface ITripRepository
    {
        Trip UpdateTrip(Trip trip);
        IEnumerable<Trip> GetTrips();
        Trip GetTrip(int id);
    }
}
