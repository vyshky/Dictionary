using System;
using System.IO;
using System.Threading.Tasks;

namespace Translator
{
    public sealed class WriteDictionary
    {
        private readonly ReadDictionary _file;
        private string Path { get; set; }
        public string[] TranslationsArray { get; set; }

        public WriteDictionary(string path = null)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
            _file = new ReadDictionary(path);
        }

        public void AddTranslation(string checkWord)
        {
            if (Path == null) throw new NullReferenceException();

            _file.LoadDictionary();
            string concatTranslations = string.Empty;
            foreach (var translation in TranslationsArray)
            {
                concatTranslations += translation + ";";
            }

            if (_file.SortedDictionary.ContainsKey(checkWord))
            {
                _file.SortedDictionary[checkWord] += concatTranslations;
            }
            else
            {
                _file.SortedDictionary[checkWord] = new string(concatTranslations);
            }

            WriteToFile(_file);
        }

        public async void WriteToFile(ReadDictionary file)
        {
            using (StreamWriter sw = new StreamWriter(Path, false, System.Text.Encoding.Default))
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