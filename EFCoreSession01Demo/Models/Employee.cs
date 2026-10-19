using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCoreSession02Demo.Models
{
    internal class Employee
    {
        public int EmpId { get; set; }
        public string? EmpName { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string UserName { get; }

        // Navigation Property [One]
        // Ef Core -> Employee May Be Manage One Department [Optional]

        [InverseProperty(nameof(Department.Manager))]
        public Department? ManagedDepartment { get; set; }

        public Address EmpAddress { get; set; } = null!;

        //Navigation Property [One]
        // Each Employee Must Be Work In One Department
        [InverseProperty(nameof(Department.Employees))]
        public Department EmployeeDepartment { get; set; } = null!;

        //[ForeignKey(nameof(EmployeeDepartment))]
        public int DepartmentId { get; set; }

        [InverseProperty(nameof(EmployeeProject.Employee))]
        public EmployeeProject? EmployeeProject { get; set; }

        public int? SupervisorId { get; set; }
        public Employee? Supervisor { get; set; }
    }
}
