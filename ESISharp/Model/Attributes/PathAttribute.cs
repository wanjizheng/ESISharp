using ESISharp.Enumeration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESISharp.Model.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    internal class PathAttribute : Attribute
    {
        internal readonly string Path;
        internal readonly WebMethods Method;

        internal PathAttribute(string path, WebMethods method)
        {
            Path = path;
            Method = method;
        }
    }
}
