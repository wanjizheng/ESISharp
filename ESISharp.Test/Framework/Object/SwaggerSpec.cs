using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESISharp.Test.Framework.Object
{

    public class SwaggerSpec
    {
#pragma warning disable IDE1006 // Naming Styles
        public string swagger { get; set; }

        public Dictionary<string, string> info { get; set; }

        public string host { get; set; }

        public string basePath { get; set; }

        public IEnumerable<string> schemes { get; set; }

        public IEnumerable<string> produces { get; set; }

        public Dictionary<string, dynamic> paths { get; set; }

        public SecurityDefinitions securityDefinitions { get; set; }

        public Dictionary<string, ParametersInfo> parameters { get; set; }

        public Dictionary<string, DefinitionInfo> definitions { get; set; }

        public class PathInfo
        {
            public MethodInfo get { get; set; }

            public MethodInfo post { get; set; }

            public MethodInfo put { get; set; }

            public MethodInfo delete { get; set; }

            public class MethodInfo
            {
                public string description { get; set; }

                public string summary { get; set; }

                public IEnumerable<string> tags { get; set; }

                public IEnumerable<ParameterInfo> parameters { get; set; }

                public Dictionary<string, ResponseInfo> responses { get; set; }

                public string operationId { get; set; }

                [JsonProperty(PropertyName = "x-cached-seconds")]
                public string xcachedseconds { get; set; }

                [JsonProperty(PropertyName = "x-alternative-versions")]
                public IEnumerable<string> xalternateversions { get; set; }

                public class ParameterInfo
                {
                    [JsonProperty(PropertyName = "$ref")]
                    public string reference { get; set; }
                }

                public class ResponseInfo
                {
                    public string description { get; set; }

                    public Dictionary<string, string> examples { get; set; }

                    public SchemaInfo schema { get; set; }

                    public Dictionary<string, string> headers { get; set; }

                    public class SchemaInfo
                    {
                        public string type { get; set; }

                        public IEnumerable<string> required { get; set; }

                        public Dictionary<string, string> properties { get; set; }

                        public string title { get; set; }

                        public string description { get; set; }
                    }
                }
            }
        }

        public class SecurityDefinitions
        {
            public EveSso evesso { get; set; }

            public class EveSso
            {
                public string type { get; set; }

                public string authorizationUrl { get; set; }

                public string flow { get; set; }

                public Dictionary<string, string> scopes { get; set; }
            }
        }

        public class ParametersInfo
        {
            public Parameter datasource { get; set; }

            public Parameter user_agent { get; set; }

            [JsonProperty(PropertyName = "X-User-Agent")]
            public Parameter xuseragent { get; set; }

            public Parameter token { get; set; }

            public Parameter character_id { get; set; }

            public Parameter corporation_id { get; set; }

            public Parameter page { get; set; }

            public Parameter language { get; set; }

            public Parameter alliance_id { get; set; }

            public class Parameter
            {
                public string name { get; set; }

                public string description { get; set; }

                public string format { get; set; }

                [JsonProperty(PropertyName = "in")]
                public string inparam { get; set; }

                public bool required { get; set; }

                public string type { get; set; }

                [JsonProperty(PropertyName = "default")]
                public dynamic defaultparam { get; set; }

                [JsonProperty(PropertyName = "enum")]
                public IEnumerable<string> enumparam { get; set; }
            }
        }

        public class DefinitionInfo
        {
            public string type { get; set; }

            public string description { get; set; }

            public string title { get; set; }

            public IEnumerable<string> required { get; set; }

            public Dictionary<string, PropertyInfo> properties { get; set; }

            public class PropertyInfo
            {
                public string type { get; set; }

                public string description { get; set; }
            }
        }
#pragma warning restore IDE1006 // Naming Styles
    }
}
