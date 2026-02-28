namespace MVC_PRACTICE.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string City { get; set; }
        //public DateTime Date { get; set; }
        public CompanyDetail Company { get; set; }

    }
}
