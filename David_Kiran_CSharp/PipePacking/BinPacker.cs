using System.Collections.Generic;
using System.Linq;

namespace PipePacking
{
    public class BinPacker
    {
        public List<List<int>> Pack(int binSize, List<int> pipeList)
        {
            var result = new List<List<int>>();

            foreach (var pipelength in pipeList.OrderByDescending(pipe => pipe))
            {
                var boxToAdd = (from list in result
                                let sum = list.Sum() + pipelength
                                orderby sum descending 
                                        where sum <= binSize
                                select list).FirstOrDefault();

                if (boxToAdd != null)
                {
                    boxToAdd.Add(pipelength);
                }
                else
                {
                    result.Add(new List<int> { pipelength });
                }
            }

            return result;
        }

        //public List<List<int>> Pack(int binSize, List<int> pipeList)
        //{
        //    var result = new List<List<int>>();

        //    foreach (var pipelength in pipeList.OrderByDescending(pipe => pipe))
        //    {
        //        var boxToAdd = (from list in result
        //                        let sum = list.Sum() + pipelength
        //                        orderby sum descending 
        //                                where sum <= binSize
        //                        select list).FirstOrDefault();

        //        if (boxToAdd != null)
        //        {
        //            boxToAdd.Add(pipelength);
        //        }
        //        else
        //        {
        //            result.Add(new List<int> { pipelength });
        //        }
        //    }

        //    return result;
        //}

        //public List<List<int>> Pack(int binSize, List<int> pipeList)
        //{

        //    var result = new List<List<int>>();

        //    foreach (var pipelength in pipeList.OrderByDescending(pipe => pipe))
        //    {
        //        var allPossibleBoxes = result.FindAll(x => x.Sum() + pipelength <= binSize);
        //        if (allPossibleBoxes.Any())
        //        {
        //            var maxValue = allPossibleBoxes.Max(a => a.Sum());
        //            var boxToAdd = allPossibleBoxes.First(x => x.Sum() == maxValue);
        //            boxToAdd.Add(pipelength);
        //        }
        //        else
        //        {
        //            result.Add(new List<int> { pipelength });
        //        }
        //    }

        //    return result;
        //}


        //public List<List<int>> Pack(int binSize, List<int> pipeList)
        //{
        //    var result = new List<List<int>>();

        //    foreach (var pipelength in pipeList)
        //    {
        //        var matchingList = result.FirstOrDefault(x => x.Sum() + pipelength <= binSize);

        //        if (matchingList != null)
        //        {
        //            matchingList.Add(pipelength);
        //        }
        //        else
        //        {
        //            result.Add(new List<int> { pipelength });
        //        }
        //    }

        //    return result;
        //}

        //public List<List<int>> Pack(int binSize, List<int> pipeList)
        //{
        //    var result = new List<List<int>>();

        //    List<int> currentList = new List<int>();
        //    foreach (var pipelength in pipeList)
        //    {
        //        if (currentList.Sum() + pipelength <= binSize)
        //        {
        //            var matchingList = result.FirstOrDefault(x => x.Sum() + pipelength <= binSize);

        //            if (matchingList != null)
        //            {
        //                matchingList.Add(pipelength);
        //                continue;
        //            }

        //            currentList.Add(pipelength);
        //        }
        //        else
        //        {
        //            result.Add(currentList);
        //            currentList = new List<int> { pipelength };
        //        }
        //    }

        //    if (currentList.Count > 0)
        //    {
        //        result.Add(currentList);
        //    }

        //    return result;
        //}
    }
}