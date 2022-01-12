using AutoMapper;

namespace SampleRESTAPI.Models
{
    public class ClassProfile : Profile
    {
        /*
         *  {
            CreateMap<Models.Student, Dtos.StudentDto>()
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
        */

        public ClassProfile()
        {
            CreateMap<Models.Course, Dtos.CourseDto>().
                ForMember(dest => dest.TotalHours,
                opt => opt.MapFrom(src => src.Credits * 3));
        }

    }
}
