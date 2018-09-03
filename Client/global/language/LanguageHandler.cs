using System.Collections.Generic;

namespace Client.global.language
{
    public class LanguageHandler
    {
        private static LanguageHandler instance;
        private LanguageHandler() { }

        /// <summary>
        /// Sinleton-Pattern Eigenschaft
        /// </summary>
        /// <created>janzen_d,2018-09-03</created>
        public static LanguageHandler INSTANCE
        {
            get
            {
                if (instance == null)
                {
                    instance = new LanguageHandler();
                }
                return instance;
            }
        }

        private static Dictionary<int, ObjWord> dictLanguage = new Dictionary<int, ObjWord>();

        public void ReadXml(string path)
        {

        }
    }
}
