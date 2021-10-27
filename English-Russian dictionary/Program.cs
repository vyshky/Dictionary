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
            ReadDictionary dictioanary = new ReadDictionary(path);
            dictioanary.LoadDictionary();
           

            // Запись в файл нового элемента

            string[] translation = new[] { "Translations" };
            string word = "Перевод";
            AddTranslate(word, translation, path);

            translation = new[] { "Mouse" };
            word = "Мыш";
            AddTranslate(word, translation, path);

            translation = new[] { "Home" };
            word = "Дом";
            AddTranslate(word, translation, path);

            translation = new[] { "Earth" };
            word = "Земля";
            AddTranslate(word, translation, path);
        }

        public static void AddTranslate(string addWord, string[] translations, string pathDictionary)
        {
            WriteDictionary fileWrite = new WriteDictionary(pathDictionary)
            {
                Translations = translations
            };
            fileWrite.AddTranslation(addWord);
        }
    }
}