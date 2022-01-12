using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleRESTAPI.Dtos
{
    public class CourseForCreateDto : IValidatableObject
    {
        [Required]
        public string Title { get; set; }

        [Required]
        
        public int Credits { get; set; }

        public double Price { get; set; }
    }
}
