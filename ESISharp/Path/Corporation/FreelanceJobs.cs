using ESISharp.Web;

namespace ESISharp.ESIPath.Corporation {
    /// <summary>Authenticated Corporation Freelance Job paths</summary>
    public class CorporationFreelanceJobs {
        protected ESIEve EasyObject;

        internal CorporationFreelanceJobs(ESIEve EasyEve) {
            EasyObject = EasyEve;
        }

        /// <summary>Get Corporation's Freelance Jobs</summary>
        /// <remarks>Requires SSO Authentication, uses "read_freelance_jobs" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="After">(String) Cursor after which to return records</param>
        /// <param name="Before">(String) Cursor before which to return records</param>
        /// <param name="Limit">(Int32) Maximum number of records to return</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetFreelanceJobs(int CorporationID, string After = null, string Before = null, int? Limit = null) {
            var Path = $"/corporations/{CorporationID.ToString()}/freelance-jobs/";
            var Data = new {
                after = After,
                before = Before,
                limit = Limit
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }

        /// <summary>Get Corporation's Freelance Job Participants</summary>
        /// <remarks>Requires SSO Authentication, uses "read_freelance_jobs" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="JobID">(String) Freelance Job ID</param>
        /// <param name="After">(String) Cursor after which to return records</param>
        /// <param name="Before">(String) Cursor before which to return records</param>
        /// <param name="Limit">(Int32) Maximum number of records to return</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetParticipants(int CorporationID, string JobID, string After = null, string Before = null,
            int? Limit = null) {
            var Path = $"/corporations/{CorporationID.ToString()}/freelance-jobs/{JobID}/participants/";
            var Data = new {
                after = After,
                before = Before,
                limit = Limit
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }
    }
}
