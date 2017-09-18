using System;
using System.Collections.Generic;

namespace Lesson1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> myDict = new Dictionary<string, string>();

            myDict.Add("0001", "高橋");
            myDict.Add("0002", "佐々木");
            myDict.Add("0003", "鈴木");
            myDict.Add("0004", "前田");

            foreach(string key in myDict.Keys)
            {
                Console.WriteLine(key);
            }

            foreach(string val in myDict.Values)
            {
                Console.WriteLine(val);
            }

            foreach(KeyValuePair<string, string> kvp in myDict)
            {
                Console.WriteLine($"Key={kvp.Key}, Value={kvp.Value}");
            }
        }
    }
}
