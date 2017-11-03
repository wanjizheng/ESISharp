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
        private FileStream fs;

        public void OpenResource(string path)
        {
            this.fs = new FileStream(path, FileMode.Open);
        }

        public void WriteToFile(string path, string text)
        {
            var fs = new FileStream(path, FileMode.Open);
            var bytes = Encoding.UTF8.GetBytes(text);
            fs.Write(bytes, 0, bytes.Length);
        }
    }
}
