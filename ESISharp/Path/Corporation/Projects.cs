using ESISharp.Web;

namespace ESISharp.ESIPath.Corporation {
    /// <summary>Authenticated Corporation Projects paths</summary>
    public class CorporationProjects {
        protected ESIEve EasyObject;

        internal CorporationProjects(ESIEve EasyEve) {
            EasyObject = EasyEve;
        }

        /// <summary>Get Corporation's Projects</summary>
        /// <remarks>Requires SSO Authentication, uses "read_projects" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="After">(String) Cursor after which to return records</param>
        /// <param name="Before">(String) Cursor before which to return records</param>
        /// <param name="Limit">(Int32) Maximum number of records to return</param>
        /// <param name="State">(String) Project state filter</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetProjects(int CorporationID, string After = null, string Before = null, int? Limit = null,
            string State = "Active") {
            var Path = $"/corporations/{CorporationID.ToString()}/projects/";
            var Data = new {
                after = After,
                before = Before,
                limit = Limit,
                state = State
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }

        /// <summary>Get Corporation Project Details</summary>
        /// <remarks>Requires SSO Authentication, uses "read_projects" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="ProjectID">(String) Project ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetProject(int CorporationID, string ProjectID) {
            var Path = $"/corporations/{CorporationID.ToString()}/projects/{ProjectID}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Corporation Project Contribution</summary>
        /// <remarks>Requires SSO Authentication, uses "read_projects" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="ProjectID">(String) Project ID</param>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetContribution(int CorporationID, string ProjectID, int CharacterID) {
            var Path = $"/corporations/{CorporationID.ToString()}/projects/{ProjectID}/contribution/{CharacterID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Get Corporation Project Contributors</summary>
        /// <remarks>Requires SSO Authentication, uses "read_projects" scope</remarks>
        /// <param name="CorporationID">(Int32) Corporation ID</param>
        /// <param name="ProjectID">(String) Project ID</param>
        /// <param name="After">(String) Cursor after which to return records</param>
        /// <param name="Before">(String) Cursor before which to return records</param>
        /// <param name="Limit">(Int32) Maximum number of records to return</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetContributors(int CorporationID, string ProjectID, string After = null,
            string Before = null, int? Limit = null) {
            var Path = $"/corporations/{CorporationID.ToString()}/projects/{ProjectID}/contributors/";
            var Data = new {
                after = After,
                before = Before,
                limit = Limit
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }
    }
}
