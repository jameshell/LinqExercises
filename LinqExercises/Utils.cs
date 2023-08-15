using System;
using System.Collections.Generic;
namespace LinqExercises;

public class Utils
{
    public void DisplayItems<T>(IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
    }
}