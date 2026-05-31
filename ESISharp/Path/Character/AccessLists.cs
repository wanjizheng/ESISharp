using ESISharp.Web;

namespace ESISharp.ESIPath.Character {
    /// <summary>Authenticated Character Access List paths</summary>
    public class CharacterAccessLists {
        protected ESIEve EasyObject;

        internal CharacterAccessLists(ESIEve EasyEve) {
            EasyObject = EasyEve;
        }

        /// <summary>List Access Lists for a character</summary>
        /// <remarks>Requires SSO Authentication, using "esi-access.read_lists.v1" scope</remarks>
        /// <param name="CharacterID">Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetAccessLists(int CharacterID) {
            var Path = $"/characters/{CharacterID.ToString()}/access-lists/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Access List details</summary>
        /// <remarks>Requires SSO Authentication, using "esi-access.read_lists.v1" scope</remarks>
        /// <param name="CharacterID">Character ID</param>
        /// <param name="AccessListID">Access List ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetAccessListDetails(int CharacterID, long AccessListID) {
            var Path = $"/characters/{CharacterID.ToString()}/access-lists/{AccessListID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}