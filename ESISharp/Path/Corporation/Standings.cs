using ESISharp.Web;

namespace ESISharp.ESIPath.Corporation {
    /// <summary>Authenticated Corporation Standings paths</summary>
    public class CorporationStandings {
        protected ESIEve EasyObject;

        internal CorporationStandings(ESIEve EasyEve) {
            EasyObject = EasyEve;
        }

        /// <summary>Get corporation standings from agents, NPC corporations, and factions</summary>
        /// <remarks>Requires SSO Authentication, using "read_standings" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetStandings(int CorporationID) {
            var Path = $"/corporations/{CorporationID.ToString()}/standings/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}