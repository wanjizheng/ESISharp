namespace ESISharp.Model.Abstract
{
    public abstract class FakeEnumerator
    {
        public string Value { get; internal set; }

        protected FakeEnumerator(string value) => Value = value;
    }
}
