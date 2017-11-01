using ESISharp.Model.Abstract;

namespace ESISharp.Model.Enumeration
{
    public class ResponseType : FakeEnumerator
    {
        internal ResponseType(string value) : base(value) { }

        public static readonly ResponseType Json = new ResponseType("application/json");
    }
}
