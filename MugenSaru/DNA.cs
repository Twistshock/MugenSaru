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

        public void calculateFitness(char[] target)
        {
            int score = 0;
            for (int i = 0; i < this.genes.Length; i++)
            {
                if (this.genes[i] == target[i])
                {
                    score++;
                }
            }
            this.fitness = (float)score / target.Length;
        }

        public DNA crossover(DNA partner)
        {
            DNA child = new DNA(this.genes.Length);
            int midpoint = Random.Shared.Next(this.genes.Length);
            for (int i = 0; i < this.genes.Length; i++)
            {
                if (i > midpoint)
                {
                    child.genes[i] = this.genes[i];
                }
                else
                {
                    child.genes[i] = partner.genes[i];
                }
            }
            return child;
        }

        public void mutate(float mutationRate)
        {
            for (int i = 0; i < this.genes.Length; i++)
            {
                if (Random.Shared.NextDouble() < mutationRate)
                {
                    this.genes[i] = randomCharacter();
                }
            }
        }
    }
}