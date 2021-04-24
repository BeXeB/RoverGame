using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionSlotController : MonoBehaviour //actions Parentre
{
    GameObject actionSlotPrefab;
    ContentSizeFitter contentSizeFitter;
    List<ActionSlotUI> actionSlots = new List<ActionSlotUI>();

    private void OnEnable()
    {
        actionSlotPrefab = (GameObject)Resources.Load("Prefabs/ActionSlot", typeof(GameObject));
        contentSizeFitter = GetComponent<ContentSizeFitter>();
    }

    private void Update() // gets called every frame
    {
        //needs better solution ASAP
        contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.MinSize;
    }

    public List<ActionSlotUI> GetActionSlots()
    { 
        return actionSlots;
    }

    public void AddActionSlot(ActionSlotUI action)
    {
        actionSlots.Add(action);
        AddNewEmptySlot();
    }

    public void AddNewEmptySlot()
    {
        Instantiate(actionSlotPrefab, Vector3.zero, transform.rotation, transform);
    }

    public void DeleteAction(ActionSlotUI action)
    {
        actionSlots.Remove(action);
        action.DeleteSlot();
    }
}
