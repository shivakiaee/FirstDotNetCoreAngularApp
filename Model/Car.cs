using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
   public class Car:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(9)")]
        public string LicensePlate { get; set; }
        public Driver Driver { get; set; }
    }
}
