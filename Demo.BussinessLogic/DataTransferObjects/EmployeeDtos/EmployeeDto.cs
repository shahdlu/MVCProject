﻿using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BussinessLogic.DataTransferObjects.EmployeeDtos
{
    public class EmployeeDto
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public int Age { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        public string? Email { get; set; }
        public string EmpGender { get; set; }

        [Display(Name = "Employee Type")]
        public string EmpType { get; set; }
    }
}
