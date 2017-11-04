using ESISharp.Enumeration;
using System;
using System.Collections.Generic;

namespace ESISharp.Model.Interface
{
    interface IEsiConnect
    {
        void SetDataSource(DataSource datasource);
        void SetResponseType(ResponseType responsetype);
        void SetRetryStrategy(IEnumerable<TimeSpan> delays);
        void SetRoute(Route route);
        void SetTimeout(TimeSpan timespan);
        void SetUserAgent(string useragent);
    }
}
