using UnityEngine;
using UnityEngine.UI;

public class ActionSlot : MonoBehaviour
{
    [SerializeField] Image sensorIcon;
    [SerializeField] Image actionIcon;
    [SerializeField] Button actionListButton;

    private void Start()
    {
        GetComponentInParent<ActionSlotController>().AddSlot(this);
    }
}