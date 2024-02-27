using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace eshop.API.Security
{
    public class BasicHandler : AuthenticationHandler<BasicOption>
    {
        public BasicHandler(IOptionsMonitor<BasicOption> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //1. Gelen isteğin header'i içerisinde Authorization var mı?
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.NoResult());

            }

            //2. Auth değeri Parse edilebiliyor mu?
            if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue parsedValue))
            {
                return Task.FromResult(AuthenticateResult.NoResult());

            }

            //3. Scheme Basic  mi?

            if (!parsedValue.Scheme.Equals("Basic", StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(AuthenticateResult.NoResult());

            }

            var bytes = Convert.FromBase64String(parsedValue.Parameter);
            var headerValue = Encoding.UTF8.GetString(bytes);

            var userName = headerValue.Split(':')[0];
            var password = headerValue.Split(":")[1];

            if (userName == "admin" && password == "123")
            {
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, "Client"),

                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, Scheme.Name);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                AuthenticationTicket authenticationTicket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);
                return Task.FromResult(AuthenticateResult.Success(authenticationTicket));

            }
            return Task.FromResult(AuthenticateResult.Fail("Hatalı kullanıcı adı veya şife"));
        }
    }
}
