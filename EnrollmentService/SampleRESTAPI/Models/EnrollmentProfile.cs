using AutoMapper;
using SampleRESTAPI.Dtos;

namespace SampleRESTAPI.Models
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
