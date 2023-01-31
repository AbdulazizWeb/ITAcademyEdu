using ITAcademyEdu.Application.Abstractions;
using ITAcademyEdu.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITAcademyEdu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminActions")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateTeacherModel model)
        {
           await _teacherService.CreateAsync(model);

            return Ok();

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(UpdateTeacherModel model)
        {
            var teachers = await _teacherService.GetAllAsync();

            return Ok(teachers);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTeacherModel model)
        {
            await _teacherService.UpdateAsync(model);

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _teacherService.DeleteAsync(id);

            return Ok();
        }


    }
}
