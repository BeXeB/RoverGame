using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUI : MonoBehaviour
{
    [SerializeField] int maxActions;
    [TextArea(3,15)][SerializeField] string mapString;

    public void OnMapSelected()
    {
        Map map = MapSelection.instance.map;
        map.mapString = mapString;
        map.maxActions = maxActions;
        string[] rows = mapString.Split('/');
        int x = rows.Length;
        string[] tile = rows[0].Split(',');
        int z = tile.Length;
        map.x = x;
        map.z = z;
        MapSelection.instance.StartMap();
    }
}
