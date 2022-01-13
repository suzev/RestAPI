
using Microsoft.Extensions.Configuration;
using EnrollmentService.Dtos;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EnrollmentService.SyncDataServices.Http
{
    public class HttpEnrollmentDataClient : IEnrollmentDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpEnrollmentDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task CreateEnrollmentFromPaymentService(CreateEnrollmentDto enrollment)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(enrollment),
                Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_configuration["PaymentService"], httpContent);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"==> Sync Post to Payment Service Success");
            }
            else
            {
                Console.WriteLine($"==> Sync Post to Enrollment Service Failed. . .");
            }
        }
    }
}
