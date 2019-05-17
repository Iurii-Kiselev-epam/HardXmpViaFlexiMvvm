using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace VacationsTracker.Core.Communication
{
    /// <summary>
    /// Provides HttpClient extention method for XMP VTS Authentication
    /// </summary>
    public static class XmpProxyAuthenticator
    {
        private const string InvalidCredentialsErrorKey = "invalid_grant";
        private const string InvalidCredentialsErrorDesc = "invalid_username_or_password";

        /// <summary>
        /// Authenticates the user and adds Bearer token to the http client
        /// </summary>
        public static async Task AuthenticateAsync(this HttpClient httpClient,
            string login, string passw, string vtsIdentityUrl)
        {
            if (httpClient == null)
            {
                throw new ArgumentNullException(nameof(httpClient));
            }
            if (string.IsNullOrWhiteSpace(vtsIdentityUrl))
            {
                throw new ArgumentNullException(nameof(vtsIdentityUrl));
            }

            var identityServer = await httpClient.GetDiscoveryDocumentAsync(vtsIdentityUrl); //await DiscoveryClient.GetAsync(AppSettings.Current.VtsIdentityServiceUrl);
            if (identityServer.IsError)
            {
                var err = $"{identityServer.ErrorType} > {identityServer.Error}";
                throw new CommunicationException(
                    message: $"Cannot connect to Identity Server ({vtsIdentityUrl}). {err}",
                    statusCode: (int)identityServer.StatusCode,
                    response: identityServer.Raw,
                    headers: null,
                    innerException: identityServer.Exception);
            }

            var passwordTokenRequest = new PasswordTokenRequest
            {
                Address = identityServer.TokenEndpoint,
                ClientId = XmpProxyConstants.OAuth.ClientId,
                ClientSecret = XmpProxyConstants.OAuth.ClientSecret,
                UserName = login,
                Password = passw,
                Scope = XmpProxyConstants.OAuth.ResourceId
            };
            var userTokenResponse = await httpClient.RequestPasswordTokenAsync(passwordTokenRequest);
            if (userTokenResponse.IsError || userTokenResponse.AccessToken == null)
            {
                if (userTokenResponse.ErrorType == ResponseErrorType.Protocol && 
                    userTokenResponse.Error == InvalidCredentialsErrorKey &&
                    userTokenResponse.ErrorDescription == InvalidCredentialsErrorDesc)
                {
                    throw new AuthenticationException(
                        message: "Invalid Credentials",
                        innerException: userTokenResponse.Exception);
                }

                var err = $"{userTokenResponse.ErrorType} > {userTokenResponse.Error} > {userTokenResponse.ErrorDescription}";
                throw new CommunicationException(
                    $"Cannot Get Access Token ({identityServer.TokenEndpoint}). {err}",
                    (int)identityServer.StatusCode,
                    identityServer.Raw,
                    null,
                    identityServer.Exception);
            }

            httpClient.SetBearerToken(userTokenResponse.AccessToken);
        }
    }
}
