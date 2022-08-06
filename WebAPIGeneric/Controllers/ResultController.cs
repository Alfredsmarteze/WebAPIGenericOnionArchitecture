using Domain_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ICustomServices;

namespace WebAPIGeneric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly ICustomService<Result> _resultRepository;
        public ResultController(ICustomService<Result> resultRepository)
        {
            _resultRepository = resultRepository;
        }
        [HttpGet(nameof(GetReultById))]
        public IActionResult GetReultById(int id)
        { 
         var result=_resultRepository.Get(id);
            if (result !=null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Something went wrong");    
            }
        }
        [HttpGet(nameof(GetAllResult))]
        public IActionResult GetAllResult()
        { 
            var result = _resultRepository.GetAll();
            if (result !=null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
        [HttpPost(nameof(AddResult))]
        public IActionResult AddResult(Result result)
        {
            if (result !=null)
            {
                _resultRepository.Insert(result);
                return Ok("Result added successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
        [HttpPost(nameof(UpdateResult))]
        public IActionResult UpdateResult(Result result)
        {
            if (result !=null)
            {
                _resultRepository.Update(result);
                return Ok("Result successfully updated");
            }
            return BadRequest("Something went wrong");
        }
        [HttpDelete(nameof(DeleteResult))]
        public IActionResult DeleteResult(Result result)
        {
            if (result !=null)
            {
                _resultRepository.Delete(result);
                return Ok("Result deleted successfully");
            }
            return BadRequest("Something went wrong");
        }
        [HttpDelete(nameof(RemoveResult))]
        public IActionResult RemoveResult(Result result)
        {
            if (result !=null)
            {
                _resultRepository.Remove(result);
                return Ok("Successful");
            }
            return BadRequest("Something went wrong");
        }
    }
}
