using PaymentService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentService.Data
{
    public class PaymentDAL : IPayment<Payment>
    {
        private AppDbContext _db;

        public PaymentDAL (AppDbContext db)
        {
            _db = db;
        }
        public Task<IEnumerable<Payment>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Payment> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Payment> Insert(Payment obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
