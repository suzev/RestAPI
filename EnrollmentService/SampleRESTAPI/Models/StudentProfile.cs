using AutoMapper;

namespace SampleRESTAPI.Models
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Models.Student, Dtos.StudentDto>()
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<Dtos.StudentForCreateDto, Models.Student>();

        }
    }
}