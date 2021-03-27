using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            GameObject go = eventData.pointerDrag;
            go.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            go.GetComponent<ActionUI>().inSlot = true;
            ActionManager.instance.AddAction(go.GetComponent<ActionUI>().action);
        }
    }
}
