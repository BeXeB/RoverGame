using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ForActionUI : ActionUI
{
    [SerializeField] GameObject ActionPrefab;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] List<ForSlot> slots;
    [SerializeField] GameObject slotPrefab;
    [SerializeField] Transform slotsParent;

    public void AddSlot()
    {
        GameObject go = Instantiate(slotPrefab);
        slots.Add(go.GetComponent<ForSlot>());
        go.GetComponent<RectTransform>().SetParent(slotsParent);
        SlotsChanged();
    }

    public void AddSlot(int index)
    {
        GameObject go = Instantiate(slotPrefab);
        slots.Insert(index, go.GetComponent<ForSlot>());
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

    void UpdateAction()
    {
        int number;
        if (int.TryParse(inputField.text, out number) && inSlot)
        {
            ((ForAction)action).times = number;
        }
    }
    private void Start()
    {
        inputField.onEndEdit.AddListener(delegate { UpdateAction(); });
        GameObject go = Instantiate(ActionPrefab);
        action = go.GetComponent<ForAction>();
    }
}
