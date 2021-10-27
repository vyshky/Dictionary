namespace Translator
{
    public class Translation
    {
        public ReadDictionary readDictionary;
        public WriteDictionary writeDictionary;
        public Translation(string path)
        {
            readDictionary.Path = path;
            writeDictionary.Path = path;
        }
        
        
    }
}