namespace CallBoardNix.Models
{
    public record class LoginModel(string Email, string Password);
    public record class RegisterModel(string Name, string Surname, string status, string PhoneNumber, string Email, string Password);
}
