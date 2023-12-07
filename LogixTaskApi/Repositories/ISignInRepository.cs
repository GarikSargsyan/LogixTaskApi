using LogixTaskApi.Models.RequestModels;

namespace LogixTaskApi.Repositories
{
    public interface ISignInRepository
    {
        public Task<string> SignIn(SignInRequestModel signInModel);
        public Task<string> Registration(RegistrationRequestModel registrationInModel);
    }
}
