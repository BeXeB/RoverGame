using UnityEngine;
using UnityEngine.UI;

public class ActionSlot : MonoBehaviour
{
    [SerializeField] Image sensorIcon;
    [SerializeField] Image actionIcon;

    private void Start()
    {
        GetComponentInParent<ActionSlotController>().AddSlot(this);
    }
}