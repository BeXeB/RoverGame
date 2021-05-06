using UnityEngine;

[CreateAssetMenu(fileName = "New Map")]
public class Map : ScriptableObject
{
    //0 = void
    //1 = start
    //2 = finish prefab
    //3 = path prefab
    //4 = hill prefab
    //5 = hole prefab

    public int maxActions;
    public int roverRotation;
    public int alienRotation;
    public bool testing;
    public int x, z;
    [TextArea(3,15)]public string mapString;
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
                map[i, j] = int.TryParse(tiles[j], out int result) ? (result) : 0;
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

public enum TileType {Void ,StartTile, FinishTile, PathTile, HillTile, HoleTile }
