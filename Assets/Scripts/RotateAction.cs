using System.Collections;
using UnityEngine;

public class RotateAction : Action
{
    RoverMovement player;
    public float ammount;

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
        player.Rotate(ammount);
        yield return new WaitUntil(() => !player.runningRoutine);
        running = false;
    }
}
