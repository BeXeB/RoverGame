using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActionSlot : MonoBehaviour, IEndDragHandler
{
    [SerializeField] Image sensorIcon;
    [SerializeField] Image actionIcon;
    [SerializeField] Button actionListButton;

    private void Start()
    {
        GetComponentInParent<ActionSlotController>().AddSlot(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(eventData.pointerDrag)
        {
            
        }
    }
}