using Demo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BussinessLogic.DataTransferObjects.DepartmentDtos
{
    public class DepartmentDetailsDto
    {
        //constructor base mapping
        //public DepartmentDetailsDto(Department department)
        //{
        //    Id = department.Id;
        //    Name = department.Name;
        //    CreatedOn = DateOnly.FromDateTime(department.CreatedOn);
        //}
        public int Id { get; set; } //PK
        public int CreatedBy { get; set; } //User Id
        public DateOnly CreatedOn { get; set; }
        public int LastModifedBy { get; set; } //User Id
        public DateOnly LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; } // soft delete
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
