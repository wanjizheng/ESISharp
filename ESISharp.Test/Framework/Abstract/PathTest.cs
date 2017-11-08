using ESISharp.Test.Framework.Helpers;
using Xunit.Abstractions;

namespace ESISharp.Test.Framework.Abstract
{
    public abstract class PathTest
    {
        public readonly ITestOutputHelper Console;
        public readonly bool CredsExist;
        public readonly string ClientID;
        public readonly string SecretKey;

        public readonly Public Public;
        public readonly Authenticated Authenticated;

        protected PathTest(ITestOutputHelper console)
        {
            Console = console;

            Public = new Public();

            CredsExist = DevCredentials.CredentialsExist();
            if (CredsExist)
            {
                var c = DevCredentials.GetCredentials();
                ClientID = c.ClientID;
                SecretKey = c.SecretKey;
                Authenticated = new Authenticated(ClientID, SecretKey);
            }
        }
    }
}
