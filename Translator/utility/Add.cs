using System;

namespace Translator.utility
{
    public class Add
    {
        public static string ConcatValues(string checkTranslations, string[] translationsArray)
        {
            string[] tempTranslation = checkTranslations.Split(';');
            for (int i = 0; i < tempTranslation.Length; ++i)
            {
                for (int y = 0; y < translationsArray.Length; ++y)
                {
                    if (tempTranslation[i] == translationsArray[y])
                    {
                        throw new Exception($"В словаре уже существует перевод : {tempTranslation[i]}");
                    }
                }
            }

            string concatTranslations = checkTranslations;

            foreach (var translation in translationsArray)
            {
                concatTranslations += translation + ";";
            }

            return concatTranslations;
        }

        public static string ConcatValue(string checkTranslations, string translationsArray)
        {
            string[] tempTranslation = checkTranslations.Split(';');
            for (int i = 0; i < tempTranslation.Length; ++i)
            {
                if (translationsArray == tempTranslation[i])
                    throw new Exception($"В словаре уже существует перевод : {tempTranslation[i]}");
            }

            return checkTranslations + tempTranslation + ";";
        }
    }
}