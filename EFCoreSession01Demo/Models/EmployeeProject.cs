using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreSession02Demo.Models
{
    internal class EmployeeProject
    {
        public int EmpId { get; set; }
        public Employee Employee { get; set; } = null!;
        public int ProId { get; set; }
        public Project Project { get; set; } = null!;
    }
}
