using ESISharp.Enumeration;
using ESISharp.Paths.Authenticated;

namespace ESISharp
{
    public class Authenticated : Model.Abstract.EsiConnection
    {
        internal new Access Access = Access.Authenticated;

        private readonly Paths.Authenticated.Alliance.Main _Alliance;

        public Paths.Authenticated.Alliance.Main Alliance => _Alliance;

        public Authenticated(string clientid) : base()
        {
            _Alliance = new Paths.Authenticated.Alliance.Main(this);
        }

        public Authenticated(string clientid, string secretkey) : this(clientid)
        {
            
        }
    }
}
