using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActionSlot : MonoBehaviour, IDropHandler
{
    public int slotIndex;
    bool used;
    Action action;
    ActionUI actionUI;

    public void NullOut()
    {
        action = null;
        actionUI = null;
        used = false;
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject go = eventData.pointerDrag;
        if (go != null)
        {
            if (!used && !go.GetComponent<SensorUI>()) //test not sensor
            {
                used = true;
                SlotManager.instance.AddSlot();
                go.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                go.GetComponent<RectTransform>().SetParent(GetComponent<RectTransform>());
                actionUI = go.GetComponent<ActionUI>();
                actionUI.inSlot = true;
                actionUI.slotIndex = slotIndex;
                action = actionUI.action;
                ActionManager.instance.AddAction(go.GetComponent<ActionUI>().action, slotIndex);
            }
            else if (action is ForAction && !go.GetComponent<SensorUI>())
            {
                go.GetComponent<RectTransform>().SetParent(
                    ((ForActionUI)actionUI).transform.GetComponentInChildren<VerticalLayoutGroup>().transform);
                go.GetComponent<ActionUI>().inSlot = true;
                ((ForAction)action).AddAction(go.GetComponent<ActionUI>().action);
            }
            else if (action is WhileAction)
            {
                print("asd");
                if (go.GetComponent<SensorUI>())
                {
                    ((WhileAction)action).sensor = go.GetComponent<SensorUI>().sensor;
                }
                else
                {
                    go.GetComponent<RectTransform>().SetParent(
                    ((WhileActionUI)actionUI).transform.GetComponentInChildren<VerticalLayoutGroup>().transform);
                    go.GetComponent<ActionUI>().inSlot = true;
                    ((WhileAction)action).AddAction(go.GetComponent<ActionUI>().action);
                }
            }
        }
    }
}
