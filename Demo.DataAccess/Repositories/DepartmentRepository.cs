using Demo.DataAccess.Data.DbContexts;
using Demo.DataAccess.Models.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories
{
    // Primary constructor .Net 8 c#12
    public class DepartmentRepository(ApplicationDbContext dbContext) : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        //CRUD Operations
        //Get All
        public IEnumerable<Department> GetAll(bool withTracking = false)
        {
            if (withTracking)
                return _dbContext.Departments.ToList();
            else
                return _dbContext.Departments.AsNoTracking().ToList();
        }
        //Get By Id
        public Department? GetById(int id)
        {
            return _dbContext.Departments.Find(id);
        }
        //Update
        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);//update locally
            return _dbContext.SaveChanges();
        }
        //Delete
        public int Remove(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }
        //Insert
        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }
    }
}
