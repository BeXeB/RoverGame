using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapCreatorUI : MonoBehaviour
{
    public static MapCreatorUI instance;
    private void Awake()
    {
        instance = this;
    }
    [SerializeField] Map map;
    [SerializeField] GameObject infoUI;
    [SerializeField] GameObject settingsUI;
    [SerializeField] GameObject sizeUI;
    [SerializeField] Sprite voidIcon;
    [SerializeField] Sprite startIcon;
    [SerializeField] Sprite pathIcon;
    [SerializeField] Sprite hillIcon;
    [SerializeField] Sprite holeIcon;
    [SerializeField] Sprite finishIcon;
    [SerializeField] GameObject tilesParent;
    [SerializeField] GameObject tileUIPrefab;
    [SerializeField] TMP_InputField xInput;
    [SerializeField] TMP_InputField zInput;
    public int maxActions;
    public int roverRot;
    public int alienRot;
    private TileType selectedTileType;
    private MapCreatorTileUI[,] mapTiles;

    public void OnCreateButton()
    {
        int result;
        int x = int.TryParse(xInput.text, out result) ? result : 16;
        int z = int.TryParse(zInput.text, out result) ? result : 16;
        mapTiles = new MapCreatorTileUI[z, x];
        tilesParent.GetComponent<GridLayoutGroup>().constraintCount = z;
        InitializeTiles();
        sizeUI.SetActive(false);
    }

    private void InitializeTiles()
    {
        for (int i = 0; i < mapTiles.GetLength(1); i++)
        {
            for (int j = 0; j < mapTiles.GetLength(0); j++)
            {
                GameObject gameObject = Instantiate(parent: tilesParent.transform, original: tileUIPrefab);
                mapTiles[j, i] = gameObject.GetComponent<MapCreatorTileUI>();
                mapTiles[j, i].x = j;
                mapTiles[j, i].z = i;
            }
        }
    }

    private Sprite GetSelectedSprite()
    {
        switch (selectedTileType)
        {
            case TileType.StartTile:
                return startIcon;
            case TileType.PathTile:
                return pathIcon;
            case TileType.HillTile:
                return hillIcon;
            case TileType.HoleTile:
                return holeIcon;
            case TileType.FinishTile:
                return finishIcon;
            default:
                return voidIcon;
        }
    }

    public void SetTile(int x, int z)
    {
        //check if tile is start so only one can be placed
        mapTiles[x, z].icon.sprite = GetSelectedSprite();
        mapTiles[x, z].tileType = selectedTileType;
    }

    public void SetTileType(TileType type)
    {
        selectedTileType = type;
    }

    public void ResetMap()
    {
        for (int i = 0; i < mapTiles.GetLength(1); i++)
        {
            for (int j = 0; j < mapTiles.GetLength(0); j++)
            {
                mapTiles[j, i].icon.sprite = voidIcon;
                mapTiles[j, i].tileType = TileType.Void;
            }
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void Info()
    {
        infoUI.SetActive(true);
    }

    public void DisableInfo()
    {
        infoUI.SetActive(false);
    }

    public void Play()
    {
        string mapStr = "";
        map.testing = true;
        for (int i = 0; i < mapTiles.GetLength(1); i++)
        {
            for (int j = 0; j < mapTiles.GetLength(0); j++)
            {
                mapStr +=  (int)mapTiles[j, i].tileType;
                mapStr += "|";
            }
            mapStr = mapStr.Remove(mapStr.Length - 1);
            mapStr += "\n";
        }
        mapStr = mapStr.Remove(mapStr.Length - 1);
        map.x = mapTiles.GetLength(1);
        map.z = mapTiles.GetLength(0);
        map.mapString = mapStr;
        map.maxActions = maxActions;
        map.roverRotation = roverRot;
        map.alienRotation = alienRot;
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        settingsUI.SetActive(true);
    }
}
