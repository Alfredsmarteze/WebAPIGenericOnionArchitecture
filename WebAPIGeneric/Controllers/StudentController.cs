using Domain_Layer.Data;
using Domain_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ICustomServices;

namespace WebAPIGeneric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ICustomService<Student> _customService;
        private readonly ApplicationDbContext _applicationDbContext;

        public StudentController(ICustomService<Student> customService, ApplicationDbContext applicationDbContext)
        {
            _customService = customService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet(nameof(GetStudentById))]
        public IActionResult GetStudentById(int id)
        {
            var obj = _customService.Get(id);
            if (obj != null)
            {
                return Ok(obj);
            }
            else {
                return BadRequest();
            }
        }
        [HttpGet(nameof(GetAllStudent))]
        public IActionResult GetAllStudent()
        { 
            var obj=_customService.GetAll();
            if (obj !=null)
            {
                return Ok(obj);
            }
            else
            {
                return BadRequest();  
            }
        }
        [HttpPost(nameof(AddStudent))]
        public IActionResult AddStudent(Student student)
        {
            if (student !=null)
            {
                _customService.Insert(student);
                return Ok("Successfully added student"); 
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost(nameof(UpdateStudent))]
        public IActionResult UpdateStudent(Student student)
        {
            if (student !=null)
            {
                _customService.Update(student);
                return Ok("Successfully updated student");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete(nameof(DeleteStudent))]
        public IActionResult DeleteStudent(Student student)
        {
            if (student != null)
            { 
            _customService.Delete(student); 
                return Ok("Deleted successfully");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
