using GeneticSharp.Domain;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
using System;

namespace chessQueenProblem
{
    class Program
    {
        /// <summary>
        /// GeneticSharp Console Application template.
        /// <see href="https://github.com/giacomelli/GeneticSharp"/>
        /// </summary>
        static void Main(string[] args)
        {
            // TODO: use the best genetic algorithm operators to your optimization problem.
            var selection = new EliteSelection();
            var crossover = new UniformCrossover();
            var mutation = new UniformMutation(true);

            var fitness = new chessQueenFitness();
            var chromosome = new chessQueenChromosome();

            var population = new Population(5000, 7000, chromosome);

            var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);

            //ga.Termination = new FitnessStagnationTermination(4);
            ga.Termination = new FitnessThresholdTermination(0);

            ga.GenerationRan += (s, e) => Console.WriteLine($"Generation {ga.GenerationsNumber}. Best fitness: {ga.BestChromosome.Fitness.Value}");
            ga.GenerationRan += (s, e) => Console.WriteLine($"Chromosome Sample 1:" + String.Join("", ga.Population.CurrentGeneration.Chromosomes[0].GetGenes()));
            ga.GenerationRan += (s, e) => Console.WriteLine($"Chromosome Sample 2:" + String.Join("", ga.Population.CurrentGeneration.Chromosomes[1].GetGenes()));
            ga.GenerationRan += (s, e) => Console.WriteLine($"Chromosome Sample 3:" + String.Join("", ga.Population.CurrentGeneration.Chromosomes[2].GetGenes()));
            ga.GenerationRan += (s, e) => Console.WriteLine($"Chromosome Sample 4:" + String.Join("", ga.Population.CurrentGeneration.Chromosomes[3].GetGenes()));
            ga.GenerationRan += (s, e) => Console.WriteLine($"Chromosome Sample 5:" + String.Join("", ga.Population.CurrentGeneration.Chromosomes[4].GetGenes()));
            ga.GenerationRan += (s, e) => Console.WriteLine($"Best Chromosome: " + String.Join("", ga.Population.CurrentGeneration.BestChromosome.GetGenes()));
            

            Console.WriteLine("GA running...");
            ga.Start();

            Console.WriteLine();
            Console.WriteLine($"Best solution found has fitness: {ga.BestChromosome.Fitness}");
            Console.WriteLine($"Elapsed time: {ga.TimeEvolving}");
            //Console.ReadKey();
        }
    }
}
