using Information.Data;
using Information.Entity;

namespace Information.Repository
{
    public class FactorRepository : IFactorRepository
    {
        private readonly DataContext _dataContext;
        public FactorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Factor GetFactorById(int id)
        {
            return _dataContext.Factors.Find(id);
        }
        public Factor GetFactorByPaymentStatus(string PaymentStatus)
        {
            return _dataContext.Factors.Where(p => p.PaymentStatus == PaymentStatus).FirstOrDefault();
        }
    }
}
