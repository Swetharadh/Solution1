using CRUDAPI.Data;
using CRUDAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
namespace CRUDAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly Context _context;
        public StudentController(Context context)
        {
            _context = context;
        }
        //Get all the students
        [HttpGet]
        public List<Student> Get()
        {
            return _context.student.ToList();
        }
        [HttpGet("{Id}")]
        public Student GetStudent(int id)
        {
            var per = _context.student.Where(i => i.Id == id).FirstOrDefault();
            return per;
        }
        [HttpPost]
        public ActionResult InsertStudent([FromBody] Student student)
        {
            _context.student.Add(student);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.student.FindAsync(id);
            if (student == null)
            {
                return NoContent();
            }
            _context.student.Remove(student);
            await _context.SaveChangesAsync();
            return NotFound();
        }
        [HttpPut]
        public ActionResult UpdateStudent([FromBody] Student s)
        {
            var per = _context.student.Where(i => i.Id == s.Id).FirstOrDefault();
            per.ProductName = s.ProductName;
            per.Price = s.Price;
            per.Quantity = s.Quantity;
            _context.SaveChanges();
            return NoContent();
        }
    }
}


