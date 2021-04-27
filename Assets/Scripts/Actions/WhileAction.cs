using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileAction : Action
{
    public Sensor sensor;
    public bool invertSensor;
    [SerializeField] List<Action> actionsToRepeat;
    RoverMovement player;

    private void Start()
    {
        player = RoverManager.instance.rover.GetComponent<RoverMovement>();
    }

    public void AddAction(Action action)
    {
        actionsToRepeat.Add(action);
    }

    public void AddActions(List<Action> actions)
    {
        actionsToRepeat = actions;
    }


    public override void PerformAction()
    {
        StartCoroutine(ActionBehaviour());
    }

    IEnumerator ActionBehaviour()
    {
        running = true;
        while (sensor.Evaluate() ^ invertSensor)
        {
            foreach (Action action in actionsToRepeat)
            {
                action.PerformAction();
                yield return new WaitUntil(() => !action.running);
            }
        }
        running = false;
    }
}
