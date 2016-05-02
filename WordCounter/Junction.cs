using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter
{
    //This class is used to contain the Text objects
    //after execution of WordPipeline.
    static class Junction
    {
        static List<Text> texts = new List<Text>();

        //Adds the Text object t the List texts.
        public static void AddText(Text t)
        {
            texts.Add(t);
        }

        public static void WriteToFile()
        {

            string title, formatting, currWord;
            using(System.IO.StreamWriter sw = new System.IO.StreamWriter("Output.txt"))
            {
                foreach(Text t in texts)
                {
                    title = t.FileName;
                    formatting = new String('=', title.Length);

                    //Write name of file.
                    sw.WriteLine(formatting);
                    sw.WriteLine(title);
                    sw.WriteLine(formatting);



                }
            }
        }

        public static List<Text> Texts
        {
            get { return texts; }
            set { texts = value; }
        }
    }
}
