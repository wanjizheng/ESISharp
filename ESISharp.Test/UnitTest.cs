using ESISharp;
using ESISharp.Scopes;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace ESISharp.Test
{
    public class UnitTests
    {
        private readonly ITestOutputHelper Console;

        public UnitTests(ITestOutputHelper Console)
        {
            this.Console = Console;
        }

        [Fact]
        public void Main()
        {
            Console.WriteLine(string.Empty);
        }
    }
}
