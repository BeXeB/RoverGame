using UnityEngine;
using UnityEngine.EventSystems;

public class ForSlot : MonoBehaviour
{
    public int slotIndex;
    bool used;
    ActionUI actionUI;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject go = eventData.pointerDrag;
        if (go != null)
        {
            if (!used)
            {
                used = true;
                go.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                go.GetComponent<RectTransform>().SetParent(GetComponent<RectTransform>());
                actionUI = go.GetComponent<ActionUI>();
                actionUI.inSlot = true;
                actionUI.slotIndex = slotIndex;
                //ActionManager.instance.AddAction(go.GetComponent<ActionUI>().action, slotIndex);
                ((ForActionUI)actionUI).AddSlot();
            }
        }
    }
}
