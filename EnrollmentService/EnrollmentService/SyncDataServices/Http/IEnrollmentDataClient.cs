using EnrollmentService.Dtos;
using System.Threading.Tasks;

namespace EnrollmentService.SyncDataServices.Http
{
    public interface IEnrollmentDataClient
    {
        Task CreateEnrollmentFromPaymentService(CreateEnrollmentDto enrollment);
    }
}
