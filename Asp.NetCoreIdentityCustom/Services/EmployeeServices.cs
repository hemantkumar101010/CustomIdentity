using Asp.NetCoreIdentityCustom.Models;

namespace Asp.NetCoreIdentityCustom.Services
{
    public class EmployeeServices
    {
        public  Employees employee;
        public EmployeeServices(Employees employees)
        {
            this.employee = employees;
        }
        public List<EmployeeViewModel> Get()
        {
            return employee;
        }

        public List<EmployeeViewModel> Create(EmployeeViewModel employeeViewModel)
        {
            employee.Add(employeeViewModel);
            return employee;
        }
       
    }
}
