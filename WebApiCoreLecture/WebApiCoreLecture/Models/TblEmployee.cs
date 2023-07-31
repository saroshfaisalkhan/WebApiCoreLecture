using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiCoreLecture.Models
{
    public class TblEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Range(23, 30, ErrorMessage = "Age should be between 23 to 30")]

        public int Age { get; set; }
        public DateTime Doj { get; set; }

        public string Genedr { get; set; }
        public bool IsMarried { get; set; }
        public bool IsActive { get; set; }
        public int DesignationId { get; set; }

        [NotMapped]
        public string Designation { get; set; }
    }
}
