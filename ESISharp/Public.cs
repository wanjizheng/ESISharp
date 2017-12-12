using ESISharp.Enumeration;

namespace ESISharp
{
    public class Public : Model.Abstract.EsiConnection
    {
        internal new Access Access = Access.Public;

        private readonly Paths.Public.Alliance _Alliance;
        private readonly Paths.Public.Character _Character;

        public Paths.Public.Alliance Alliance => _Alliance;
        public Paths.Public.Character Character => _Character;

        public Public() : base()
        {
            _Alliance = new Paths.Public.Alliance(this);
            _Character = new Paths.Public.Character(this);
        }
    }
}
