using ESISharp.Web;

namespace ESISharp.ESIPath.Character {
    /// <summary>Authenticated Character Structure paths</summary>
    public class CharacterStructures {
        protected ESIEve EasyObject;

        internal CharacterStructures(ESIEve EasyEve) {
            EasyObject = EasyEve;
        }

        /// <summary>Get Character Mercenary Dens</summary>
        /// <remarks>Requires SSO Authentication, uses "read_character" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetMercenaryDens(int CharacterID) {
            var Path = $"/characters/{CharacterID.ToString()}/structures/mercenary-dens/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Character Mercenary Den Details</summary>
        /// <remarks>Requires SSO Authentication, uses "read_character" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MercenaryDenID">(String) Mercenary Den ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetMercenaryDen(int CharacterID, string MercenaryDenID) {
            var Path = $"/characters/{CharacterID.ToString()}/structures/mercenary-dens/{MercenaryDenID}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}