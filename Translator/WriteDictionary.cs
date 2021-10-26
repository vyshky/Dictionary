using System;
using System.IO;
using System.Threading.Tasks;

namespace Translator
{
    public class WriteDictionary
    {
        public string Path { get; set; }
        public string[] Translation { get; set; }

        public async Task AddTranslation(string checkWord)
        {
            if (Path == null) throw new NullReferenceException();
            Dictionary file = new Dictionary { Path = this.Path };
            file.LoadDictionary();

            string concat = string.Empty;
            foreach (var T in Translation)
            {
                concat += T + ";";
            }

            if (file.Word.ContainsKey(checkWord))
            {
                file.Word[checkWord] += concat;
            }
            else
            {
                file.Word[checkWord] = new string(concat);
            }

            using (StreamWriter sw = new StreamWriter(Path, false, System.Text.Encoding.Default))
            {
                var line = file.Word;

                foreach (var l in line)
                {
                    await sw.WriteLineAsync(l.Key + "\r\t" + l.Value);
                }
            }
        }
    }
}