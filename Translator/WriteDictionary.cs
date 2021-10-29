using System;
using System.IO;
using System.Threading.Tasks;

namespace Translator
{
    public sealed class WriteDictionary
    {
        private readonly string _path;
        private readonly ReadDictionary _file;

        public WriteDictionary(string path = null)
        {
            _path = path ?? throw new ArgumentNullException(nameof(path));
            _file = new ReadDictionary(path);
        }

        public async void WriteToFile(ReadDictionary file)
        {
            using (StreamWriter sw = new StreamWriter(_path, false, System.Text.Encoding.Default))
            {
                var lines = file.SortedDictionary;

                foreach (var l in lines)
                {
                    await sw.WriteLineAsync(l.Key + "\r\t" + l.Value);
                }
            }
        }
    }
}