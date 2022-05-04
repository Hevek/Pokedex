using System.ComponentModel.DataAnnotations;

namespace Poke.Models
{
    public class PokeM
    {
            [Key]
            [Display(Name = "ID:")]
            public Guid IdP { get; set; }

            [Display(Name = "Pokémon:")]
            [Required]
            public string PokeN { get; set; }

            [Display(Name = "Type:")]
            public string TypeP { get; set; }

            [Display(Name = "Height:")]
            public double Height { get; set; }

            [Display(Name = "Weight:")]
            public double Weight { get; set; }

            [Display(Name = "Ability 1:")]
            public string Ability { get; set; }

            [Display(Name = "Pokemon Picture:")]
            public byte[]? PictureP { get; set; }

            [Display(Name = "Health Points:")]
            public double HP { get; set; }

            [Display(Name = "Attack:")]
            public double Atk { get; set; }

            [Display(Name = "Defence:")]
            public double Def { get; set; }

            [Display(Name = "Sp.Atk:")]
            public double SpAtk { get; set; }

            [Display(Name = "Sp.Def:")]
            public double SpDef { get; set; }

            [Display(Name = "Speed:")]
            public double Speed { get; set; }

            [Display(Name = "Gender: M/F")]
            [MaxLength(2)]
            public string GenderP { get; set; }

    }
}
