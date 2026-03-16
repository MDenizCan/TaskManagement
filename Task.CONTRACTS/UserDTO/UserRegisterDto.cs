using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.MODELS.UserDTO;

public class UserRegisterDto
{
    [Required]
    [Display(Name = "Name")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name must contain only letters.")]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Surname")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name must contain only letters.")]
    public string Surname { get; set; }

    [Required]
    [Display(Name = "Email")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; }

    [Required]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Password doesn't match.")]
    public string ConfirmPassword { get; set; }
}
