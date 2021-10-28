using System;
using System.Collections.Generic;

namespace Translator
{
    public sealed class TranslationManager
    {
        private readonly ReadDictionary _readDictionary;
        private readonly WriteDictionary _writeDictionary;

        public TranslationManager(string path)
        {
            _readDictionary = new ReadDictionary(path);
            _writeDictionary = new WriteDictionary(path);
        }

        public void ReplaceTranslation(string wordIndex, string oldTranslation, string newTranslation)
        {
            _readDictionary.LoadDictionary();
            if (!_readDictionary.SortedDictionary.ContainsKey(wordIndex))
                throw new Exception("В словаре нет такого слова(ключа)");

            string finalTranslations = ReplaceValue(wordIndex, oldTranslation, newTranslation);
            _readDictionary.SortedDictionary[wordIndex] = finalTranslations;
            _writeDictionary.WriteToFile(_readDictionary);
        }

        private string ReplaceValue(string indexWord, string oldValue, string newValue)
        {
            string[] tempTranslations = _readDictionary.SortedDictionary[indexWord].Split(';');

            for (int value = 0; value < tempTranslations.Length; ++value)
            {
                var translation = tempTranslations[value].TrimStart();
                if (translation == oldValue)
                {
                    tempTranslations[value] = newValue;
                    string concatTranslations = ConcatArrayTranslations(tempTranslations);
                    return concatTranslations;
                }
            }

            throw new Exception("Перевод(Value) для изменения не найден");
        }

        private string ConcatArrayTranslations(string[] array)
        {
            string concat = string.Empty;
            foreach (var line in array)
            {
                if (line == string.Empty) continue;
                concat += line + ";";
            }

            return concat;
        }

        public void ReplaceWord(string oldWord, string newWord)
        {
            if (_readDictionary.SortedDictionary.ContainsKey(newWord))
                throw new Exception($"Вы не можете изменить слово '{oldWord}' на '{newWord}' , " +
                                    $"так как в словаре уже существет слово '{newWord}'");
            _readDictionary.LoadDictionary();
            if (_readDictionary.SortedDictionary.ContainsKey(oldWord))
            {
                string tempTranslations = _readDictionary.SortedDictionary[oldWord];
                _readDictionary.SortedDictionary.Remove(oldWord);
                _readDictionary.SortedDictionary.Add(newWord, tempTranslations);
                _writeDictionary.WriteToFile(_readDictionary);
            }
        }
    }
}