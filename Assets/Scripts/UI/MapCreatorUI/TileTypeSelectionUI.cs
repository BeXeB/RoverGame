using UnityEngine;
using UnityEngine.UI;

public class TileTypeSelectionUI : MonoBehaviour
{
    public Image selectedImage;
    public TileType tileType;
    private TileTypeSelectorUI selectorUI;

    private void Awake()
    {
        selectorUI = GetComponentInParent<TileTypeSelectorUI>();
    }

    public void OnButtonPressed()
    {
        selectorUI.ChangeSelection(this);
    }
}
