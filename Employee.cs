using System.ComponentModel.DataAnnotations;

namespace Crud_using_entity_framework.Models
{
    public class Employee
    {
        [Key]
        [Required]
       
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Phone { get; set; }
    }
}
