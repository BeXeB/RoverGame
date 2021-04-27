using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeUI : MonoBehaviour
{
    public static CodeUI instance;

    private void Awake()
    {
        instance = this;
    }

    public delegate void OnRemainingActionsChanged();
    public OnRemainingActionsChanged onRemainingActionsChangedCallback;


    public int maxActions;
    public int remainingActions;
    [SerializeField] private Transform actionSlotParent;
    private ActionManager actionManager;

    public void IncreaseRemainingAction()
    {
        remainingActions++;
        onRemainingActionsChangedCallback?.Invoke();
    }

    public void DecreaseRemainingActions()
    {
        remainingActions--;
        onRemainingActionsChangedCallback?.Invoke();
    }

    private void Start()
    {
        actionManager = ActionManager.instance;
        maxActions = MapManager.instance.selectedMap.GetMaxActions();
        remainingActions = maxActions;
    }

    public void Play()
    {
        actionManager.AddActions(Compile(actionSlotParent));
        actionManager.PerformActions();
    }

    public List<Action> Compile(Transform actionParent)
    {
        ActionSlotController actionSlotController = actionParent.GetComponent<ActionSlotController>();
        List<Action> actionsList = new List<Action>();
        foreach (ActionSlotUI actionSlotUI in actionSlotController.GetActionSlots())
        {
            Action action = actionSlotUI.GetAction();
            if (action is ForAction)
            {
                ((ForAction)action).AddActions(Compile(actionSlotUI.GetTrueActionsParent()));
            }
            else if (action is WhileAction)
            {
                ((WhileAction)action).AddActions(Compile(actionSlotUI.GetTrueActionsParent()));
            }
            else if (action is IfAction)
            {
                ((IfAction)action).AddTrueActions(Compile(actionSlotUI.GetTrueActionsParent()));
                ((IfAction)action).AddFalseActions(Compile(actionSlotUI.GetFalseActionsParent()));
            }
            actionsList.Add(action);
        }
        return actionsList;
    }
}
