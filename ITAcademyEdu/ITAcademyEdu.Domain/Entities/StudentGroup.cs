using ITAcademyEdu.Domain.Enums;

namespace ITAcademyEdu.Domain.Entities
{
    public class StudentGroup
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentId { get; set; }
        public int GroupId { get; set; }
        public DateTime JoinedDate { get; set; }
        public bool IsPayed { get; set; }

        public Student Student { get; set; }
        public Group Group { get; set; }
    }
}