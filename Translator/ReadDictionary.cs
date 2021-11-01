using System;
using System.Collections.Generic;
using System.IO;

namespace Translator
{
    public sealed class ReadDictionary
    {
        private string _notSerializedFile;
        private readonly string _path;
        public SortedDictionary<string, string> SortedDictionary { get; private set; }

        public ReadDictionary(string path = null)
        {
            _path = path ?? throw new ArgumentNullException(nameof(path));
            _notSerializedFile = string.Empty;
            SortedDictionary = new SortedDictionary<string, string>();
        }

        public bool ContainsKey(string wordIndex)
        {
            return SortedDictionary.ContainsKey(wordIndex);
        }

        public void Remove(string oldWord)
        {
            SortedDictionary.Remove(oldWord);
        }

        public void Add(string newWord, string translations)
        {
            SortedDictionary.Add(newWord, translations);
        }

        public void LoadDictionary()
        {
            using StreamReader sr = new StreamReader(_path);
            _notSerializedFile = sr.ReadToEnd();

            string[] lines = WordsSplitting(_notSerializedFile);
            SortedDictionary = InitDictionary(lines);
        }

        private SortedDictionary<string, string> InitDictionary(string[] lines)
        {
            for (int key = 0; key < lines.Length; key += 2)
            {
                if (lines[key] == string.Empty) continue;
                //SortedDictionary[lines[key]] = lines[key + 1];
                SortedDictionary.Add(lines[key], lines[key + 1]);
            }

            return SortedDictionary;
        }

        private string[] WordsSplitting(string file)
        {
            string[] lines = file.Split('\r');
            TrimArray(lines);
            return lines;
        }

        private void TrimArray(string[] lines)
        {
            for (int i = 0; i < lines.Length; ++i)
            {
                lines[i] = lines[i].Replace('\r', ' ');
                lines[i] = lines[i].Replace('\n', ' ');
                lines[i] = lines[i].Replace('\t', ' ');
                lines[i] = lines[i].Trim(' ');
            }
        }
    }
}