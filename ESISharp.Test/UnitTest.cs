using ESISharp;
using ESISharp.Model.Enumeration.Scopes;
using System;
using System.Collections.Generic;
using Xunit;

namespace ESISharp.Test
{
    public class UnitTests
    {
        readonly Public PTest = new Public();
        
        [Fact]
        public void Main()
        {
            PTest.SetUserAgent("ayyy");
        }
    }
}
