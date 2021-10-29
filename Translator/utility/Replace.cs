using System;

namespace Translator.utility
{
    public class Replace
    {
        public static string Value(string getTranslations, string oldValue, string newValue)
        {
            string[] tempValue = getTranslations.Split(';');

            for (int i = 0; i < tempValue.Length; ++i)
            {
                var translation = tempValue[i].TrimStart();
                if (translation == oldValue)
                {
                    tempValue[i] = newValue;
                    string concatTranslations = ConcatArrayTranslations(tempValue);
                    return concatTranslations;
                }
            }

            throw new Exception("Перевод(Value) для изменения не найден");
        }

        private static string ConcatArrayTranslations(string[] array)
        {
            string concat = string.Empty;
            foreach (var line in array)
            {
                if (line == string.Empty) continue;
                concat += line + ";";
            }

            return concat;
        }
    }
}