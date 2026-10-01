using System;
using System.Collections.Generic;
using System.Text;

// Based on Daniel Shiffman, Nature of Code
// http://natureofcode.com
namespace MugenSaru
{
    class Program
    {
        static void Main()
        {
            // Mutation rate
            float mutationRate = 0.01f;
            // Population size
            int populationSize = 150;
            // Target phrase
            string target = "to be or not to be";
            char[] targetGenes = target.ToCharArray();

            // Step 1: Initialize an empty population and fill it with random DNA.
            DNA[] population = new DNA[populationSize];
            for (int i = 0; i < populationSize; i++)
            {
                population[i] = new DNA(target.Length);
            }

            int generation = 0;
            while (true)
            {
                generation++;

                // Step 2a: Calculate fitness.
                DNA best = population[0];
                for (int i = 0; i < population.Length; i++)
                {
                    population[i].calculateFitness(targetGenes);
                    if (population[i].fitness > best.fitness)
                    {
                        best = population[i];
                    }
                }

                Console.WriteLine(
                    $"Generation {generation}  fitness {best.fitness:0.00}  {new string(best.genes)}");

                if (best.fitness == 1f)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"Target reached in {generation} generations.");
                    break;
                }

                // Step 2b: Build the mating pool.
                // Add each member n times according to its fitness score.
                List<DNA> matingPool = new List<DNA>();
                for (int i = 0; i < population.Length; i++)
                {
                    int n = (int)Math.Floor(population[i].fitness * 100);
                    for (int j = 0; j < n; j++)
                    {
                        matingPool.Add(population[i]);
                    }
                }

                // If nobody matched any character yet, pick parents from the whole population.
                if (matingPool.Count == 0)
                {
                    matingPool.AddRange(population);
                }

                // Step 3: Reproduction. Replace the population with children.
                DNA[] nextGeneration = new DNA[population.Length];
                for (int i = 0; i < population.Length; i++)
                {
                    DNA partnerA = matingPool[Random.Shared.Next(matingPool.Count)];
                    DNA partnerB = matingPool[Random.Shared.Next(matingPool.Count)];
                    // Step 3a: Crossover
                    DNA child = partnerA.crossover(partnerB);
                    // Step 3b: Mutation
                    child.mutate(mutationRate);
                    nextGeneration[i] = child;
                }

                population = nextGeneration;
            }
        }
    }
}
