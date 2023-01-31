using ITAcademyEdu.Application.Abstractions;
using ITAcademyEdu.Application.Models;
using ITAcademyEdu.Application.Services;
using ITAcademyEdu.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITAcademyEdu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminActions")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentModel model)
        {
           await _studentService.CreateAsync(model);

            return Ok();

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllAsync();

            return Ok(students);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentModel model)
        {
            await _studentService.UpdateAsync(model);

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.DeleteAsync(id);

            return Ok();
        }


    }
}
