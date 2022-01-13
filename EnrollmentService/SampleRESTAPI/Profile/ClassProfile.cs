using AutoMapper;

namespace SampleRESTAPI.Models
{
    public class ClassProfile : Profile
    {
        public ClassProfile()
        {
            CreateMap<Models.Course, Dtos.CourseDto>().
                ForMember(dest => dest.TotalHours,
                opt => opt.MapFrom(src => src.Credits * 3));
        }
    }
}
