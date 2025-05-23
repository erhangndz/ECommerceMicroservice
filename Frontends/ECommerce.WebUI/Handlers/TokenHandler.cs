using System.Net;
using System.Net.Http.Headers;
using ECommerce.WebUI.Services.IdentityServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace ECommerce.WebUI.Handlers
{
    public class TokenHandler(IHttpContextAccessor _contextAccessor,IIdentityService _identityService): DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessToken = await _contextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var result = await _identityService.GetRefreshToken();
                if (result)
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    await base.SendAsync(request, cancellationToken);
                }
            }


            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new Exception(response.StatusCode.ToString());
            }

            return response;
        }
    }
}
