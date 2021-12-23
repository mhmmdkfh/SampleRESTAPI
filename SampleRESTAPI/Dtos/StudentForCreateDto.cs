using SampleRESTAPI.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleRESTAPI.Dtos
{
    [StudentFirstLastMustBeDifferentAttribute]
    public class StudentForCreateDto
    {
        [Required(ErrorMessage ="FirstName tidak boleh kosong")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName tidak boleh kosong")]
        public string LastName { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }

        /*public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FirstName == LastName)
            {
                yield return new ValidationResult("FirstName dan LastName tidak boeh sama",
                    new[] { "StudentForCreateDto" });
            }
        }*/
    }
}
