using System;
using System.IO;
using System.Threading.Tasks;

namespace Translator
{
    public sealed class WriteDictionary
    {
        ReadDictionary file;
        public string Path { get; set; }
        public string[] Translations { get; set; }

        public WriteDictionary(string path = null)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
            file = new ReadDictionary(path);
        }

        public async Task AddTranslation(string checkWord)
        {
            if (Path == null) throw new NullReferenceException();
            
            file.LoadDictionary();

            string concat = string.Empty;
            foreach (var T in Translations)
            {
                concat += T + ";";
            }

            if (file.Words.ContainsKey(checkWord))
            {
                file.Words[checkWord] += concat;
            }
            else
            {
                file.Words[checkWord] = new string(concat);
            }

            using (StreamWriter sw = new StreamWriter(Path, false, System.Text.Encoding.Default))
            {
                var lines = file.Words;

                foreach (var l in lines)
                {
                    await sw.WriteLineAsync(l.Key + "\r\t" + l.Value);
                }
            }
        }
    }
}