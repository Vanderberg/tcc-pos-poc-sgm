using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SGM.Shared.Domain.Security
{
    public class SigningConfigurations
    {
        public SecurityKey Key { get; set; }

        public SigningCredentials SigningCredentials { get; set; }

        public SigningConfigurations()
        {
            Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e"));
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}