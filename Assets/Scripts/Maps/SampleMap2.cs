using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleMap2 : Map
{
    public override int[,] getMap()
    {
        int[,] map = new int[10,10]
        {
            {2, 1, 1, 1, 1, 1, 1, 1, 1, 3},
            {2, 1, 1, 1, 1, 1, 1, 1, 1, 3},
            {2, 1, 1, 1, 3, 1, 1, 1, 1, 3},
            {2, 1, 1, 1, 3, 1, 1, 1, 1, 3},
            {2, 1, 1, 1, 3, 1, 1, 1, 1, 3},
            {2, 1, 1, 1, 3, 1, 1, 1, 1, 3},
            {2, 1, 1, 1, 1, 1, 1, 1, 1, 3},
            {2, 1, 1, 1, 1, 1, 1, 1, 1, 3},
            {2, 1, 1, 1, 1, 1, 1, 1, 1, 3},
            {2, 2, 2, 2, 2, 2, 2, 2, 2, 3},
        };
        return map;
    }
}