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

    public Action GetAction()
    {
        return action;
    }

    public Transform GetTrueActionsParent()
    {
        return trueActionsParent.transform;
    }

    public Transform GetFalseActionsParent()
    {
        return falseActionsParent.transform;
    }

    public void AddAction(Action action)
    {
        CodeUI.instance.DecreaseRemainingActions();
        this.action = action;
        icon.sprite = action.icon;
        deleteButton.interactable = true;
        if (action.type == ActionType.For || action.type == ActionType.While)
        {
            complexUI.SetActive(true);
            middleImg.SetActive(false);
            trueActionsParent.SetActive(true);
            falseActionsParent.SetActive(false);
            trueActionsParent.GetComponent<ActionSlotController>()?.AddNewEmptySlot();
        }
        else if (action.type == ActionType.If)
        {
            complexUI.SetActive(true);
            middleImg.SetActive(true);
            trueActionsParent.SetActive(true);
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
            if (CodeUI.instance.remainingActions > 0)
            {
                //open action selector and create new slot after selecting
                ActionSelectorUI.instance.EnableUI(this);
                GetComponentInParent<ActionSlotController>().AddActionSlot(this);
            }
        }
        else
        {
            //if an action is alredy selected open options instead
            ActionOptionsUI.instance.OpenOptions(action);
        }
    }

    private void OnDestroy()
    {
        if (action)
        {
            CodeUI.instance.IncreaseRemainingAction();
            Destroy(action.gameObject);
        }
    }
}
