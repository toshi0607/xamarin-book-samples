using System;

namespace Lesson1
{
    class MainClass
    {
        private enum DayOfWeek { Sun, Mon, Tue, Wed, Thu, Fri, Sat }

        public static void Main(string[] args)
        {
            DayOfWeek mon = DayOfWeek.Mon;
            if(mon == DayOfWeek.Mon)
            {
                Console.WriteLine("月曜日です");
            }
        }
    }
}
