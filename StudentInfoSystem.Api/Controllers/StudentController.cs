using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentInfoSystem.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentInfoSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        DataArrange data = new DataArrange();
        public static List<Student> _students = new();

        //GET METHOD
        [HttpGet("get")]
        public IActionResult Get()
        {
            if (_students.Count == 0)
            {
                return BadRequest("No data to display");
            }

            return Ok(_students);
        }

        //POST METHOD
        [HttpPost("register")]
        public  IActionResult Register([FromForm]Student model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //early return
            }

            //Check if the same number exist in the list
            var student = _students.FirstOrDefault(s => s.Number == model.Number);

            //if the student exist with the same number do not override
            if (student != null)
            {
                return BadRequest("A student with this number is on the list. Please change your number."); //early return
            }

            //The incoming data is being arranged
            model.Name = data.FirstCharToUpper(model.Name);
            model.LastName = data.FirstCharToUpper(model.LastName);
            model.Class = data.FirstCharToUpper(model.Class);

            _students.Add(model);

            return Ok("Student added successfully.");
        }


        //PUT METHOD
        [HttpPut("update")]
        public IActionResult Update([FromForm] Student model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //early return
            }

            var student = _students.FirstOrDefault(s => s.Number == model.Number);

            if (student == null)
            {
                return BadRequest("Student not found.");//early return
            }

            student.Name = data.FirstCharToUpper(model.Name);
            student.LastName = data.FirstCharToUpper(model.LastName);
            student.Class = data.FirstCharToUpper(model.Class);
            student.Number = model.Number;

            return Ok("Student updated successfully.");

        }

        //DELETE METHOD
        [HttpDelete("delete/{number}")]
        public IActionResult Delete(int number)
        {

            var student = _students.FirstOrDefault(s => s.Number == number);

            if (student == null)
            {
                return BadRequest("Student not found.");//early return
            }

            _students.Remove(student);

            return Ok("Student deleted successfully.");

        }



    }
}

