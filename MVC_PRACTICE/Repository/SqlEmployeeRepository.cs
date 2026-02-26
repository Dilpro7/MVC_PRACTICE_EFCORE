using MVC_PRACTICE.Context;
using MVC_PRACTICE.Models;

namespace MVC_PRACTICE.Repository
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public SqlEmployeeRepository(EmployeeDbContext employeeDbContext)
        {
           _employeeDbContext = employeeDbContext;
        }
        public void AddEmployee(Employee emp)
        {
            _employeeDbContext.Employees.Add(emp);

            _employeeDbContext.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _employeeDbContext.Employees.First(emp => emp.Id == id);
            _employeeDbContext.Employees.Remove(employee);

            _employeeDbContext.SaveChanges();
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _employeeDbContext.Employees.First(e => e.Id == id);
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return _employeeDbContext.Employees.ToList();
        }

        public void UpdateEmployee(Employee emp)
        {
            var employee = _employeeDbContext.Employees.First(value => value.Id == emp.Id);

            employee.Name = emp.Name;
            employee.Salary = emp.Salary;
            employee.City = emp.City;

            _employeeDbContext.Employees.Update(employee);

            _employeeDbContext.SaveChanges();

        }
    }
}
