using System;
using System.Linq;

namespace Translator.utility
{
    public static class Concat
    {
        public static string Value(string oldTranslations, params string[] newTranslations)
        {
            foreach (var oldT in oldTranslations.Split(';'))
            {
                foreach (var newT in newTranslations)
                {
                    if (oldT == newT)
                    {
                        throw new Exception($"В словаре уже существует перевод : {oldT}");
                    }
                }
            }

            return oldTranslations + ArrayToString(newTranslations);
        }

        public static string ArrayToString(params string[] array)
        {
            string concat = string.Empty;
            foreach (var line in array)
            {
                if (line == string.Empty) continue;
                concat += line + ";";
            }

            return concat;
        }

        public static string DeleteElement(string deleteElement, params string[] array)
        {
            string concat = string.Empty;
            foreach (var line in array)
            {
                if (line == string.Empty || line == deleteElement) continue;
                concat += line + ";";
            }

            return concat;
        }
    }
}