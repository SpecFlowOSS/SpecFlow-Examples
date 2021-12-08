using DemoWebShop.Specs.Enums;
using DemoWebShop.Specs.Models;

namespace DemoWebShop.Specs.Pages.Register;

public interface IRegisterPage
{
    void Register(RegistrationModel registrationModel);
    void GoTo();
    void SubmitRegistration();
    bool RegistrationHasFailed();
}
