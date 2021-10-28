using Translator;

namespace English_Russian_dictionary
{
    class Program
    {
        public static void Main()
        {
            string path =
                @"C:\Users\vyshk\RiderProjects\English-Russian dictionary\Translator\bin\Debug\net5.0\dictionary\Russian.dsl";

            // Запись в файл нового элемента

            string[] translation = new[] { "Translation" };
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

            // Изменение перевода и слова
            TranslationManager manager = new TranslationManager(path);
            manager.ReplaceTranslation("Перевод", "Translation", "NewTranslation");
            manager.ReplaceWord("Перевод", "Translate");

            // TODO :: Написать Эксцэпшин при добавлении EQUALS(Перевод(VALUE));
        }

        public static void AddTranslate(string addWord, string[] translations, string pathDictionary)
        {
            WriteDictionary fileWrite = new WriteDictionary(pathDictionary)
            {
                TranslationsArray = translations
            };
            fileWrite.AddTranslation(addWord);
        }
    }
}