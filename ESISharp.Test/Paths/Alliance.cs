using ESISharp.Test.Framework.Abstract;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using Xunit;
using Xunit.Abstractions;

namespace ESISharp.Test.Paths
{
    public class Alliance : PathTest
    {
        public Alliance(ITestOutputHelper console) : base(console) { }

        [Fact]
        public void Public_GetAll()
        {
            var r = Public.Alliance.GetAll().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
            Assert.NotEmpty(JsonConvert.DeserializeObject<List<dynamic>>(r.Body));
        }

        [Theory]
        [InlineData(1354830081)]
        [InlineData(new long[] { 1354830081, 99002782 })]
        public void Public_GetNames(dynamic AllianceIDs)
        {
            var r = Public.Alliance.GetNames(AllianceIDs).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
            Assert.NotEmpty(JsonConvert.DeserializeObject<List<dynamic>>(r.Body));
        }
    }
}
