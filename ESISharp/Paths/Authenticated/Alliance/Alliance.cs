using ESISharp.Model.Abstract;

namespace ESISharp.Paths.Authenticated
{
    public partial class Alliance : Public.Alliance
    {
        internal Alliance(EsiConnection esiconnection) : base(esiconnection) { }
    }
}
