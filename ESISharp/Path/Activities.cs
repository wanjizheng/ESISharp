using ESISharp.Web;

namespace ESISharp.ESIPath {
    /// <summary>Public Activity paths</summary>
    public class Activities {
        protected ESIEve EasyObject;

        internal Activities(ESIEve EasyEve) {
            EasyObject = EasyEve;
        }

        /// <summary>Get Raidable Skyhooks</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRaidableSkyhooks() {
            var Path = "/skyhooks/raidable/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }
    }
}