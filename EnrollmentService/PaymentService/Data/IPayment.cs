using PaymentService.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentService.Data
{
    public interface IPayment
    {
        Task CreatePayment (Enrollment enrollment);

    }
}
