using AutoMapper;
using EnrollmentService.Dtos;

namespace EnrollmentService.Models
{
    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<Enrollment, CreateEnrollmentDto>();
            CreateMap<CreateEnrollmentDto, Enrollment>();
        }
    }
}
