using System;

namespace Lesson1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("氏名を入力してください");

            string strName = Console.ReadLine();
            Console.WriteLine($"こんにちは{strName}さん"); 
        }
    }
}
