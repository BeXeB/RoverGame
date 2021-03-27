using System.Collections;
using UnityEngine;

public class RotateAction : Action
{
    RoverMovement player;
    public float amount;

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
        player.Rotate(amount);
        yield return new WaitUntil(() => !player.runningRoutine);
        running = false;
    }
}
