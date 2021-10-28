using System;
using System.Collections.Generic;
using System.IO;

namespace Translator
{
    public sealed class ReadDictionary
    {
        private string _notSerializedFile;
        private string Path { get; }
        public SortedDictionary<string, string> SortedDictionary { get; private set; }


        public ReadDictionary(string path = null)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
            _notSerializedFile = string.Empty;
            SortedDictionary = new SortedDictionary<string, string>();
        }

        public void LoadDictionary()
        {
            if (Path == null) throw new NullReferenceException();
            try
            {
                using StreamReader sr = new StreamReader(Path);
                _notSerializedFile = sr.ReadToEnd();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            string[] lines = WordsSplitting(_notSerializedFile);
            SortedDictionary = InitDictionary(lines);
        }

        private SortedDictionary<string, string> InitDictionary(string[] lines)
        {
            for (int key = 0; key < lines.Length; key += 2)
            {
                if (lines[key] == string.Empty) continue;
                SortedDictionary[lines[key]] = new string(lines[key + 1]);
            }

            return SortedDictionary;
        }

        private string[] WordsSplitting(string file)
        {
            string[] lines = file.Split('\r');
            lines = TrimArray(lines);
            return lines;
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