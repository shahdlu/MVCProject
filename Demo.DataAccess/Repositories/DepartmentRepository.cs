using Demo.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories
{
    // Primary constructor .Net 8 c#12
    internal class DepartmentRepository(ApplicationDbContext dbContext)
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        //CRUD Operations
        //Get All
        //Get By Id
        public Department? GetById (int id)
        {
            var department = _dbContext.Departments.Find(id) ;
            return department;
        }
        //Update
        //Delete
        //Insert
    }
}
