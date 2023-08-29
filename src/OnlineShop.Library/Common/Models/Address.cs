using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Library.Common.Models
{
    [Table("Addresses")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string Country { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string City { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(32)")]
        public string PostalCode { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string AddressLine1 { get; set; } = null!;

        [Column(TypeName = "nvarchar(256)")]
        public string? AddressLine2 { get; set; }
    }
}
