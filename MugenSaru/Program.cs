using System;
// Based on sample by Daniel Shiffman, Nature of Code.
// I want to try to rewrite 09_ga as C#
namespace MugenSaru
{
    class Program()
    {
        public static string targetSentence = "To be or not to be.";
        static void Main()
        {
            int populationSize = 100;
            float mutationRate = 0.01f;
            int maxGenerations = 1000;

            string bestPhrase;
            string[] allPhrases = new string[populationSize];

            Console.WriteLine("Hello World");
            Console.WriteLine("Test Char"); 
            Console.WriteLine(DNA.randomCharacter());
        }

    }


}

