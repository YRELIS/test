/*using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class Class1
{
    public static void Main()
    {
        FileStream file1 = new FileStream(@"d:\\test.txt", FileMode.Open); //создаем файловый поток
        StreamReader reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком 
        Console.WriteLine(reader.ReadToEnd()); //считываем все данные с потока и выводим на экран
        string inp = reader.ReadToEnd();
        
        string dateString = DateTime.Today.ToString("d", DateTimeFormatInfo.InvariantInfo);
        string resultString = MDYToDMY(inp);
        Console.WriteLine("Converted {0} to {1}.", inp, resultString);
        reader.Close(); //закрываем поток
    }

    static string MDYToDMY(string input)
    {
        try
        {
            return Regex.Replace(input,
                  "\\b(?<month>\\d{1,2})/(?<day>\\d{1,2})/(?<year>\\d{2,4})\\b",
                  "${day}.${month}.${year}", RegexOptions.None,
                  TimeSpan.FromMilliseconds(150));
            FileStream file2 = new FileStream(@"d:\\test2.txt", FileMode.Create); //создаем файловый поток
            StreamWriter writer = new StreamWriter(file2); //создаем «потоковый писатель» и связываем его с файловым потоком 
            writer.Write(input); //записываем в файл
            writer.Close(); //закрываем поток. Не закрыв поток, в файл ничего не запишется 
        }
        catch (RegexMatchTimeoutException)
        {
            return input;
        }
    }

}*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;


namespace kkr2
{

    class Read_File
    {
        public string txt = "";
        public Read_File()
        {
            FileStream file = new FileStream("D:\\readText.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file, Encoding.Default);
            txt = reader.ReadToEnd();
            reader.Close();
            Console.WriteLine("Текст прочитан с файла D:\\readText.txt");
        }
    }
    class RegexTextOut : Read_File
    {
        public string regex = @"(0[1-9]|[12][0-9]|3[01])[.](0[1-9]|1[012])[.](19|20)\d\d";
        public RegexTextOut()
        {
            Console.WriteLine("Вывод найденых дат и запись в файл D:\\outText.txt");
            StreamWriter output = new StreamWriter("D:\\outText.txt", false, Encoding.Default);
            Match match = Regex.Match(this.txt, regex);
            while (match.Success)
            {
                Console.WriteLine(match.Value);
                output.WriteLine(match.Value);
                match = match.NextMatch();
            }
            output.Close();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            RegexTextOut regexTextOut = new RegexTextOut();
        }
    }
}