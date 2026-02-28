using MVC_PRACTICE.Models;

namespace MVC_PRACTICE.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        static List<Employee> _employees = new List<Employee>();
        
        static EmployeeRepository()
        {
            Employee emp = new Employee();
            emp.Id = 1;
            emp.Name = "Adil Mohammed";
            emp.Salary = 25000;
            emp.City = "Vuyyuru";
            

            _employees.Add(emp);
            _employees.Add(new Employee() { Id = 2, Name = "Abid Mohammad", Salary = 20000, City = "Machilipatnam" });
            _employees.Add(new Employee() { Id = 3, Name = "Mohammad Gafoor", Salary = 30000, City = "Machilipatnam" });


        }
        public void AddEmployee(Employee emp)
        {
            _employees.Add(emp);
        }

        public void DeleteEmployee(int id)
        {
            var employee = _employees.First(emp => emp.Id == id);
            _employees.Remove(employee);
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _employees.First(e => e.Id == id);

            //Example for Partial View!!
            employee.Company = new CompanyDetail() { Id = 1, CompanyName = "Google", ContactNumber = "8125539049"};
            
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return _employees;
        }

        public void UpdateEmployee(Employee emp)
        {
            var employee = _employees.First(e => e.Id == emp.Id);

            employee.Name = emp.Name;
            employee.Salary = emp.Salary;
            employee.City = emp.City;

        }
    }
}
