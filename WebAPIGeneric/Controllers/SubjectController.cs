using Domain_Layer.Data;
using Domain_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer.IRepository;
using ServiceLayer.ICustomServices;

namespace WebAPIGeneric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ICustomService<SubjectGPA> _subjRepository;
        public SubjectController(ICustomService<SubjectGPA> subjRepository)
        {
            _subjRepository = subjRepository;
        }

        [HttpGet(nameof(GetSubjectById))]
        public ActionResult GetSubjectById(int id)
        {
            var obj= _subjRepository.Get(id);
            if (obj !=null)
            {                
                return Ok(obj);    
            }
            else
            {
                return BadRequest();  
            }
        }
        [HttpGet(nameof(GetAllSubject))]
        public IActionResult GetAllSubject()
        {
            var obj = _subjRepository.GetAll();
            if (obj !=null)
            {
                return Ok(obj);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost(nameof(AddSubject))]
        public IActionResult AddSubject(SubjectGPA subjectGPA)
        {
            if (subjectGPA !=null)
            {
                _subjRepository.Insert(subjectGPA);
                return Ok("Successful");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
        [HttpPost(nameof(UpdateSubject))]
        public IActionResult UpdateSubject(SubjectGPA subjectGPA)
        {
            if (subjectGPA !=null)
            {
                _subjRepository.Update(subjectGPA);
                return Ok("Updated successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
        [HttpDelete(nameof(DeleteSubject))]
        public IActionResult DeleteSubject(SubjectGPA subjectGPA)
        {
            if (subjectGPA !=null)
            {
                _subjRepository.Delete(subjectGPA);
                return Ok("Successfully deleted");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
