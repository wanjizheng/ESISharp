using ESISharp.Web;

namespace ESISharp.ESIPath.Character {
    /// <summary>Authenticated Character Freelance Job paths</summary>
    public class CharacterFreelanceJobs {
        protected ESIEve EasyObject;

        internal CharacterFreelanceJobs(ESIEve EasyEve) {
            EasyObject = EasyEve;
        }

        /// <summary>List freelance jobs for a character</summary>
        /// <remarks>Requires SSO Authentication, using "esi-characters.read_freelance_jobs.v1" scope</remarks>
        /// <param name="CharacterID">Character ID</param>
        /// <param name="After">Cursor after which to return records</param>
        /// <param name="Before">Cursor before which to return records</param>
        /// <param name="Limit">Number of records to retrieve per request</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetFreelanceJobs(int CharacterID, string After = null, string Before = null, int? Limit = null) {
            var Path = $"/characters/{CharacterID.ToString()}/freelance-jobs/";
            var Data = new {
                after = After,
                before = Before,
                limit = Limit
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }

        /// <summary>Get participation details for a freelance job</summary>
        /// <remarks>Requires SSO Authentication, using "esi-characters.read_freelance_jobs.v1" scope</remarks>
        /// <param name="CharacterID">Character ID</param>
        /// <param name="JobID">Freelance Job UUID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetFreelanceJobParticipation(int CharacterID, string JobID) {
            var Path = $"/characters/{CharacterID.ToString()}/freelance-jobs/{JobID}/participation/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }
    }
}