using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFiveMap : Map
{
    public override int[,] getMap()
    {
        int[,] map = new int[11, 11]
        {
            {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
            {2, 0, 3, 1, 1, 1, 3, 1, 1, 1, 2},
            {2, 1, 3, 1, 3, 1, 3, 1, 3, 1, 2},
            {2, 1, 3, 1, 3, 1, 3, 1, 3, 1, 2},
            {2, 1, 3, 1, 3, 1, 3, 1, 3, 1, 2},
            {2, 1, 3, 1, 3, 1, 3, 1, 3, 1, 2},
            {2, 1, 3, 1, 3, 1, 3, 1, 3, 1, 2},
            {2, 1, 3, 1, 3, 1, 3, 1, 3, 1, 2},
            {2, 1, 3, 1, 3, 1, 3, 1, 3, 1, 2},
            {2, 1, 1, 1, 3, 1, 1, 1, 3, 1, 2},
            {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
        };
        return map;
    }
}