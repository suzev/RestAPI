using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Data;
using PaymentService.Models;
using System;
using System.Threading.Tasks;

namespace PaymentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollment _enrollment;
        private readonly IMapper _mapper;

        public EnrollmentsController (IEnrollment enrollment, IMapper mapper)
        {
            _enrollment = enrollment;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateEnrollment (CreateEnrollmentDto createEnrollmentDto)
        {
            try
            {
                var dto = _mapper.Map<Enrollment>(createEnrollmentDto);
                await _enrollment.CreateEnrollment(dto);
                return Ok($"Data Enrollment StudentID: {createEnrollmentDto.StudentId} dan CourseId: {createEnrollmentDto.CourseId}");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
