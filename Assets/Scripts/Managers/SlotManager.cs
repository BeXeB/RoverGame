using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public static SlotManager instance;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    [SerializeField] List<ActionSlot> slots;
    [SerializeField] GameObject slotPrefab;
    [SerializeField] Transform slotsParent;

    public void AddSlot()
    {
        GameObject go = Instantiate(slotPrefab);
        slots.Add(go.GetComponent<ActionSlot>());
        go.GetComponent<RectTransform>().SetParent(slotsParent);
        SlotsChanged();
    }

    public void AddSlot(int index)
    {
        GameObject go = Instantiate(slotPrefab);
        slots.Insert(index, go.GetComponent<ActionSlot>());
        go.GetComponent<RectTransform>().SetParent(slotsParent);
        SlotsChanged();
    }

    public void RemoveSlot(int index)
    {
        GameObject go = slots[index].gameObject;
        slots.Remove(slots[index]);
        Destroy(go);
        SlotsChanged();
    }

    void SlotsChanged()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].slotIndex = i;
            if (slots[i].GetComponentInChildren<ActionUI>())
            {
                slots[i].GetComponentInChildren<ActionUI>().slotIndex = i;
            }
        }
    }
}
