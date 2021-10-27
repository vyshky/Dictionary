using System;
using System.Collections.Generic;
using System.IO;

namespace Translator
{
    public sealed class ReadDictionary
    {
        public SortedDictionary<string, string> Words { get; set; } = new();
        private string file;
        public string Path { get; set; }


        public ReadDictionary(string path = null)
        {
            file = string.Empty;
            Path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public void LoadDictionary()
        {
            if (Path == null) throw new NullReferenceException();
            try
            {
                using StreamReader sr = new StreamReader(Path);
                file = sr.ReadToEnd();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            WordsSplitting();
        }

        public void WordsSplitting()
        {
            string[] lines = file.Split('\r');
            lines = TrimArray(lines);

            for (int i = 0; i < lines.Length; i += 2)
            {
                if (lines[i] == string.Empty) continue;
                Words[lines[i]] = new string(lines[i + 1]);
            }
        }

        private string[] TrimArray(string[] lines)
        {
            for (int i = 0; i < lines.Length; ++i)
            {
                lines[i] = lines[i].Replace('\r', ' ');
                lines[i] = lines[i].Replace('\n', ' ');
                lines[i] = lines[i].Replace('\t', ' ');
                lines[i] = lines[i].Trim(' ');
            }

            return lines;
        }
    }
}