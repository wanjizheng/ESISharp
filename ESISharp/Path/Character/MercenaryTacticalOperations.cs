using ESISharp.Web;

namespace ESISharp.ESIPath.Character {
    /// <summary>Authenticated Character Mercenary Tactical Operation paths</summary>
    public class CharacterMercenaryTacticalOperations {
        protected ESIEve EasyObject;

        internal CharacterMercenaryTacticalOperations(ESIEve EasyEve) {
            EasyObject = EasyEve;
        }

        /// <summary>Get Mercenary Tactical Operations</summary>
        /// <remarks>Requires SSO Authentication, uses "read_character" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetOperations(int CharacterID) {
            var Path = $"/characters/{CharacterID.ToString()}/mercenary-tactical-operations/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Mercenary Tactical Operation Details</summary>
        /// <remarks>Requires SSO Authentication, uses "read_character" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="OperationID">(String) Operation ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetOperation(int CharacterID, string OperationID) {
            var Path = $"/characters/{CharacterID.ToString()}/mercenary-tactical-operations/{OperationID}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}