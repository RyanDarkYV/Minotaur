using Minotaur.CommonParts.Authentication;

namespace Minotaur.Api.Framework
{
    public class AdminAuth : JwtAuthAttribute
    {
        public AdminAuth() : base("admin")
        {
        }
    }
}