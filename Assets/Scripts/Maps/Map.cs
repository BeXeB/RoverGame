using UnityEngine;

public abstract class Map : MonoBehaviour
{
    
    //1 = path prefab
    //2 = hill prefab
    //3 = hole prefab
    //4 = alien prefab
    public abstract int[,] getMap();
}
