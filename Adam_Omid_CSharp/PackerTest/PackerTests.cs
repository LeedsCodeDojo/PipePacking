using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiedPiper;

namespace PackerTest
{
    [TestClass]
    public class PackerTests
    {
        [TestMethod]
        public void SmokeTest()
        {
            var bins = new Packer(10).Pack(new List<int>() {10});

            Assert.AreEqual(1,bins.Count);
            Assert.AreEqual(1,bins[0].pipes.Count);
            Assert.AreEqual(10, bins[0].pipes[0]);
        }

        [TestMethod]
        public void TwoPipesReturnOneBin()
        {
            var bins = new Packer(10).Pack(new List<int>() { 5, 5 });

            Assert.AreEqual(1, bins.Count);
            Assert.AreEqual(2, bins[0].pipes.Count);
            Assert.AreEqual(5, bins[0].pipes[0]);
            Assert.AreEqual(5, bins[0].pipes[1]);
        }

        [TestMethod]
        public void TwoPipesReturnTwoBin()
        {
            var bins = new Packer(5).Pack(new List<int> { 5, 5 });

            Assert.AreEqual(2, bins.Count);
            
            Assert.AreEqual(1, bins[0].pipes.Count);
            Assert.AreEqual(5, bins[0].pipes[0]);

            Assert.AreEqual(1, bins[1].pipes.Count);
            Assert.AreEqual(5, bins[1].pipes[0]);
        }

        [TestMethod]
        public void ThePizzaTest()
        {
            RunExample(13, new List<int> { 1, 1, 3, 4, 4, 5, 6, 6, 6, 8, 8, 8, 9, 9 });
        }

        private void RunExample(int binSize, List<int> pipes)
        {
            Console.WriteLine("BinSize: " + binSize);
            
            Console.WriteLine(String.Join(",", pipes));
            Console.WriteLine("Total Pipes Size: " + pipes.Sum(p => p));
            Console.WriteLine("Min Bins : " + pipes.Sum(p => p) / 13M);
            Console.WriteLine("TotalPipesSize mod 13: " + pipes.Sum(p => p) % 13);

            Console.WriteLine("**Cool sorting");
            var bins = new Packer(binSize).Pack(pipes);
            Console.WriteLine("Bins: " + bins.Count);
            foreach (var bin in bins)
            {
                Console.WriteLine(String.Join(",", bin.pipes));
            }

            Console.WriteLine("**Desc sorting");
            bins = new Packer(binSize).Pack(pipes, false);
            Console.WriteLine("Bins: " + bins.Count);
            foreach (var bin in bins)
            {
                Console.WriteLine(String.Join(",", bin.pipes));
            }
        }

        [TestMethod]
        public void FitFirstChallenge()
        {
            RunExample(10, new List<int> { 2, 2, 3, 4, 4, 5 });
        }
    }
}
