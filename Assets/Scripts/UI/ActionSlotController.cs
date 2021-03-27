using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSlotController : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    private List<GameObject> slots;

    private void Awake()
    {
        slots = new List<GameObject>();
    }

    public void AddSlot()
    {
        GameObject go = Instantiate(prefab, transform.position, transform.rotation, transform);
        slots.Add(go);
    }
}
