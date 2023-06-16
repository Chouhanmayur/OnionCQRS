using System.ComponentModel.DataAnnotations;

namespace Employee.Management.BlazorUI.Models
{
    public  class Employee1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
    }
}
