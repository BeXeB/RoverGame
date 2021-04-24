using UnityEngine;

public class ActionSelectorUI : MonoBehaviour
{
    [SerializeField] GameObject actionSelectorUI;
    public static ActionSelectorUI instance;

    ActionSlotUI currentActionSlot;

    private void Awake()
    {
        instance = this;
    }

    public void EnableUI(ActionSlotUI actionSlot)
    {
        currentActionSlot = actionSlot;
        actionSelectorUI.SetActive(true);
    }

    public void SelectAction(GameObject actionPrefab)
    {   
        GameObject go = Instantiate(actionPrefab);
        currentActionSlot.AddAction(go.GetComponent<Action>());
        DisableUI();
    }

    public void DisableUI()
    {
        actionSelectorUI.SetActive(false);
        currentActionSlot = null;
    }
}