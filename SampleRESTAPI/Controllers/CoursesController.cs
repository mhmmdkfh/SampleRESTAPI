using Microsoft.AspNetCore.Mvc;
using SampleRESTAPI.Data;
using SampleRESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private ICourse _course;
        public CoursesController(ICourse course)
        {
            _course = course;
        }

        // GET: api/<CoursesController>
       
        [HttpGet]
        public async Task<IEnumerable<Course>> Get()
        {
            var results = await _course.GetAll();
            return results;
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public async Task<Course> Get(int id)
        {
            var result = await _course.GetById(id.ToString());
            return result;
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Course course)
        {
            try
            {
                var result = await _course.Insert(course);
                return Ok(result);  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Course course)
        {
            try
            {
                var result = await _course.Update(id.ToString(), course);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _course.Delete(id.ToString());
                return Ok($"delete data id {id} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("bytitle")]
        public async Task<IEnumerable<Course>> GetByTitle(string title)
        {
            var results = await _course.GetByTitle(title);
            return results;
        }
    }
}
