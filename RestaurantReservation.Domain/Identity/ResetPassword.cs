
using System.ComponentModel.DataAnnotations;
namespace RestaurantReservation.Domain.Identity;
public class ResetPassword
{
    [Compare("Password", ErrorMessage = "Password and Confirmation Passowrd dont match.")]
    public string ConfirmPassword { get; set; }
    public string Token { get; set; }
    [Required]
    public string Password { get; set; }
    public string Email { get; set; }
}
