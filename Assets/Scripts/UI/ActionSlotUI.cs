using UnityEngine;
using UnityEngine.UI;

public class ActionSlotUI : MonoBehaviour //action Slotokra
{
    [SerializeField] Image icon;
    [SerializeField] Button deleteButton;
    [SerializeField] Button actionButton;
    [SerializeField] GameObject complexUI;
    [SerializeField] GameObject trueActionsParent;
    [SerializeField] GameObject middleImg;
    [SerializeField] GameObject falseActionsParent;
    Action action;

    private void Start()
    {
        actionButton.interactable = true;
        deleteButton.interactable = false;
        action = null;
    }

    public void AddAction(Action action)
    {
        this.action = action;
        icon.sprite = action.icon;
        deleteButton.interactable = true;
        if (action.type == ActionType.For || action.type == ActionType.While)
        {
            complexUI.SetActive(true);
            middleImg.SetActive(false);
            falseActionsParent.SetActive(false);
            trueActionsParent.GetComponent<ActionSlotController>()?.AddNewEmptySlot();
        }
        else if (action.type == ActionType.If)
        {
            complexUI.SetActive(true);
            middleImg.SetActive(true);
            falseActionsParent.SetActive(true);
            trueActionsParent.GetComponent<ActionSlotController>()?.AddNewEmptySlot();
            falseActionsParent.GetComponent<ActionSlotController>()?.AddNewEmptySlot();
        }
        else
        {
            complexUI.SetActive(false);
        }
    }

    public void DeleteSlot()
    {
        Destroy(action.gameObject);
        Destroy(gameObject);
    }

    public void OnDeteleButton()
    {
        GetComponentInParent<ActionSlotController>().DeleteAction(this);
    }

    public void OnActionButton()
    {
        if (action == null)
        {
            //open action selector and create new slot after selecting
            ActionSelectorUI.instance.EnableUI(this);
            GetComponentInParent<ActionSlotController>().AddActionSlot(this);
        }
        else
        {
            //if an action is alredy selected open options instead
            ActionOptionsUI.instance.OpenOptions(action);
        }
    }
}
