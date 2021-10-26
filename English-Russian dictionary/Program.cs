using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Translator;

namespace English_Russian_dictionary
{
    class Program
    {
        public static void Main()
        {
            string path =
                @"C:\Users\vyshk\RiderProjects\English-Russian dictionary\Translator\bin\Debug\net5.0\dictionary\Russian.dsl";

            // Загрузка файла в память
            Dictionary dictioanary = new Dictionary { Path = path };
            dictioanary.LoadDictionary();
            //
            // Запись в файл нового элемента

            string[] translation = new[] { "Translation звонок", "Translation2" };
            string word = "Перевод";
            AddTranslate(word, translation, path);

            translation = new[] { "Компьюетерная мыш" };
            word = "Mouse";
            AddTranslate(word, translation, path);

            translation = new[] { "Home" };
            word = "Дом";
            AddTranslate(word, translation, path);

            WriteDictionary word4 = new WriteDictionary { Path = path };
            translation = new[] { "Earth" };
            word = "Земля";
            AddTranslate(word, translation, path);
        }

        public static void AddTranslate(string word, string[] translations, string path)
        {
            WriteDictionary file = new WriteDictionary { Path = path };
            file.Translation = translations;
            file.AddTranslation(word);
        }
    }
}