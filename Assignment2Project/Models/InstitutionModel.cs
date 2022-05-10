using System.ComponentModel.DataAnnotations;

namespace Assignment2Project.Models
{
    public class InstitutionModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        [MaxLength(150)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Telephone Number is Required")]
        [MaxLength(11)]
        public string TelephoneNum { get; set; }
    }
}
