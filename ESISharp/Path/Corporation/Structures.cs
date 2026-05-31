using ESISharp.Web;

namespace ESISharp.ESIPath.Corporation {
    /// <summary>Authenticated Corporation Structure paths</summary>
    public class CorporationStructures {
        protected ESIEve EasyObject;

        internal CorporationStructures(ESIEve EasyEve) {
            EasyObject = EasyEve;
        }

        /// <summary>Get Corporation Skyhooks</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetSkyhooks(int CorporationID) {
            var Path = $"/corporations/{CorporationID.ToString()}/structures/skyhooks/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Skyhook Details</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="SkyhookID">(String) Skyhook ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetSkyhook(int CorporationID, string SkyhookID) {
            var Path = $"/corporations/{CorporationID.ToString()}/structures/skyhooks/{SkyhookID}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Corporation Sovereignty Hubs</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetSovereigntyHubs(int CorporationID) {
            var Path = $"/corporations/{CorporationID.ToString()}/structures/sovereignty-hubs/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Sovereignty Hub Details</summary>
        /// <remarks>Requires SSO Authentication, uses "read_corporation" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="SovereigntyHubID">(String) Sovereignty Hub ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetSovereigntyHub(int CorporationID, string SovereigntyHubID) {
            var Path = $"/corporations/{CorporationID.ToString()}/structures/sovereignty-hubs/{SovereigntyHubID}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}