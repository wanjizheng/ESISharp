using ESISharp.Model.Abstract;
using System.IO;
using System.Text;

namespace ESISharp
{
    public class Public : EsiConnection
    {
        public Public() : base()
        {

        }
    }

    public class TestingCodeSmellDetection
    {
        private int one = 1;
        private int two = 2;
        private int inc = 3;

        public void SomeMethod()
        {
            if (one < two)
            {
                one =+ inc;
            }
        }
    }
}
