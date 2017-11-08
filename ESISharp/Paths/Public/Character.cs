using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Object;
using ESISharp.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESISharp.Paths.Public
{
    public class Character : ApiPath
    {
        internal Character(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest GetAffiliation(int CharacterID)
        {
            return GetAffiliation(new int[] { CharacterID });
        }

        public EsiRequest GetAffiliation(IEnumerable<int> CharacterIDs)
        {
            var path = new Path() { "characters", "affiliation" };
            var data = new Data()
            {
                BodyDynamic = CharacterIDs
            };
            return new EsiRequest(EsiConnection, path, WebMethods.POST, data);
        }
    }
}
