using UnityEngine;

[CreateAssetMenu(fileName = "New Map")]
public class Map : ScriptableObject
{

    //1 = finish prefab
    //2 = path prefab
    //3 = hill prefab
    //4 = hole prefab
    //5 = alien prefab

    public int maxActions;
    public int roverRotation;
    public int alienRotation;
    public int x, z;
    public string mapString;
    private int[,] map;
    private void GetMapFromString()
    {
        roverRotation %= 4;
        alienRotation %= 4;
        map = new int[x, z];
        string[] rows = mapString.Split('\n');
        for (int i = 0; i < rows.Length; i++)
        {
            string[] tiles = rows[i].Split('|');
            for (int j = 0; j < tiles.Length; j++)
            {
                map[i, j] = int.TryParse(tiles[j], out int result) ? result : -1;
            }
        }
    }

    public int[,] GetMap()
    {

        GetMapFromString();
        return map;
    }

    public int GetMaxActions()
    {
        return maxActions;
    }
}

public enum TileType { StartTile, FinishTile, PathTile, HillTile, HoleTile }
