using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; } 

        //it default the date creation to when an object is created
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
