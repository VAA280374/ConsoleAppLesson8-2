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
                File.Create(path);  
            }
            using (StreamWriter sw = new StreamWriter(path, false))
            { 
                sw.Write(" "); // очистка файла
                 
            }
            using (StreamWriter sww = new StreamWriter(path, true))
            {
                Random random = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int r = random.Next(-50, 50);
                    sww.Write(" {0} ", r);
                }
            }

            StreamReader sr = new StreamReader(path);
            _result = sr.ReadToEnd();
            sr.Close();

            Console.Write("Сгенерирована последовательность : {0}", _result);
            _result = _result.Trim(); // Убираем началиный и конечный пробелы, похоже они пееносятся в _rezultArrey

            string[] _resultArray = _result.Split(); // ПРО..СЯ!!! При наличии двух пробелов подряд на втором пробеле генерируется "Пустая" строка.
            foreach (string line in _resultArray)
            {
                if (line == "") continue;  // ВАЖНО!!! Убираем пустые строки - см. Коммент к Split
                // Console.Write(line);
                sum += Convert.ToInt32(line);
            }
            Console.WriteLine();
            Console.WriteLine("Сумма чисел равна : {0}", sum);

            Console.ReadKey();
        }
    }
}
