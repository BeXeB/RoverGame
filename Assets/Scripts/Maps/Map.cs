using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Map : MonoBehaviour
{
    
    //1 = path prefab
    //2 = hill prefab
    //3 = hole prefab
    public abstract int[,] getMap();
}
