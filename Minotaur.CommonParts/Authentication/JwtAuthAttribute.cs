using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Minotaur.CommonParts.Authentication
{
    public class JwtAuthAttribute : AuthAttribute
    {
        public JwtAuthAttribute(string policy = "") : base(JwtBearerDefaults.AuthenticationScheme, policy)
        {
        }
    }
}