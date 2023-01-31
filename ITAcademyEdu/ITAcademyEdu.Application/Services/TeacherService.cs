using ITAcademyEdu.Application.Abstractions;
using ITAcademyEdu.Application.Models;
using ITAcademyEdu.Domain.Entities;
using ITAcademyEdu.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ITAcademyEdu.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IApplicationDbContext _context;
        private readonly IHashProvider _hashProvider;


        public TeacherService(IApplicationDbContext context, IHashProvider hashProvider)
        {
            _context = context;
            _hashProvider = hashProvider;
        }

        public async Task CreateAsync(CreateTeacherModel model)
        {
            var entity = new User()
            {
                Username = model.Username,
                PasswordHash = _hashProvider.GetHash(model.Password),
                Fullname = model.Fullname,
                Role = UserRole.Teacher
            };

            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == id && x.Role == UserRole.Teacher);

            if (entity == null)
            {
                throw new Exception("Not found");
            }

            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TeacherViewModel>> GetAllAsync()
        {
            return await _context.Users
                .Where(x => x.Role == UserRole.Teacher)
                .Select(x => new TeacherViewModel()
                {
                    Id = x.Id,
                    Username = x.Username,
                    Fullname = x.Fullname,
                })
                .ToListAsync();
        }

        public async Task<TeacherViewModel> GetByIdAsync(int id)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(u => u.Id == id && u.Role == UserRole.Teacher);

            return new TeacherViewModel()
            {
                Id = entity.Id,
                Username = entity.Username,
                Fullname = entity.Fullname

            };
        }

        public async Task UpdateAsync(UpdateTeacherModel model)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == model.Id && x.Role == UserRole.Teacher);

            if (entity == null)
            {
                throw new Exception("Not found");
            }

            entity.Username = model.Username ?? entity.Username;
            entity.Fullname = model.Fullname ?? entity.Fullname;
            entity.PasswordHash = model.Password == null ? entity.PasswordHash : _hashProvider.GetHash(model.Password);

            _context.Users.Update(entity);
            await _context.SaveChangesAsync();

        }
    }
}
