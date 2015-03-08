using System;
using System.IO;

namespace MarkovDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"C:\Users\shibayan\Documents\mecab\statemachine_data.txt");

            var markovDic = new MarkovDictionary();

            foreach (var line in lines)
            {
                markovDic.AddSentence(line.Split('|'));
            }

            for (int i = 0; i < 100; i++)
            {
                var sentence = markovDic.BuildSentence();

                Console.WriteLine(string.Join("", sentence));
            }
        }
    }
}
