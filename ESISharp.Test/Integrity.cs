using ESISharp.Scopes;
using ESISharp.Test.Framework.Abstract;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace ESISharp.Test
{
    public class Integrity : IntegrityTest
    {
        public Integrity(ITestOutputHelper console) : base(console) { }

        [Fact]
        public void Scopes()
        {
            var scopes = Scope.All;
            var specscopes = SwaggerSpec.securityDefinitions.evesso.scopes;
            List<string> diff = new List<string>();
            foreach (KeyValuePair<string, string> s in specscopes)
            {
                if (!scopes.Any(x => x.Value == s.Key))
                {
                    diff.Add(s.Key);
                    Console.WriteLine(s.Key);
                }
            }
            Assert.Empty(diff);
        }
    }
}
