using ESISharp.Model.Abstract;

namespace ESISharp.Paths.Authenticated.Alliance
{
    public partial class Main : Public.Alliance
    {
        private Contacts _Contacts;

        public Contacts Contacts => _Contacts;

        internal Main(EsiConnection esiconnection) : base(esiconnection)
        {
            _Contacts = new Contacts(esiconnection);
        }
    }
}
