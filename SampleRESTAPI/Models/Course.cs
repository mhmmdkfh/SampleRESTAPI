using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleRESTAPI.Models
{
    //[Table("Course")]
    public class Course
    {
        //[Column("Course_id")]
        public int CourseID { get; set; }
        
        //[Column("Judul")]
        //[MaxLength(255)]
        public string Title { get; set; }

        //[Column(TypeName ="decimal(5,2)")]
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
