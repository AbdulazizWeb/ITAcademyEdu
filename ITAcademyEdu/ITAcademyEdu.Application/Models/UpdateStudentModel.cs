namespace ITAcademyEdu.Application.Models
{
    public class UpdateStudentModel
    {
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Phone { get; set; }
    }
}
