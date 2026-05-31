using ESISharp.Web;

namespace ESISharp.ESIPath {
    /// <summary>Public Faction paths</summary>
    public class Factions {
        protected ESIEve EasyObject;

        internal Factions(ESIEve EasyEve) {
            EasyObject = EasyEve;
        }

        /// <summary>Get Factions</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetAll() {
            var Path = "/factions/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }
    }
}