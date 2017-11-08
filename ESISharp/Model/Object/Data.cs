using System.Collections.Generic;

namespace ESISharp.Model.Object
{
    internal class Data
    {
        private Dictionary<string, dynamic> _Query;
        private Dictionary<string, dynamic> _BodyKvp;
        private dynamic _BodyDynamic;

        internal Dictionary<string, dynamic> Query { get => _Query; set => _Query = value; }
        internal Dictionary<string, dynamic> BodyKvp { get => _BodyKvp; set => _BodyKvp = value; }
        internal dynamic BodyDynamic { get => _BodyDynamic; set => _BodyDynamic = value; }
    }
}
