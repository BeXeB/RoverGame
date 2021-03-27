using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSlotController : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform parent;
    private List<ActionSlot> slots;

    private void Start()
    {
        Instantiate(prefab, parent.position, parent.rotation, parent);
    }

    public void AddSlot(ActionSlot slot)
    {
        slots.Add(slot);
    }
}
