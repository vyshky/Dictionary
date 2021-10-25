using System;
using System.IO;
using System.Threading.Tasks;

namespace Translator
{
    public class WriteDictionary
    {
        public string Path { get; set; }
        public string[] Translation { get; set; }

        public async Task AddTranslation(string word, string[] translation)
        {
            if (Path == null) throw new NullReferenceException();
            Dictionary file = new Dictionary { Path = this.Path };
            file.LoadDictionary();

            string addTranslate = "=";

            for (int i = 0; i < file.Word.Count; ++i)
            {
                if (file.Word[i].Contains(word))
                {
                    addTranslate = file.Word[i];
                    file.Word.RemoveAt(i);

                    int index = addTranslate.IndexOf('=');
                    addTranslate = addTranslate.Remove(0, index);
                    index = addTranslate.LastIndexOf('|');
                    addTranslate = addTranslate.Remove(index);
                }
            }

            string translationSum = null;
            foreach (var i in translation)
            {
                translationSum += i + ";";
            }

            file.Word.Add(word + addTranslate + translationSum + '|');

            using (StreamWriter sw = new StreamWriter(Path, false, System.Text.Encoding.Default))
            {
                foreach (var w in file.Word)
                {
                    await sw.WriteLineAsync(w);
                }
            }
        }
    }
}