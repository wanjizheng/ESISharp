using ESISharp.Enumeration;
using ESISharp.Test.Framework.Object;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web;
using Xunit;
using Xunit.Abstractions;

namespace ESISharp.Test.Framework.Abstract
{
    public abstract class IntegrityTest
    {
        public readonly ITestOutputHelper Console;

        public readonly UriBuilder Url;
        public readonly SwaggerSpec SwaggerSpec;

        protected IntegrityTest(ITestOutputHelper console)
        {
            Console = console;

            Url = new UriBuilder()
            {
                Scheme = "https",
                Host = "esi.tech.ccp.is"
            };
            Url.Path = String.Join("/", new string[] { "latest", "swagger.json" });
            var Query = HttpUtility.ParseQueryString(Url.Query);
            Query["datasource"] = DataSource.Tranquility.Value;
            Url.Query = Query.ToString();

            using (var c = new WebClient())
            {
                var d = c.DownloadString(Url.ToString());
                SwaggerSpec = JsonConvert.DeserializeObject<SwaggerSpec>(d);
            }
        }
    }
}
