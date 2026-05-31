using ESISharp.Web;

namespace ESISharp.ESIPath.Corporation {
    /// <summary>Authenticated Corporation Shares paths</summary>
    public class CorporationShares {
        protected ESIEve EasyObject;

        internal CorporationShares(ESIEve EasyEve) {
            EasyObject = EasyEve;
        }

        /// <summary>Get corporation shares</summary>
        /// <remarks>Requires SSO Authentication, using "read_shares" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetShares(int CorporationID) {
            var Path = $"/corporations/{CorporationID.ToString()}/shares/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get corporation shareholders</summary>
        /// <remarks>Backward-compatible alias for GetShares()</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetShareholders(int CorporationID) {
            return GetShares(CorporationID);
        }
    }
}