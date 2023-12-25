using LC.Service.Dto_s;
using LC.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenterAPI.Controllers.Course
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService service;
        public CourseController(ICourseService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(CourseDto dto)
            => Ok(await service.CreateAsync(dto));

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
            => Ok(service.GetAll(p => p.Id != 0));


        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, CourseDto dto)
            => Ok(service.Update(id, dto));




        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await service.GetAsync(u => u.Id == id));


        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await service.DeleteAsync(p => p.Id == id));
    }
}
