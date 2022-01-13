using PaymentService.Models;

namespace PaymentService.Profile
{
    public class PaymentsProfile : AutoMapper.Profile
    {
       public PaymentsProfile()
        {
            CreateMap<PaymentInput, Enrollment>();
        }
    }
}
