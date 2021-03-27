using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    [SerializeField] Transform listTransform;

    public void Toggle()
    {
        listTransform.gameObject.SetActive(!listTransform.gameObject.activeSelf);
    }
}
