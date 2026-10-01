using System;
using System.Reflection.Metadata.Ecma335;

namespace MugenSaru
{
    class DNA
    {
        public char[] genes;
        public float fitness;
        public DNA(int length)
        {
            this.genes = new char[length];
            this.fitness = 0.0f;
            for (int i = 0; i < length; i++)
            {
                this.genes[i] = randomCharacter();
            }
        }
        public static char randomCharacter()
        {
            int c = Random.Shared.Next(32, 127);
            return (char)c;
        }
    }
}