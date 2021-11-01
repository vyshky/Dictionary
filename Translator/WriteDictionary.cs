using System;
using System.IO;
using System.Threading.Tasks;

namespace Translator
{
    public sealed class WriteDictionary
    {
        private readonly string _path;

        public WriteDictionary(string path = null)
        {
            _path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public async void WriteToFileAsync(ReadDictionary dictionary)
        {
            await using StreamWriter file = new StreamWriter(_path, false);
            foreach (var line in dictionary.SortedDictionary)
            {
                await file.WriteLineAsync(line.Key + "\r\t" + line.Value);
            }
        }

        public static async void ExportToFileAsync(ReadDictionary dictionary, string path)
        {
            await using StreamWriter file = new StreamWriter(path, false);
            foreach (var line in dictionary.SortedDictionary)
            {
                await file.WriteLineAsync(line.Key + "\r\t" + line.Value);
            }
        }
    }
}