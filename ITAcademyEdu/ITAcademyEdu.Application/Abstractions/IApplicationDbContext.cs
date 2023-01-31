using ITAcademyEdu.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ITAcademyEdu.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Domain.Entities.Group> Groups { get; set; }
        DbSet<StudentGroup> StudentGroups { get; set; }
        DbSet<Lesson> Lessons { get; set; }
        DbSet<Attendance> Attendances { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
