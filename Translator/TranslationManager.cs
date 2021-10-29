using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Translator.utility;

namespace Translator
{
    public sealed class TranslationManager
    {
        private readonly ReadDictionary _readDictionary;
        private readonly WriteDictionary _writeDictionary;
        private readonly string _path;

        public TranslationManager(string path)
        {
            _path = path;
            _readDictionary = new ReadDictionary(path);
            _writeDictionary = new WriteDictionary(path);
        }

        public void AddWord(string word, string translation)
        {
            if (_path == null) throw new NullReferenceException();
            _readDictionary.LoadDictionary();
            if (_readDictionary.SortedDictionary.ContainsKey(word))
                throw new Exception($"Вы не можете добавить '{word}' , так как в словаре уже есть такой ключ");
            _readDictionary.SortedDictionary.Add(word, translation + ";");
            _writeDictionary.WriteToFile(_readDictionary);
        }

        public void AddValues(string checkWord, string[] translationsArray)
        {
            if (_path == null) throw new NullReferenceException();
            _readDictionary.LoadDictionary();

            if (!_readDictionary.SortedDictionary.ContainsKey(checkWord))
                throw new Exception("В словаре нет такого слова");

            string concatTranslations = Add.ConcatValues(_readDictionary.SortedDictionary[checkWord], translationsArray);
            _readDictionary.SortedDictionary[checkWord] = concatTranslations;
            _writeDictionary.WriteToFile(_readDictionary);
        }

        public void AddValue(string checkWord, string translationArray)
        {
            if (_path == null) throw new NullReferenceException();
            _readDictionary.LoadDictionary();

            if (!_readDictionary.SortedDictionary.ContainsKey(checkWord))
                throw new Exception("В словаре нет такого слова");

            string concatTranslations = Add.ConcatValue(_readDictionary.SortedDictionary[checkWord], translationArray);
            _readDictionary.SortedDictionary[checkWord] = concatTranslations;
            _writeDictionary.WriteToFile(_readDictionary);
        }

        public void ReplaceValue(string wordIndex, string oldTranslation, string newTranslation)
        {
            _readDictionary.LoadDictionary();
            if (!_readDictionary.SortedDictionary.ContainsKey(wordIndex))
                throw new Exception("В словаре нет такого слова(ключа)");

            string sendTranslations = _readDictionary.SortedDictionary[wordIndex];
            string finalTranslations =
                Replace.Value(sendTranslations, oldTranslation, newTranslation);
            _readDictionary.SortedDictionary[wordIndex] = finalTranslations;
            _writeDictionary.WriteToFile(_readDictionary);
        }


        public void ReplaceKey(string oldWord, string newWord)
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