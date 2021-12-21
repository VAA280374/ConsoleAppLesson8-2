using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleAppLesson8_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "__log.txt";
            string _result;
            int sum = 0;
            
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл {0} создан заново", path);
                FileStream fs = File.Create(path);
                fs.Close();
            }
            using (StreamWriter sw = new StreamWriter(path, false))
            { 
                sw.Write(" "); // очистка файла
                 
            }
            using (StreamWriter sww = new StreamWriter(path, true))
            {
                Random random = new Random();
                int r = random.Next(-50, 50);
                for (int i = 0; i < 10; i++)
                {
                    sww.Write(" {0} ", random.Next(-50, 50));
                }
            }

            StreamReader sr = new StreamReader(path);
            _result = sr.ReadToEnd();
            sr.Close();

            string[] _resultArray = _result.Split();
            foreach (string line in _resultArray)
            {
                // sum += Convert.ToInt32(line);
                Console.WriteLine(line);
                //Console.WriteLine(line.TrimEnd);

            }


            Console.WriteLine(_result);
            Console.ReadKey();
        }
    }
}
