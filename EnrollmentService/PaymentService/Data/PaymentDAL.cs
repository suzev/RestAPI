using PaymentService.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentService.Data
{
    public class PaymentDAL : IPayment
    {
        private readonly Kasus1Context _db;

        public PaymentDAL (Kasus1Context db)
        {
            _db = db;
        }
        public Task<IEnumerable> CreatePayment(PaymentInput paymentInput)
        {
            throw new System.NotImplementedException();
        }
    }
}
