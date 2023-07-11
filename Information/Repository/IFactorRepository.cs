using Information.Entity;

namespace Information.Repository
{
    public interface IFactorRepository
    {
        Factor GetFactorById(int id);
        Factor GetFactorByPaymentStatus(string PaymentStatus);
    }
}
