using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleRESTAPI.Dtos
{
    public class CourseForCreateDto : IValidatableObject
    {
        [Required]
        public string Title { get; set; }
        [Required]
        //[Column(TypeName ="decimal(5,2)")]
        public int Credits { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Credits > 10)
            {
                yield return new ValidationResult("Credits Tidak Boleh Lebih dari 10",
                    new[] { "Credits" });
            }

            if(Title.Length > 50 || !Title.StartsWith("Training"))
            {
                yield return new ValidationResult("Harus dimulai dengan kata Training dan tidak boleh lebih dari 50",
                    new[] { "Title" });
            }
        }
    }
}
