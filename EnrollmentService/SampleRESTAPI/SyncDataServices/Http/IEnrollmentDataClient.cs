using SampleRESTAPI.Dtos;
using System.Threading.Tasks;

namespace SampleRESTAPI.SyncDataServices.Http
{
    public interface IEnrollmentDataClient
    {
        Task CreateEnrollmentFromPaymentService(CreateEnrollmentDto enrollment);
    }
}
