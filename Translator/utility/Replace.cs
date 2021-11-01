using System;
using System.Linq;

namespace Translator.utility
{
    public static class Replace
    {
        public static string Value(string getTranslations, string oldValue, string newValue)
        {
            string[] tempValue = getTranslations.Split(';');

            for (int i = 0; i < tempValue.Length; ++i)
            {
                var translation = tempValue[i].TrimStart();
                if (translation != oldValue) continue;

                tempValue[i] = newValue;
                string concatTranslations = Concat.ArrayToString(tempValue);
                return concatTranslations;
            }

            throw new Exception("Перевод(Value) для изменения не найден");
        }
    }
}