using System;
using System.Collections.Generic;
using System.IO;

namespace Translator
{
    public class ReadDictionary
    {
        public string Path { get; set; }
        public SortedDictionary<string, string> Words { get; set; } = new();
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

            string[] lines = FileStr.Split('\r');
            lines = Trim(lines);

            for (int i = 0; i < lines.Length; i += 2)
            {
                if (lines[i] == "") continue;
                Words[lines[i]] = new string(lines[i + 1]);
            }
        }

        public string[] Trim(string[] lines)
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