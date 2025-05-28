namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;

    public string? ResetToken { get; set; }
    public DateTime? ResetTokenExpiry { get; set; }

    public virtual List<Product> Products { get; set; }
}