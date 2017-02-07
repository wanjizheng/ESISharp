﻿using ESISharp.Enumerations;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ESISharp
{
    /// <summary>
    /// SSO Authentication Operations
    /// </summary>
    public partial class Sso
    {
        internal void Authorize()
        {
            if (ClientID == null) return;

            if(RefreshToken != null && GrantType == OAuthGrant.Authorization && !ReauthorizeScopes)
            {
                RefreshAccessToken(RefreshToken);
                return;
            }

            var LocalRequestedScopes = RequestedScopes;

            var SsoBuilder = new UriBuilder("https://login.eveonline.com/oauth/authorize");
            var Query = HttpUtility.ParseQueryString(SsoBuilder.Query);
            if (GrantType == OAuthGrant.Authorization && SecretKey != null)
            {
                Query["response_type"] = "code";
            }
            else
            {
                Query["response_type"] = "token";
            }
            Query["state"] = State;
            Query["redirect_uri"] = CallbackUrl;
            Query["client_id"] = ClientID;
            Query["scope"] = ScopesUrl;
            SsoBuilder.Query = Query.ToString();

            System.Diagnostics.Process.Start(SsoBuilder.ToString());

            var Server = new NamedPipeServerStream("ESISharpAuth");
            var Reader = new StreamReader(Server);
            Server.WaitForConnection();
            var AuthRouterReply = Reader.ReadLine();
            Server.WaitForPipeDrain();
            Server.Disconnect();
            Server.Close();

            var ReplyArguments = ParseReplyArguments(AuthRouterReply);

            if(GrantType == OAuthGrant.Authorization && SecretKey != null)
            {
                string AuthCode;
                ReplyArguments.TryGetValue("code", out AuthCode);
                var AccessTokenResponse = GetAccessToken(AuthCode);
                while(!string.IsNullOrEmpty(AccessTokenResponse))
                {
                    var Token = JsonConvert.DeserializeObject<AccessToken>(AccessTokenResponse);
                    AuthToken = new AuthToken(Token.access_token, Token.token_type, Token.refresh_token, Token.expires_in);
                    GrantType = OAuthGrant.Authorization;
                    if(!LocalRequestedScopes.Contains(Scope.None))
                    {
                        AuthorizedScopes = LocalRequestedScopes;
                        ClearRequestedScopes();
                    }
                    break;
                }
            }
            else
            {
                string ImplicitAccessToken;
                string ImplicitTokenType;
                string ImplicitTokenExpiresIn;

                ReplyArguments.TryGetValue("access_token", out ImplicitAccessToken);
                ReplyArguments.TryGetValue("token_type", out ImplicitTokenType);
                ReplyArguments.TryGetValue("expires_in", out ImplicitTokenExpiresIn);
                ImplicitToken = new ImplicitToken(ImplicitAccessToken, ImplicitTokenType, ImplicitTokenExpiresIn);
                GrantType = OAuthGrant.Implicit;
                if (!LocalRequestedScopes.Contains(Scope.None))
                {
                    AuthorizedScopes = LocalRequestedScopes;
                    ClearRequestedScopes();
                }
            }
        }

        private Dictionary<string, string> ParseReplyArguments(string RouterReply)
        {
            var Output = new Dictionary<string, string>();
            string ReplyHeaderChar;
            if (GrantType == OAuthGrant.Implicit) {
                ReplyHeaderChar = @"#";
            }
            else
            {
                ReplyHeaderChar = @"?";
            }
            var UrlHeader = CallbackProtocol + @":///" + ReplyHeaderChar;
            var ReplyArgs = RouterReply.Split(new string[] { UrlHeader }, StringSplitOptions.None)
                            .SelectMany(p => p.Split('&'))
                            .Where(m => m.Contains('='))
                            .Select(m => new KeyValuePair<string, string>(m.Split('=')[0], m.Split('=')[1]));
            ReplyArgs.ToList().ForEach(kvp => Output.Add(kvp.Key, kvp.Value));
            return Output;
        }

        private string GetAccessToken(string AuthCode)
        {
            var GetAccessTokenTask = SsoPost(
                "authorization_code",
                "code",
                AuthCode);
            GetAccessTokenTask.Wait();
            return GetAccessTokenTask.Result;
        }

        internal void RefreshAccessToken()
        {
            var GetAccessTokenTask = SsoPost(
                "refresh_token",
                "refresh_token",
                AuthToken.RefreshToken);
            GetAccessTokenTask.Wait();
            AccessToken Token = JsonConvert.DeserializeObject<AccessToken>(GetAccessToken(GetAccessTokenTask.Result));
            AuthToken = new AuthToken(Token.access_token, Token.token_type, Token.refresh_token, Token.expires_in);
        }

        internal void RefreshAccessToken(string RefreshToken)
        {
            var GetAccessTokenTask = SsoPost(
                "refresh_token",
                "refresh_token",
                RefreshToken);
            GetAccessTokenTask.Wait();
            AccessToken Token = JsonConvert.DeserializeObject<AccessToken>(GetAccessTokenTask.Result);
            AuthToken = new AuthToken(Token.access_token, Token.token_type, Token.refresh_token, Token.expires_in);
        }

        private async Task<string> SsoPost(string Grant, string CodeType, string Code)
        {
            string ResponseString;
            SsoClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Base64Encode(ClientID + ":" + SecretKey));
            SsoClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage Response = await SsoClient.PostAsync(new Uri("https://login.eveonline.com/oauth/token"), new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", Grant),
                    new KeyValuePair<string, string>(CodeType, Code)
                }));
            ResponseString = await Response.Content.ReadAsStringAsync();
            return ResponseString;
        }

        private string Base64Encode(string PlainText)
        {
            var PlainTextBytes = Encoding.UTF8.GetBytes(PlainText);
            return Convert.ToBase64String(PlainTextBytes);
        }

        internal bool IsTokenValid()
        {
            DateTime Expires;
            int TimeDifference;
            if (GrantType == OAuthGrant.Authorization)
            {
                Expires = AuthToken.Expires;
            }
            else
            {
                Expires = ImplicitToken.Expires;
            }
            TimeDifference = DateTime.Compare(Expires, DateTime.UtcNow);
            if (TimeDifference < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal void CreateRegistryKeys()
        {
            var Protocol = CallbackProtocol;
            var RouterCommand = @"""" + @AuthRouterFilePath + @""" ""%1""";

            var ProtocolRoot = Registry.ClassesRoot.CreateSubKey(Protocol);
            ProtocolRoot.SetValue("", "URL:Eve Online SSO Protocol");
            ProtocolRoot.SetValue("URL Protocol", "");

            var DefaultIcon = ProtocolRoot.CreateSubKey("DefaultIcon");
            DefaultIcon.SetValue("", AuthRouterFileName + ".exe,1");

            var Shell = ProtocolRoot.CreateSubKey("Shell");
            var Open = Shell.CreateSubKey("Open");
            var Command = Open.CreateSubKey("Command");
            Command.SetValue("", RouterCommand);
        }

        /// <summary>
        /// Verify information of the callback protocol.
        /// <para/>Key will be create if it doesn't exist, or overwritten if there is an error.
        /// </summary>
        public void VerifyCallbackProtocolRegistyKey()
        {
            var Protocol = CallbackProtocol;
            var RouterCommand = @"""" + @AuthRouterFilePath + @""" ""%1""";
            var ProtocolRoot = Registry.ClassesRoot.OpenSubKey(Protocol);

            if (ProtocolRoot == null)
            {
                CreateRegistryKeys();
            }
            else
            {
                try
                {
                    var DefaultIconKey = ProtocolRoot.OpenSubKey("DefaultIcon");
                    var ShellKey = ProtocolRoot.OpenSubKey("Shell");
                    var OpenKey = ShellKey.OpenSubKey("Open");
                    var CommandKey = OpenKey.OpenSubKey("Command");

                    if (DefaultIconKey == null || ShellKey == null || OpenKey == null || CommandKey == null)
                    {
                        CreateRegistryKeys();
                        return;
                    }

                    var ProtocolRootValue = ProtocolRoot.GetValue("") != null;
                    var DefaultIconValue = DefaultIconKey.GetValue("") != null;
                    var CommandValue = CommandKey.GetValue("") != null;

                    if (!ProtocolRootValue && !DefaultIconValue && !CommandValue)
                    {
                        CreateRegistryKeys();
                        return;
                    }

                    if (CommandKey.GetValue("").ToString() != RouterCommand)
                        CreateRegistryKeys();
                }
                catch (NullReferenceException)
                {
                    CreateRegistryKeys();
                }
            }
        }

        internal class AccessToken
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
            public string refresh_token { get; set; }
        }
    }
}
