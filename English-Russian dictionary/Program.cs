using Translator;

namespace English_Russian_dictionary
{
    class Program
    {
        public static void Main()
        {
            string path =
                @"C:\Users\vyshk\RiderProjects\English-Russian dictionary\Translator\bin\Debug\net5.0\dictionary\Russian.dsl";
            TranslationManager fileWrite = new TranslationManager(path);

            // string[] translationArray = { "Мир привет", "Privet mir" };
            // string helloWorld = "Hello World";
            // fileWrite.AddWord("Hello World", "Привет мир");
            // fileWrite.AddValues(helloWorld, translationArray);
            //
            // // Запись в файл нового элемента
            // string word = "Перевод";
            // fileWrite.AddWord(word, "Translation");
            //
            // word = "Мыш";
            // fileWrite.AddWord(word, "Mouse");
            //
            // word = "Дом";
            // fileWrite.AddWord(word, "Home");
            //
            // word = "Земля";
            // fileWrite.AddWord(word, "Earth");

            // // Изменение перевода и слова
            // TranslationManager manager = new TranslationManager(path);
            // manager.ReplaceValue("Перевод", "Translation", "NewTranslation");
            // manager.ReplaceKey("Перевод", "Измененный Перевод");
        }
    }
}