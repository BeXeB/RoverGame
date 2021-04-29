using System.Collections;
using UnityEngine;

public class RotateAction : Action
{
    RoverMovement player;
    public float amount;

    private void Start()
    {
        player = RoverManager.instance.rover.GetComponent<RoverMovement>();
    }
    public override void PerformAction()
    {
        routine = StartCoroutine(ActionBehaviour());
        ActionManager.instance.runningRoutines.Add(routine);
    }

    IEnumerator ActionBehaviour()
    {
        running = true;
        player.Rotate(amount);
        yield return new WaitUntil(() => !player.runningRoutine);
        running = false;
        ActionManager.instance.runningRoutines.Remove(routine);
    }
}
