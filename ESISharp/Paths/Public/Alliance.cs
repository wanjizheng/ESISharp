using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Public
{
    public class Alliance : ApiPath
    {
        internal Alliance(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest GetAll()
        {
            var path = new Path() { "alliances" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetName(long AllianceID)
        {
            return GetNames(new long[] { AllianceID });
        }

        public EsiRequest GetNames(IEnumerable<long> AllianceIDs)
        {
            var path = new Path() { "alliances", "names" };
            var data = new Data()
            {
                Query = new Dictionary<string, dynamic>()
                {
                    ["alliance_ids"] = AllianceIDs
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }
    }
}
