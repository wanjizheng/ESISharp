using ESISharp.Web;

namespace ESISharp.ESIPath {
    /// <summary>Public Meta paths</summary>
    public class Meta {
        protected ESIEve EasyObject;

        internal Meta(ESIEve EasyEve) {
            EasyObject = EasyEve;
        }

        /// <summary>Get the changelog of this API</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetChangelog() {
            var Path = "/meta/changelog/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get a list of compatibility dates</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetCompatibilityDates() {
            var Path = "/meta/compatibility-dates/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }

        /// <summary>Get the health status of each API route</summary>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetStatus() {
            var Path = "/meta/status/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }
    }

    /// <summary>Public and Authenticated Meta paths</summary>
    public class AuthMeta : Meta {
        internal AuthMeta(ESIEve EasyEve) : base(EasyEve) {
            EasyObject = EasyEve;
        }
    }
}