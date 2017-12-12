using ESISharp.Test.Framework.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ESISharp.Test.Paths
{
    public class Character : PathTest
    {
        public Character(ITestOutputHelper console) : base(console) { }

        [Theory]
        [InlineData(91105772)]
        [InlineData(new int[] { 91105772, 95589933 })]
        [Trait("Path", "Alliance")]
        public void Public_GetCharacterAffiliation(dynamic CharacterIDs)
        {
            var r = Public.Character.GetAffiliation(CharacterIDs).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
            Assert.NotEmpty(JsonConvert.DeserializeObject<List<dynamic>>(r.Body));
        }
    }
}
