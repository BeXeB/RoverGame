using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapUI : MonoBehaviour
{
    [SerializeField] int maxActions;
    [SerializeField] int roverRotation;
    [SerializeField] int alienRotation;
    [SerializeField] string levelNo;
    [SerializeField] TMP_Text text;
    [TextArea(3, 15)] [SerializeField] string mapString;

    private void Start()
    {
        text.text = "Level\n" + levelNo;
    }

    public void OnMapSelected()
    {
        Map map = MapSelection.instance.map;
        map.alienRotation = alienRotation;
        map.roverRotation = roverRotation;
        map.mapString = mapString;
        map.maxActions = maxActions;
        string[] rows = mapString.Split('\n');
        int x = rows.Length;
        string[] tile = rows[0].Split('|');
        int z = tile.Length;
        map.x = x;
        map.z = z;
        map.testing = false;
        MapSelection.instance.StartMap();
    }
}
