using System.Collections;
using UnityEngine;

public class MoveAction : Action
{
    RoverMovement rover;
    public int amount;

    private void Start()
    {
        rover = RoverManager.instance.rover.GetComponent<RoverMovement>();
    }

    public override void PerformAction()
    {
        routine = StartCoroutine(ActionBehaviour());
        ActionManager.instance.runningRoutines.Add(routine);
    }

    IEnumerator ActionBehaviour()
    {
        running = true;
        rover.Move(amount);
        yield return new WaitUntil(() => !rover.runningRoutine);
        running = false;
        ActionManager.instance.runningRoutines.Remove(routine);
    }
}
