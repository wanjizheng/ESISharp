using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ESISharp.Web {
    internal static class Utils {
        internal static string ConstructUrlArgs(object QueryArguments) {
            var IArguments = QueryArguments.GetType()
                .GetProperties()
                .Where(p => p.GetValue(QueryArguments, null) != null &&
                            GetPropertyValue(p.GetValue(QueryArguments, null)) != null)
                .Select(p => $"{p.Name}={WebUtility.HtmlEncode(GetPropertyValue(p.GetValue(QueryArguments)))}");
            return $"&{string.Join("&", IArguments)}";
        }

        private static string GetPropertyValue(object Property) {
            if (Property is IEnumerable && !(Property is string)) {
                if (Property is IEnumerable<bool>)
                    return string.Join(",", Property as IEnumerable<bool>);
                if (Property is IEnumerable<decimal>)
                    return string.Join(",", Property as IEnumerable<decimal>);
                if (Property is IEnumerable<double>)
                    return string.Join(",", Property as IEnumerable<double>);
                if (Property is IEnumerable<float>)
                    return string.Join(",", Property as IEnumerable<float>);
                if (Property is IEnumerable<int>)
                    return string.Join(",", Property as IEnumerable<int>);
                if (Property is IEnumerable<long>)
                    return string.Join(",", Property as IEnumerable<long>);
                if (Property is IEnumerable<short>)
                    return string.Join(",", Property as IEnumerable<short>);
                if (Property is IEnumerable<string>) return string.Join(",", Property as IEnumerable<string>);
                return null;
            }

            return Property.ToString();
        }
    }
}