using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFourMap : Map
{
    public override int[,] getMap()
    {
        int[,] map = new int[11, 5]
        {
            {2, 2, 2, 2, 2},
            {2, 0, 3, 4, 2},
            {2, 1, 2, 1, 2},
            {2, 1, 2, 1, 2},
            {2, 1, 2, 1, 2},
            {2, 1, 2, 1, 2},
            {2, 1, 2, 1, 2},
            {2, 1, 2, 1, 2},
            {2, 1, 2, 1, 2},
            {2, 1, 1, 1, 2},
            {2, 2, 2, 2, 2},
        };
        return map;
    }
}