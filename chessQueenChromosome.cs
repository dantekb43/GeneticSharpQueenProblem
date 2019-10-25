using GeneticSharp.Domain.Chromosomes;
using System;

namespace chessQueenProblem
{
    class chessQueenChromosome : ChromosomeBase
    {
        // TODO: Change the argument value passed to base construtor to change the length 
        // of your chromosome.
        public chessQueenChromosome() 
            : base(8)
        {
            CreateGenes();
        }

        public override Gene GenerateGene(int geneIndex)
        {
            Random random = new Random();
            return new Gene(random.Next(1, 9));
            //throw new NotImplementedException("// TODO: Generate a gene base on MyProblemChromosome representation.");
        }

        public override IChromosome CreateNew()
        {
            return new chessQueenChromosome();
        }
    }
}
