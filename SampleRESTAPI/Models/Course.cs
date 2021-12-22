using System.ComponentModel.DataAnnotations;

namespace SampleRESTAPI.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

    }
}
