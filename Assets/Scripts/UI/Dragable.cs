using UnityEngine;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public Canvas canvas;
    RectTransform rectTransform;
    CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;
        GameObject go = eventData.pointerDrag;
        ActionUI actionUI = go.GetComponent<ActionUI>();
        if (actionUI.inSlot)
        {
            ActionManager.instance.RemoveAction(actionUI.action, actionUI.slotIndex);
            go.GetComponent<ActionUI>().inSlot = false;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}
