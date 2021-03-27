using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSlotController : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform parent;
    private List<ActionSlot> slots;

    private void Awake()
    {
        slots = new List<ActionSlot>();
    }

    public void AddSlot(ActionSlot slot)
    {
        slots.Add(slot);
    }
}
