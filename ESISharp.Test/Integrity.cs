using ESISharp.Model.Attributes;
using ESISharp.Scopes;
using ESISharp.Test.Framework.Abstract;
using ESISharp.Test.Framework.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;
namespace ESISharp.Test
{
    public class Integrity : IntegrityTest
    {
        public Integrity(ITestOutputHelper console) : base(console) { }

        [Fact]
        [Trait("ESI API", "Integrity")]
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

        [Fact]
        [Trait("ESI API", "Integrity")]
        public void Paths()
        {
            var assypaths = Assembly.GetAssembly(typeof(Public))
                        .GetTypes()
                        .SelectMany(a => a.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                        .Where(b => Attribute.IsDefined(b, typeof(PathAttribute)))
                        .ToList();
            var paths = assypaths.Select(x => new { x.GetCustomAttribute<PathAttribute>().Path, Method = x.GetCustomAttribute<PathAttribute>().Method.ToString() }).ToList();
            var specpaths = SwaggerSpec.paths;
            List<object> diff = new List<object>();
            foreach (KeyValuePair<string, Dictionary<string, SwaggerSpec.MethodInfo>> sp in specpaths)
            {
                var lp = paths.Where(x => x.Path == sp.Key).ToList();

                foreach (KeyValuePair<string, SwaggerSpec.MethodInfo> spm in sp.Value)
                {
                    if (!lp.Any(x => String.Equals(x.Method, spm.Key, StringComparison.OrdinalIgnoreCase)))
                    {
                        diff.Add( new { sp.Key, Value = spm.Key } );
                        Console.WriteLine(sp.Key + "  :  " + spm.Key.ToUpper());
                    }
                }
            }
            Assert.Empty(diff);
        }
    }
}
