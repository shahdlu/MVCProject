using Demo.DataAccess.Data.DbContexts;
using Demo.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDepartmentRepository _DepartmentRepository;
        private IEmployeeRepository _EmployeeRepository;
        private readonly ApplicationDbContext _dbContext;
        public UnitOfWork(IDepartmentRepository departmentRepository, 
                          IEmployeeRepository employeeRepository,
                          ApplicationDbContext dbContext)
        {
            _DepartmentRepository = departmentRepository;
            _EmployeeRepository = employeeRepository;
        }
        public IEmployeeRepository EmployeeRepository => _EmployeeRepository;

        public IDepartmentRepository DepartmentRepository => _DepartmentRepository;

        public int SaveChange()
        {
            return _dbContext.SaveChanges();
        }
    }
}
