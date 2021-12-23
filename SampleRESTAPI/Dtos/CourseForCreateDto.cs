namespace SampleRESTAPI.Dtos
{
    public class CourseForCreateDto
    {
        public string Title { get; set; }

        //[Column(TypeName ="decimal(5,2)")]
        public int Credits { get; set; }
    }
}
