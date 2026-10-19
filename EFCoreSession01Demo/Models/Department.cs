using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreSession02Demo.Models
{
    internal class Department
    {
        public int DeptId { get; set; }

        public string DeptName { get; set; }

        public DateTime DateOfCreation { get; set; }

        public int Serial { get; set; }

        // Foreign Key 
        // By Convention : [ManagerId , ManagerEmpId , EmployeeId , EmployeeEmpId]

        // By Data Annotation 
        //[ForeignKey("Manager")]
        //[ForeignKey(nameof(Manager))]

        public int? DeptManagerId { get; set; }

        // Navigation Property [One]
        // Ef Core -> Department Has One Employee To Manage It [Mandatory] 
        [InverseProperty(nameof(Employee.ManagedDepartment))]
        public Employee Manager { get; set; } = null!;

        // Navigation Property [Many]
        // Department Contains Many Employees
        [InverseProperty(nameof(Employee.EmployeeDepartment))]
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

    }
}
