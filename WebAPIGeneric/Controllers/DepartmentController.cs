using Domain_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ICustomServices;

namespace WebAPIGeneric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ICustomService<Department> _departmentRepository;

        public DepartmentController(ICustomService<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        [HttpGet(nameof(GetDepartmentById))]
        public IActionResult GetDepartmentById(int id)
        {
            var result = _departmentRepository.Get(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet(nameof(GetAllDepartment))]
        public IActionResult GetAllDepartment()
        {
            var result = _departmentRepository.GetAll();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
        [HttpPost(nameof(AddDepartment))]
        public IActionResult AddDepartment(Department department)
        {
            if (department != null)
            {
                _departmentRepository.Insert(department);
                return Ok("Successfully result added");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
        [HttpPost(nameof(UpdateDepartment))]
        public IActionResult UpdateDepartment(Department department)
        {
            if (department != null)
            {
                _departmentRepository.Update(department);
                return Ok("Result successfully updated");
            }
            return BadRequest("Something went wrong");
        }
        [HttpDelete(nameof(DeleteDepartment))]
        public IActionResult DeleteDepartment(Department department)
        {
            if (department != null)
            {
                _departmentRepository.Delete(department);
                return Ok("Result deleted successfully");
            }
            return BadRequest("Something went wrong");
        }
        [HttpDelete(nameof(RemoveDepartment))]
        public IActionResult RemoveDepartment(Department department)
        {
            if (department != null)
            {
                _departmentRepository.Remove(department);
                return Ok("Successful");
            }
            return BadRequest("Something went wrong");
        }
    }
}
