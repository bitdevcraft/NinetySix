namespace NinetySix.Server.Models.Entities.Auth;

public class RegisterUser
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }

    public string? Schema { get; set; }
    
}