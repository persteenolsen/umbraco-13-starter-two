using System.ComponentModel.DataAnnotations;

//using Umbraco.Cms.Core.Models;
//using Umbraco.Cms.Core.Models.PublishedContent;

namespace MvcUmbraco.Models
{
    public class Employee
    {

        // public class Employee : ContentModel
        // {
        // public Employee(IPublishedContent content) : base(content)
        //{
        //}

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Employee Name")]
        [StringLength(15, MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(15, MinimumLength = 5)]
        public string Designation { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        public DateTime? RecordCreatedOn { get; set; }

      //  public IEnumerable<Employee> Employees { get; set; }
    }
}