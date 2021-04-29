using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfAction : Action
{
    public Sensor sensor;
    public bool invertSensor;
    [SerializeField] List<Action> trueActions;
    [SerializeField] List<Action> falseActions;
    RoverMovement player;

    private void Start()
    {
        player = RoverManager.instance.rover.GetComponent<RoverMovement>();
    }

    public void AddTrueAction(Action action)
    {
        trueActions.Add(action);
    }

    public void AddTrueActions(List<Action> actions)
    {
        trueActions = actions;
    }

    public void AddFalseAction(Action action)
    {
        falseActions.Add(action);
    }

    public void AddFalseActions(List<Action> actions)
    {
        falseActions = actions;
    }

    public override void PerformAction()
    {
        routine = StartCoroutine(ActionBehaviour());
        ActionManager.instance.runningRoutines.Add(routine);
    }

    public List<Action> GetTrueActions()
    {
        return trueActions;
    }

    public List<Action> GetFalseActions()
    {
        return falseActions;
    }

    IEnumerator ActionBehaviour()
    {
        running = true;
        if (sensor.Evaluate() ^ invertSensor)
        {
            foreach (Action action in trueActions)
            {
                action.PerformAction();
                yield return new WaitUntil(() => !action.running);
            }
        }
        else
        {
            foreach (Action action in falseActions)
            {
                action.PerformAction();
                yield return new WaitUntil(() => !action.running);
            }
        }
        running = false;
        ActionManager.instance.runningRoutines.Remove(routine);
    }
}
