using UnityEngine;

public class InfoUI : MonoBehaviour
{
    [SerializeField] GameObject infoUI;

    public void EnableUI()
    {
        infoUI.SetActive(true);
    }

    public void DisableUI()
    {
        infoUI.SetActive(false);
    }
}
