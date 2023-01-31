using ITAcademyEdu.Application.Abstractions;
using ITAcademyEdu.Application.Models;
using ITAcademyEdu.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ITAcademyEdu.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IApplicationDbContext _context;


        public StudentService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CreateStudentModel model)
        {
            var entity = new Student()
            {
                Fullname = model.Fullname,
                BirthDate = model.BirthDate,
                Phone = model.Phone,
                CreatedDateTime = DateTime.UtcNow,
            };

            _context.Students.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception("Not found");
            }

            _context.Students.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StudentViewModel>> GetAllAsync()
        {
            return await _context.Students
                .Select(x => new StudentViewModel()
                {
                    Id = x.Id,
                    Fullname = x.Fullname,
                    BirthDate = x.BirthDate,
                    Phone = x.Phone
                })
                .ToListAsync();
        }

        public async Task<StudentViewModel> GetByIdAsync(int id)
        {
            var entity = await _context.Students.FirstOrDefaultAsync(u => u.Id == id);

            return new StudentViewModel()
            {
                Id = entity.Id,
                Fullname = entity.Fullname,
                BirthDate = entity.BirthDate,
                Phone = entity.Phone

            };
        }

        public async Task UpdateAsync(UpdateStudentModel model)
        {
            var entity = await _context.Students.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (entity == null)
            {
                throw new Exception("Not found");
            }

            entity.Fullname = model.Fullname ?? entity.Fullname;
            entity.BirthDate = model.BirthDate ?? entity.BirthDate;
            entity.Phone = model.Phone ?? entity.Phone;

            _context.Students.Update(entity);
            await _context.SaveChangesAsync();

        }
    }
}
