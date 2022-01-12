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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(!Title.StartsWith("Training") || Title.Length>=50)
            {
                yield return new ValidationResult("Harus diawali dengan kata Training",
                new[] { "Title" });
            }

            if(Credits >= 10)
            {
                yield return new ValidationResult("Harus lebih kecil dari 10 karakter",
                new[] { "Credit" });
            }

        }
    }
}
