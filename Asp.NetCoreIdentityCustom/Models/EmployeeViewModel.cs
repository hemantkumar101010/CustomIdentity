namespace Asp.NetCoreIdentityCustom.Models
{
    public class EmployeeViewModel
    {
        

       // int num = rnd.Next(100,10000);
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Salary { get; set; }

        public EmployeeViewModel()
        {
            Random number = new Random();
            this.Id = number.Next();

        }
    }

    public class Employees : List<EmployeeViewModel>
    {
        public Employees()
        {
            
            Add(new EmployeeViewModel {  Name = "Hemant", Salary = 12000 });
            Add(new EmployeeViewModel {  Name = "Hemant", Salary = 12000 });
            Add(new EmployeeViewModel {  Name = "Hemant", Salary = 12000 });

        }
    }
}
