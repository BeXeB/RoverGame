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
    public override void PerformAction()
    {
        StartCoroutine(ActionBehaviour());
    }

    IEnumerator ActionBehaviour()
    {
        running = true;
        if (sensor.evaluate() ^ invertSensor)
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
    }
}
