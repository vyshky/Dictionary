using System;
using System.Collections.Generic;
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
                @"C:\Users\vyshk\RiderProjects\English-Russian dictionary\Translator\bin\Debug\net5.0\dictionary\Russian.csv";

            // Загрузка файла в память
            Dictionary dictioanary = new Dictionary { Path = path };
            dictioanary.LoadDictionary();

            // Запись в файл нового элемента
            WriteDictionary word = new WriteDictionary { Path = path };
            string[] del = { "Translation" };
            word.AddTranslation("Перевод", del);
        }
    }
}