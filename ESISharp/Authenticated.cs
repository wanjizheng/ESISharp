using ESISharp.Paths.Authenticated;

namespace ESISharp
{
    public class Authenticated : Model.Abstract.EsiConnection
    {
        private Alliance _Alliance;

        public Alliance Alliance => _Alliance;


        public Authenticated(string clientid) : base()
        {
            Initialize();
        }

        public Authenticated(string clientid, string secretkey) : base()
        {
            Initialize();
        }

        private void Initialize()
        {
            _Alliance = new Alliance(this);
        }
    }
}
