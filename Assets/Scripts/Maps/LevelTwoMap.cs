using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoMap : Map
{
    public override int[,] getMap()
    {
        int[,] map = new int[11,3]
        {
            {2, 2, 2},
            {2, 0, 2},
            {2, 1, 2},
            {2, 1, 2},
            {2, 1, 2},
            {2, 1, 2},
            {2, 1, 2},
            {2, 1, 2},
            {2, 1, 2},
            {2, 4, 2},
            {2, 2, 2},
        };
        return map;
    }
}
