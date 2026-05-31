using System.Collections.Generic;
using System.Linq;
using ESISharp.Web;

namespace ESISharp.ESIPath {
    /// <summary>Public Contracts paths</summary>
    public class Contracts {
        protected ESIEve EasyObject;

        internal Contracts(ESIEve EasyEve) {
            EasyObject = EasyEve;
        }

        /// <summary>Get Public Contracts in a Region, First Page</summary>
        /// <param name="RegionID">(Int64) Region ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetPublicContracts(int RegionID) {
            return GetPublicContracts(RegionID, 1);
        }

        /// <summary>Get Public Contracts in a Region, Specified Page</summary>
        /// <param name="RegionID">(Int64) Region ID</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetPublicContracts(int RegionID, int Page) {
            var Path = $"/contracts/public/{RegionID.ToString()}/";
            var Data = new {
                page = Page
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get, Data);
        }

        /// <summary>Get Public Contract Bids, First Page</summary>
        /// <param name="ContractID">(Int64) Contract ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetPublicContractBids(int ContractID) {
            return GetPublicContractBids(ContractID, 1);
        }

        /// <summary>Get Public Contract Bids, Specified Page</summary>
        /// <param name="ContractID">(Int64) Contract ID</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetPublicContractBids(int ContractID, int Page) {
            var Path = $"/contracts/public/bids/{ContractID.ToString()}/";
            var Data = new {
                page = Page
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get, Data);
        }

        /// <summary>Get Public Contract Items, First Page</summary>
        /// <param name="ContractID">(Int64) Contract ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetPublicContractItems(int ContractID) {
            return GetPublicContractItems(ContractID, 1);
        }

        /// <summary>Get Public Contract Items, Specified Page</summary>
        /// <param name="ContractID">(Int64) Contract ID</param>
        /// <param name="Page">(Int32) Page Number</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetPublicContractItems(int ContractID, int Page) {
            var Path = $"/contracts/public/items/{ContractID.ToString()}/";
            var Data = new {
                page = Page
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get, Data);
        }

        /// <summary>Get Public Contract Details</summary>
        /// <param name="ContractID">(Int64) Contract ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetPublicContractDetails(int ContractID) {
            var Path = $"/contracts/public/{ContractID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get);
        }
    }
}
