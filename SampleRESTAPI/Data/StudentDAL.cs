﻿using Microsoft.EntityFrameworkCore;
using SampleRESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleRESTAPI.Data
{
    public class StudentDAL : IStudent
    {
        private ApplicationDbContext _db;
        public StudentDAL(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            //var results = await _db.Students.OrderBy(s => s.FirstName).ToListAsync();
            var results = await (from s in _db.Students
                                 orderby s.FirstName ascending
                                select s).ToListAsync();
            return results;
        }

        public async Task<Student> GetById(string id)
        {
            var result = await _db.Students.Where(s => s.ID == Convert.ToInt32(id)).SingleOrDefaultAsync<Student>();
            if (result != null)
                return result;
            else
                throw new Exception("Data tidak ditemukan !");
        }

        public async Task<Student> Insert(Student obj)
        {
            try
            {
                _db.Students.Add(obj);
                await _db.SaveChangesAsync();
                return obj;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Error: {dbEx.Message}");
            }
        }

        public async Task<Student> Update(string id, Student obj)
        {
            try
            {
                var result = await GetById(id);
                result.FirstName = obj.FirstName;
                result.LastName = obj.LastName;
                result.EnrollmentDate=obj.EnrollmentDate;
                await _db.SaveChangesAsync();
                obj.ID = Convert.ToInt32(id);
                return obj;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Error: {dbEx.Message}");
            }
        }
    }
}
