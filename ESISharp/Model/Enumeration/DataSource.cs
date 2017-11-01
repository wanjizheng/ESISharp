using ESISharp.Model.Abstract;

namespace ESISharp.Model.Enumeration
{
    public class DataSource : FakeEnumerator
    {
        internal DataSource(string value) : base(value) { }

        public static readonly DataSource Tranquility = new DataSource("tranquility");
        public static readonly DataSource Singularity = new DataSource("singularity");
    }
}
