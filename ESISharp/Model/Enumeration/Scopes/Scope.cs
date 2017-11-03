using ESISharp.Model.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ESISharp.Model.Enumeration.Scopes
{
    public sealed partial class Scope : FakeEnumerator
    {
        internal static readonly Dictionary<string, Scope> Lookup = new Dictionary<string, Scope>();

        internal Scope(string value) : base(value)
        {
            if (value != string.Empty)
            {
                Lookup.Add(value, this);
            }
        }

        public static readonly IEnumerable<Scope> All = Lookup.Values.ToList();

        public static readonly Scope None = new Scope(string.Empty);
    }
}
