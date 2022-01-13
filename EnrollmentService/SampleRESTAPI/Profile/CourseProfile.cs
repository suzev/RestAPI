using AutoMapper;

namespace SampleRESTAPI.Models
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            {
                CreateMap<Models.Course, Dtos.CourseDto>().
                    ForMember(dest => dest.TotalHours,
                    opt => opt.MapFrom(src => src.Credits * 3));
            }

            CreateMap<Dtos.CourseForCreateDto, Models.Course>();
        }
    }
}
