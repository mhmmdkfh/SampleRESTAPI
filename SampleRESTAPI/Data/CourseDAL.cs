using Microsoft.EntityFrameworkCore;
using SampleRESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleRESTAPI.Data
{
    public class CourseDAL : ICourse
    {
        private ApplicationDbContext _db;
        public CourseDAL(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            //var results = await _db.Courses.OrderBy(c => c.Title).AsNoTracking().ToListAsync();
            var results = await (from c in _db.Courses orderby c.Title ascending
                                 select c).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<Course> GetById(string id)
        {
            var result = await (from c in _db.Courses
                                where c.CourseID == Convert.ToInt32(id)
                                select c).AsNoTracking().SingleOrDefaultAsync();
            if (result == null) throw new Exception($"data id {id} tidak ditemukan");
            
            return result;
        }

        public async Task<IEnumerable<Course>> GetByTitle(string title)
        {
            var results = await (from c in _db.Courses 
                                 where c.Title.ToLower().Contains(title.ToLower())
                                 orderby c.Title ascending
                                 select c).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<Course> Insert(Course obj)
        {
            try
            {
                _db.Courses.Add(obj);
                await _db.SaveChangesAsync();
                return obj;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

        public Task<Course> Update(string id, Course obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
