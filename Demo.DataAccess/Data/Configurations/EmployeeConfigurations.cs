using Demo.DataAccess.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Configurations
{
    internal class EmployeeConfigurations : BaseEntityConfigurations<Employee>, IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).HasColumnType("varchar(50)");
            builder.Property(e => e.Address).HasColumnType("varchar(150)");
            builder.Property(e => e.Salary).HasColumnType("decimal(10;2)");
            builder.Property(e => e.Gender)
                   .HasConversion((empGender) => empGender.ToString(), 
                   (_gender) => (Gender)Enum.Parse(typeof(Gender), _gender));
            builder.Property(e => e.EmployeeType)
                   .HasConversion((empType) => empType.ToString(),
                   (_Type) => (EmployeeType)Enum.Parse(typeof(EmployeeType), _Type));
            base.Configure(builder);
        }
    }
}
