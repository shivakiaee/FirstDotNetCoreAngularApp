using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public abstract class User : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string FatherName { get; set; }
        [Required]
        [Column(TypeName = "varchar(11)")]
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(1000)")]
        public string Address { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string PostalCode { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string NationalCode { get; set; }
        [Required]
        [Column(TypeName = "varchar(24)")]
        public string Sheba { get; set; }
        [EmailAddress]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
    }
}
