using System.IO;
using Translator;

namespace English_Russian_dictionary
{
    class Program
    {
        public static void Main()
        {
            string path = @"dictionary/Russian.dsl2";
            string path2 = @"dictionary/English.dsl2";
            TranslationManager manager = new TranslationManager(path);

            manager.Open();

            if (!File.Exists(path))
            {
                //TODO : Что лучше?
                // FileInfo newFile = new FileInfo(_path);
                // FileStream fs = newFile.Create();
                // fs.Close();
                //TODO : ИЛИ ЭТО
                using (File.Create(path)) ;
            }

            if (!File.Exists(path2))
            {
                //TODO : Что лучше?
                // FileInfo newFile = new FileInfo(_path);
                // FileStream fs = newFile.Create();
                // fs.Close();
                //TODO : ИЛИ ЭТО
                using (File.Create(path2)) ;
            }


            // string[] translationArray = { "Mir privet", "Privet mir" };
            // string helloWorld = "Привет мир";
            // manager.AddWord("Привет мир", "Hello World");
            // manager.AddValue(helloWorld, translationArray);
            // manager.AddValue(helloWorld, "Удали меня");
            //
            // // // Запись в файл нового элемента
            // string word = "Перевод";
            // manager.AddWord(word, "Translation");
            //
            // word = "Дом";
            // manager.AddWord(word, "Home");
            //
            // word = "Земля";
            // manager.AddWord(word, "Earth");


            //manager.DeleteWord("Привет мир");
            //manager.DeleteValue("Перевод", "Translation");

            //Console.WriteLine($"Привет мир -  {manager.Search("Привет мир")}");
            manager.ExportToDictionary("Дом", path2);

            manager.Save();

            // // // Изменение перевода и слова
            // manager.ReplaceValue("Перевод", "Translation", "NewTranslation");
            // manager.ReplaceKey("Перевод", "Измененный Перевод");
        }
    }
}