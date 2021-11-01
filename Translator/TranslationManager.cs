using System;
using Translator.utility;

namespace Translator
{
    public sealed class TranslationManager
    {
        private readonly ReadDictionary _readDictionary;
        private readonly WriteDictionary _writeDictionary;

        public TranslationManager(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            _readDictionary = new ReadDictionary(path);
            _writeDictionary = new WriteDictionary(path);
        }

        public void Open()
        {
            try
            {
                _readDictionary.LoadDictionary();
            }
            catch (Exception)
            {
                throw new Exception("Файл не найден");
            }
        }

        public void Save()
        {
            _writeDictionary.WriteToFileAsync(_readDictionary);
        }

        public string Search(string word)
        {
            return _readDictionary.SortedDictionary[word];
        }

        public void ExportToDictionary(string word, string path)
        {
            var readDictionary = new ReadDictionary(path);
            readDictionary.LoadDictionary();
            string translation = _readDictionary.SortedDictionary[word];
            readDictionary.SortedDictionary.Add(word, translation);
            WriteDictionary.ExportToFileAsync(readDictionary, path);
        }

        public void DeleteWord(string word)
        {
            _readDictionary.Remove(word);
        }

        public void DeleteValue(string wordIndex, string deleteElement)
        {
            if (!_readDictionary.SortedDictionary[wordIndex].Contains(deleteElement))
            {
                throw new Exception($"Элемент '{deleteElement}' для удаления не найден");
            }

            string[] translations = _readDictionary.SortedDictionary[wordIndex].Split(";");

            if (translations[1] == "")
            {
                throw new Exception("Запрещено удалять последний элемент");
            }

            string concateTranslation = Concat.DeleteElement(deleteElement, translations);
            _readDictionary.SortedDictionary[wordIndex] = concateTranslation;
        }

        public void AddWord(string word, string translation)
        {
            if (_readDictionary.ContainsKey(word))
                throw new Exception($"Вы не можете добавить '{word}' , так как в словаре уже есть такой ключ");
            _readDictionary.Add(word, translation + ";");
        }

        public void AddValue(string word, params string[] newTranslation)
        {
            if (!_readDictionary.ContainsKey(word))
                throw new Exception("В словаре нет такого слова");

            string concatTranslations =
                Concat.Value(_readDictionary.SortedDictionary[word], newTranslation);
            _readDictionary.SortedDictionary[word] = concatTranslations;
        }

        public void ReplaceKey(string oldWord, string newWord)
        {
            if (!_readDictionary.ContainsKey(oldWord))
                throw new Exception($"Вы не можете изменить слово '{oldWord}' на '{newWord}' , " +
                                    $"так как в словаре не существет слово '{oldWord}'");


            if (_readDictionary.ContainsKey(newWord))
                throw new Exception($"Вы не можете изменить слово '{oldWord}' на '{newWord}' , " +
                                    $"так как в словаре уже существет слово '{newWord}'");

            string oldTranslations = _readDictionary.SortedDictionary[oldWord];
            _readDictionary.Remove(oldWord);
            _readDictionary.Add(newWord, oldTranslations);
        }

        public void ReplaceValue(string wordIndex, string oldTranslation, string newTranslation)
        {
            if (!_readDictionary.ContainsKey(wordIndex))
                throw new Exception("В словаре нет такого слова(ключа)");

            string sendTranslations = _readDictionary.SortedDictionary[wordIndex];
            string finalTranslations =
                Replace.Value(sendTranslations, oldTranslation, newTranslation);
            _readDictionary.SortedDictionary[wordIndex] = finalTranslations;
        }
    }
}