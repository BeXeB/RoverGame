using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBlockMap : Map
{
    public override int[,] getMap()
    {
        int[,] map = new int[1,10]
        {
            {0, 1, 1, 1, 1, 1, 1, 1, 1, 3},
        };
        return map;
    }
}
