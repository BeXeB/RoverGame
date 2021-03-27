using UnityEngine;

public class ActionListButton : MonoBehaviour
{
    [SerializeField] Transform listTransform;

    public void Toggle()
    {
        listTransform.gameObject.SetActive(!listTransform.gameObject.activeSelf);
    }
}
