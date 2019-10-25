using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace chessQueenProblem
{
    class chessQueenFitness : IFitness
    {
        public double Evaluate(IChromosome chromosome)
        {
            chromosome.Fitness = calculateAttacks(chromosome);
            return (double)chromosome.Fitness;
            //throw new NotImplementedException("// TODO: Evaluate the fitness of the chromosome.");
        }

        private int calculateAttacks(IChromosome chromosome)
        {
            int collisions = 0;
            List<Gene> genePositions = chromosome.GetGenes().ToList();
            List<int> positions = new List<int>();

            foreach (Gene g in genePositions)
                positions.Add(Convert.ToInt32(g.Value));

            for (int refQueen = 0; refQueen < positions.Count; refQueen++)
                for (int targQueen = refQueen + 1; targQueen < positions.Count; targQueen++)
                {
                    if (positions[refQueen] == positions[targQueen])
                        collisions++;
                    else if ((positions[refQueen] - (targQueen - refQueen)) == positions[targQueen])
                        collisions++;
                    else if ((positions[refQueen] + (targQueen - refQueen)) == positions[targQueen])
                        collisions++;
                }
            
            //  if (collisions == 0)
            //     Console.WriteLine(String.Join("",positions));

            return collisions * -1;
        }
    }
}
