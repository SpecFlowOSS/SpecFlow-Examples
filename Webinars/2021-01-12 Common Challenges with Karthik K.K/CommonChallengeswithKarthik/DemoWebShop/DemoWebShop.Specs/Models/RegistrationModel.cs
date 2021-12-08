using DemoWebShop.Specs.Enums;

namespace DemoWebShop.Specs.Models;

public class RegistrationModel
{
    public RegistrationModel(Gender gender, string firstName, string lastName, string email, string password, string confirmPassword)
    {
        this.Gender = gender;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Password = password;
        this.ConfirmPassword = confirmPassword;
    }

    public Gender Gender { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string Email { get; set; }

    public string Password { get; }

    public string ConfirmPassword { get; }
}