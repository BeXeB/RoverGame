using UnityEngine;
using UnityEngine.EventSystems;

public class ActionSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] int slotIndex;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            GameObject go = eventData.pointerDrag;
            go.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            go.GetComponent<ActionUI>().inSlot = true;
            go.GetComponent<ActionUI>().slotIndex = slotIndex;
            ActionManager.instance.AddAction(go.GetComponent<ActionUI>().action, slotIndex);
        }
    }
}
