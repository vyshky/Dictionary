using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Translator
{
    public class Dictionary
    {
        public string Path { get; set; }
        public List<string> Word { get; set; } = new();
        public string FileStr { get; set; }

        public void LoadDictionary()
        {
            if (Path == null) throw new NullReferenceException();
            string[] str;
            try
            {
                using (StreamReader writeLine = new StreamReader(Path))
                {
                    using (StreamReader sr = new StreamReader(Path))
                    {
                        FileStr = sr.ReadToEnd();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            string[] word = FileStr.Split('|');

            for (int i = 0; i < word.Length; ++i)
            {
                word[i] = word[i].Replace('\r', ' ');
                word[i] = word[i].Replace('\n', ' ');
                word[i] = word[i].Trim();
            }

            foreach (var w in word)
            {
                if (w.Contains(';'))
                {
                    Word.Add(w + '|');
                }
            }
        }
    }
}