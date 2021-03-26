using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActionTemplateUI : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject actionPrefab;

    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject go = Instantiate(actionPrefab);
        RectTransform rectTransform = go.GetComponent<RectTransform>();
        rectTransform.SetParent(GetComponent<RectTransform>().parent.parent);
        rectTransform.position = eventData.position;
        go.GetComponent<Dragable>().canvas = canvas;
    }
}
