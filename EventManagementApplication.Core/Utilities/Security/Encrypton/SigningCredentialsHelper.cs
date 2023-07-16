using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Core.Utilities.Security.Encrypton
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //anahtar ve algoritmayı veriyoruz

            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
