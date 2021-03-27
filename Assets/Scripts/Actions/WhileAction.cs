using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileAction : Action
{
    [SerializeField] Sensor sensor;
    [SerializeField] List<Action> actionsToRepeat;
    RoverMovement player;

    private void Start()
    {
        player = RoverManager.instance.player.GetComponent<RoverMovement>();
    }
    public override void PerformAction()
    {
        StartCoroutine(ActionBehaviour());
    }

    IEnumerator ActionBehaviour()
    {
        running = true;
        while (sensor.evaluate())
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
