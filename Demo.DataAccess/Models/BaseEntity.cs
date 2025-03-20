﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Models
{
    public class BaseEntity
    {
        public int Id { get; set; } //PK
        public int CreatedBy { get; set; } //User Id
        public DateTime CreatedOn { get; set; }
        public int LastModifedBy { get; set; } //User Id
        public DateTime LastModifiedOn  { get; set; }
        public bool IsDeleted { get; set; } // soft delete
    }
}
