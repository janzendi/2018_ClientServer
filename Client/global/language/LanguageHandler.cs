using System.Windows.Forms;

namespace Client.global.language
{
    public static class LanguageHandler
    {
        private static ToolStripStatusLabel obj1000 = null;
        public static void SetLabeltest(ToolStripStatusLabel labeltest)
        {
            obj1000 = labeltest;
        }
        public static string LABELTEST
        {
            get
            {
                obj1000.Text = "Hello World";
                return "";
            }
        }
    }
}
