using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiedPiper
{
    public class Packer
    {
        private readonly int _binSize;

        public class Bin
        {
            public List<int> pipes = new List<int>();

            public int CurrentSize()
            {
                return pipes.Sum(p => p);
            }
        }

        public List<Bin> bines = new List<Bin>();

        public Packer(int binSize )
        {
            _binSize = binSize;
        }

        public List<Bin> Pack(List<int> pipes, bool coolSorting = true)
        {
            pipes = pipes.OrderByDescending(p  => p).ToList();

            #region Complex
            List<int> orderedPipes = new List<int>();

            int minPipe = pipes.Min(p => p);
            int pipeIndex = 0;
            bool newLap = true;
            if (coolSorting)
            {
                while (pipes.Any())
                {
                    if (newLap || orderedPipes.Sum(p => p) + pipes[pipeIndex] == _binSize || orderedPipes.Sum(p => p) + pipes[pipeIndex] + minPipe <= _binSize)
                    {
                        newLap = false;
                        orderedPipes.Add(pipes[pipeIndex]);
                        pipes.RemoveAt(pipeIndex);
                    }
                    else
                    {
                        newLap = false;
                        pipeIndex++;
                        if (pipeIndex >= pipes.Count)
                        {
                            newLap = true;
                            pipeIndex = 0;
                        }
                    }
                }
            }

            #endregion

            foreach (var pipe in coolSorting ? orderedPipes : pipes)
            {
                if (!Fit(pipe)) return null;
            }
            return bines;
        }

        private bool Fit(int pipe)
        {
            if (pipe > _binSize) return false;
            foreach (Bin bin in bines)
            {
                if (bin.CurrentSize() + pipe <= _binSize)
                {
                    bin.pipes.Add(pipe);
                    return true;
                }
            }

            bines.Add(new Bin() {pipes = new List<int>{pipe}});
            return true;
        }
    }
}
