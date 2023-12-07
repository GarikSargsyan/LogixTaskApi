using LogixTaskApi.Models;
using LogixTaskApi.Models.DataBase;
using LogixTaskApi.Models.RequestModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LogixTaskApi.Repositories
{
    public class SignInRepository : ISignInRepository
    {
        private readonly ApplicationDBContext dBContext;
        private readonly IConfiguration _configuration;
        public SignInRepository(ApplicationDBContext dBContext, IConfiguration configuration)
        {
            this.dBContext = dBContext;
            _configuration = configuration;
        }

        public async Task<string> Registration(RegistrationRequestModel registrationInModel)
        {
            var userExist = await dBContext.UserProfileDBModels.FirstOrDefaultAsync(x =>
            x.Email == registrationInModel.Email);

            if (userExist != null)
            {
                return null;
            }

            var address = InfoCorrectHelper.AddressCorrect(registrationInModel.Address);
            var newUser = new UserProfileDBModel
            {
                Id = Guid.NewGuid(),
                FirstName = registrationInModel.FirstName,
                LastName = registrationInModel.LastName,
                Email = registrationInModel.Email,
                Address = address,
                DateOfBirth = registrationInModel.DateOfBirth.ToString("MM/dd/yyyy"),
                Password = registrationInModel.Password,
                PhoneNumber = registrationInModel.PhoneNumber,
                FullName = $"{registrationInModel.FirstName} {registrationInModel.LastName}",
                Role = "user",

            };
            await dBContext.UserProfileDBModels.AddAsync(newUser);
            await dBContext.SaveChangesAsync();

            var token = CreateJwtToken(newUser);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> SignIn(SignInRequestModel signInModel)
        {
            var user = await dBContext.UserProfileDBModels.SingleOrDefaultAsync(x => x.Email == signInModel.Email && x.Password == signInModel.Password && x.IsActive);

            if (user == null)
            {
                return null;
            }

            var token = CreateJwtToken(user);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public JwtSecurityToken CreateJwtToken(UserProfileDBModel user)
        {
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.Id.ToString()),
                        new Claim("Email", user.Email),
                        new Claim(ClaimTypes.Role, user.Role),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: signIn);

            return token;
        }
    }
}
