using System.ComponentModel.DataAnnotations;

namespace ITAcademyEdu.Application.Models
{
    public class CreateTeacherModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        public string Fullname { get; set; }
    }
}
