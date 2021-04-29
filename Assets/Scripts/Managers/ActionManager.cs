using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public static ActionManager instance;
    [SerializeField] List<Action> actionsToPerform;
    RoverMovement player;
    public bool performing;
    public List<Coroutine> runningRoutines = new List<Coroutine>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        player = RoverManager.instance.rover.GetComponent<RoverMovement>();
    }

    public void Stop()
    {
        StopAllCoroutines();
        foreach (Coroutine routine in runningRoutines)
        {
            if (routine != null)
                StopCoroutine(routine);
        }
        ResetActions(actionsToPerform);
        player.runningRoutine = false;
        performing = false;
    }

    private void ResetActions(List<Action> actions)
    {
        foreach (Action action in actions)
        {
            action.running = false;
            if (action is WhileAction)
            {
                ResetActions(((WhileAction)action).GetActions());
            }
            else if (action is ForAction)
            {
                ResetActions(((ForAction)action).GetActions());
            }
            else if (action is IfAction)
            {
                ResetActions(((IfAction)action).GetTrueActions());
                ResetActions(((IfAction)action).GetFalseActions());
            }
        }
    }

    public void AddAction(Action action)
    {
        actionsToPerform.Add(action);
    }

    public void AddActions(List<Action> actions)
    {
        actionsToPerform = actions;
    }

    public void RemoveAction(Action action)
    {
        actionsToPerform.Remove(action);
    }

    public void PerformActions()
    {
        if (!performing)
        {
            StartCoroutine(PerformActionsBehaviour());
        }
    }

    IEnumerator PerformActionsBehaviour()
    {
        performing = true;
        yield return new WaitUntil(() => !player.runningRoutine);
        foreach (Action action in actionsToPerform)
        {
            action.PerformAction();
            yield return new WaitUntil(() => !action.running);
        }
        performing = false;
    }
}
