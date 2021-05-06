using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTypeSelectorUI : MonoBehaviour
{
    [SerializeField] List<TileTypeSelectionUI> seliectionButtons;

    public void ChangeSelection(TileTypeSelectionUI selected)
    {
        foreach (var item in seliectionButtons)
        {
            if (item != selected)
            {
                item.selectedImage.color = new Color32(255, 255, 255, 0);
            }
            else
            {
                item.selectedImage.color = new Color32(255, 255, 255, 120);
            }
        }
        MapCreatorUI.instance.SetTileType(selected.tileType);
    }
}
