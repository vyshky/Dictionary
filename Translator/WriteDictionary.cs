using System;
using System.IO;
using System.Threading.Tasks;

namespace Translator
{
    public class WriteDictionary
    {
        public string Path { get; set; }
        public string[] Translations { get; set; }

        public async Task AddTranslation(string checkWord, ReadDictionary file)
        {
            if (Path == null) throw new NullReferenceException();
            //ReadDictionary file = new ReadDictionary { Path = this.Path };
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