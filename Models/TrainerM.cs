using System.ComponentModel.DataAnnotations;

namespace Poke.Models
{
    public class TrainerM
    {
        [Key]
        [Display(Name = "ID:")]
        public Guid IdT { get; set; }

        [Required(ErrorMessage = "Insert your name!")]
        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Display(Name = "Age:")]       
        public int Age { get; set; }

        [Display(Name = "Gender: M/F")]
        [StringLength(2)]
        public string Gender { get; set; }

        [Display(Name = "Hometown:")]
        public string Hometown { get; set; }

        [Display(Name = "Region:")]
        public string Region { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Dear trainer,\n please insert your password to keep your pokedex safe.")]
        [DataType(DataType.Password)]
        [StringLength(9)]
        public string Password { get; set; }

        [Display(Name = "Profile Picture")]
        public byte[]? Picture { get; set; }

    }
}
