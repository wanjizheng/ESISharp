namespace ESISharp.Model.Abstract
{
    public abstract class FakeEnumerator
    {
        public string Value { get; internal set; }

        protected FakeEnumerator(string value)
        {
            this.Value = value;
        }
    }
}
