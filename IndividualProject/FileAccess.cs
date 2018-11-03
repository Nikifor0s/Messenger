using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class FileAccess
    {
        public static string CreateFile(string message, string subfolder)
        {

            string filePath = @"C:\Users\Nikiforos\source\repos\IndividualProject\IndividualProject";// file path
            string extendFilePath = Path.Combine(filePath, subfolder);//extend the path and add  a folder name 
            var createFile = Directory.CreateDirectory(extendFilePath);//create the folder of the name we chose 
            string createTxt = $@"{extendFilePath}\{subfolder}.txt";// EXTEND THE PATH AND ADD TXT FILE
            File.WriteAllText(createTxt, message);//CREATE TXT FILE AND WRITE THE MESSAGE 
            extendFilePath = Path.Combine(extendFilePath, createTxt);//CREATE PATH AND ADD THE TXT FILE IN FOLDER WITH NAME OF THE FOLDER
            //System.IO.Directory.Delete(extendFilePath);

            return extendFilePath;
        }

        //TOOK THE EXISTING PATH FROM CREATE FILE METHOD WHICH RETURN  THE PATH AND ADD THIS PATH IN THIS METHOD TO APPENT THE TEXT
        public static void AppendMessage(string message, string path)
        {
            StreamWriter appendwrite = new StreamWriter(path, true);
            using (appendwrite)
            {
                try
                {
                    appendwrite.WriteLine("\n");
                    appendwrite.Write(message);
                    var now = DateTime.Now;
                    Console.WriteLine(now);
                }
                catch (EndOfStreamException x)
                {
                    Console.WriteLine(x.Message);
                }
            }

        }
    }
}
