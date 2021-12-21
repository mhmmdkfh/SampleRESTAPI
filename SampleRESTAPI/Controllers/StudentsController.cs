using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleRESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private List<Student> lstStudent = new List<Student>
        {
            new Student { ID=1,FirstName="Agus",LastName="Kurniawan",
                EnrollmentDate=DateTime.Now},
            new Student { ID=2,FirstName="Erick",LastName="Kurniawan",
                EnrollmentDate=DateTime.Now},
            new Student { ID=1,FirstName="Agus",LastName="Aja",
                EnrollmentDate=DateTime.Now}
        };

        [HttpGet]
        public List<Student> Get()
        {
            return lstStudent;
        }

        [HttpGet("{id}")]
        public Student Get(int id)
        {
            //var result = lstStudent.Where(s => s.ID == id).SingleOrDefault();
            var result = (from s in lstStudent select s).SingleOrDefault();
            if (result != null)
                return result;
            else
                return new Student { };
        }

        [HttpGet("byname")]
        public List<Student> Get(string firstname,string lastname)
        {
            var results = lstStudent.Where(s => s.FirstName.StartsWith(firstname) && 
            s.LastName.StartsWith(lastname)).ToList();
            /*var results = (from s in lstStudent where s.FirstName.ToLower()
                           .StartsWith(firstname.ToLower())
                          select s).ToList();*/
            return results;
        }
    }
}
