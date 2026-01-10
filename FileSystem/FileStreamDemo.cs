using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace FileSystem
{
    internal class FileStreamDemo
    {
        FileStream fs = null;
        public void CreateFile(string fileName)
        {
            StreamWriter sw = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.WriteLine("This is sample file");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(FileLoadException ex) 
            {
                    Console.WriteLine(ex.Message);

            }
            finally
            {
                sw.Close();
                fs.Close(); 
            }
            

        }

        public void ReadFile(string fileName)
        {
          StreamReader sr = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
                string content = sr.ReadToEnd();
                Console.WriteLine(content);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileLoadException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sr.Close();
                fs.Close();
            }   
        }
    }
}
