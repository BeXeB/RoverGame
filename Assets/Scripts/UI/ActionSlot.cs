using UnityEngine;
using UnityEngine.EventSystems;

public class ActionSlot : MonoBehaviour, IDropHandler
{
    public int slotIndex;
    bool used;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && !used)
        {
            used = true;
            GameObject go = eventData.pointerDrag;
            go.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            go.GetComponent<RectTransform>().SetParent(GetComponent<RectTransform>());
            go.GetComponent<ActionUI>().inSlot = true;
            go.GetComponent<ActionUI>().slotIndex = slotIndex;
            //ActionManager.instance.AddAction(go.GetComponent<ActionUI>().action, slotIndex);
            SlotManager.instance.AddSlot();
        }
    }
}
