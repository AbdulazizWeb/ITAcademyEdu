using ITAcademyEdu.Domain.Enums;

namespace ITAcademyEdu.Domain.Entities
{
    public class User
    {

        public User()
        {
            Groups = new HashSet<Group>();
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Fullname { get; set; }
        public UserRole Role { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}