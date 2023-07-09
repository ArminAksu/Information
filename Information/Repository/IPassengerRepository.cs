using Information.Entity;

namespace Information.Repositories
{
    public interface IPassengerRepository
    {
        Passenger GetPassengerById(int id);
        Passenger GetPassengerByPassengerPoint(string PassengerPoint);
    }
}
