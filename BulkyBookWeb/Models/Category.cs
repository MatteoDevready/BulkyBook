using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,9000000,ErrorMessage ="The Order number is out of range")]
        public int DisplayOrder { get; set; }

        //it default the date creation to when an object is created
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
