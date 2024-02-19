using Aplication.Students;
using Domain.Students;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }
        

        [HttpGet]
        public IList<Student> List()
        {
            
            var result = _service.List();

            if (result.IsSuccess)
            {
                return result.Value;
            }

            return (IList<Student>)StatusCode
                (StatusCodes.Status500InternalServerError, null);


        }


        [HttpGet]
        [Route("{bacth}")]
        public IActionResult Get([FromRoute] string bacth)
        {
            if (string.IsNullOrEmpty(bacth))
            {
                return BadRequest();
            }

            var result = _service.Get(bacth);

            if(result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return NotFound();
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateStudent student)
        {
            var result = _service.Create(student);
            if (result.IsSuccess)
            {
                return Created();
            }

            return StatusCode(StatusCodes.Status500InternalServerError, null);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateStudent student)
        {
            var result = _service.Update(student);
            if (result.IsSuccess)
            {
                return Accepted();
            }

            if (result.Error == StudentErrors.NotFound())
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status500InternalServerError, null);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id) 
        {
            var result = _service.Delete(id);
            if (result.IsSuccess)
            {
                return Accepted();
            }

            if (result.Error == StudentErrors.NotFound())
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status500InternalServerError, null);
        }
    }
}
