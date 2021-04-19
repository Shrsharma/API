using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Threading.Tasks;

namespace Api_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IBaseRepo<StudentModel> _context;

        public StudentController(IBaseRepo<StudentModel> context)
        {
            this._context = context;
        }


        // GET: Student
        [HttpGet("Get")]
        public async Task<IActionResult> Get()   //index
        {
            return Ok(await _context.GetAll());
        }

        // GET: Student/Details/5
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var studentModel = await _context.Get(id);
            if (studentModel == null)
            {
                return NotFound();
            }

            return Ok(studentModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post(StudentModel studentModel)   //create
        {
            if (ModelState.IsValid)
            {
                await _context.Insert(studentModel);
                return Ok();
            }
            return BadRequest(studentModel);
        }

       
        [HttpPut]
        public async Task<IActionResult> Put(StudentModel studentModel)    //edit
        {
            if (string.IsNullOrEmpty(studentModel.ID ))
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _context.Update(studentModel);
                return Ok(studentModel);
            }
            return BadRequest() ;
        }

        // GET: Student/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentModel = await _context.Get(id);
            if (studentModel == null)
            {
                return NotFound();
            }
            await _context.Delete(id);
            return Ok();
        }

        //// POST: Student/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    await _context.Delete(id);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
