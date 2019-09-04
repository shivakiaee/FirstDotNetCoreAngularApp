using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class City : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public Province Province { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
    }
}
