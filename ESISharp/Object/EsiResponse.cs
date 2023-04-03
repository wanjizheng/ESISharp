using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;

namespace ESISharp {
    /// <summary>ESI Reponse Object containing HTTP response information</summary>
    public class EsiResponse {
        internal EsiResponse(string ResponseBody, HttpStatusCode ResponseCode, EsiResponseHeaders ResponseHeaders) {
            Body = ResponseBody;
            Code = ResponseCode;
            Headers = ResponseHeaders;
        }

        internal EsiResponse(string ResponseBody, HttpStatusCode ResponseCode) {
            Body = ResponseBody;
            Code = ResponseCode;
        }

        /// <summary>Response Body</summary>
        public string Body { get; }

        /// <summary>Response HTTP Status Code</summary>
        public HttpStatusCode Code { get; }

        /// <summary>Response Header Serialized</summary>
        public EsiResponseHeaders Headers { get; }
    }

    /// <summary>ESI Serialized HTTP Response Headers</summary>
    public class EsiResponseHeaders {
        internal EsiResponseHeaders(HttpResponseHeaders ResponseHeaders) {
            IEnumerable<string> OutContentType;
            IEnumerable<string> OutDate;
            IEnumerable<string> OutExpires;
            IEnumerable<string> OutLastModified;
            IEnumerable<string> OutPages;
            IEnumerable<string> OutWarning;

            if (ResponseHeaders.TryGetValues("Content-Type", out OutContentType))
                ContentType = OutContentType.First();

            if (ResponseHeaders.TryGetValues("Date", out OutDate))
                Date = DateTime.Parse(OutDate.First());

            if (ResponseHeaders.TryGetValues("Expires", out OutExpires))
                Expires = DateTime.Parse(OutExpires.First());

            if (ResponseHeaders.TryGetValues("Last-Modified", out OutLastModified))
                LastModified = DateTime.Parse(OutLastModified.First());

            if (ResponseHeaders.TryGetValues("X-Pages", out OutPages))
                Pages = int.Parse(OutPages.First());

            if (ResponseHeaders.TryGetValues("Warning", out OutWarning))
                Warning = OutWarning.First();
        }

        /// <summary>Content Type</summary>
        public string ContentType { get; set; }

        /// <summary>Time Request was made</summary>
        public DateTime Date { get; set; }

        /// <summary>Time Request data will be out-of-date</summary>
        public DateTime Expires { get; set; }

        /// <summary>Time Request was last modified</summary>
        public DateTime LastModified { get; set; }

        /// <summary>Number of pages the resource has</summary>
        public int Pages { get; set; }

        /// <summary>ESI warning message</summary>
        public string Warning { get; set; }
    }
}