using UnityEngine;
using UnityEngine.UI;

public class MapCreatorTileUI : MonoBehaviour
{

    public int x;
    public int z;
    public Image icon;
    public TileType tileType;

    public void OnButtonClicked()
    {
        MapCreatorUI.instance.SetTile(x, z);
    }
}
