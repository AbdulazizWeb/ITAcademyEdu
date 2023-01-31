using System.ComponentModel.DataAnnotations;

namespace ITAcademyEdu.Application.Models
{
    public class CreateStudentModel
    {
        [Required]
        public string? Fullname { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreateDateTime { get; set; }
        [Required]
        public string? Phone { get; set; }
    }
}
