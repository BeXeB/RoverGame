using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatAction : Action
{
    [SerializeField] int times;
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
        for (int i = 0; i < times; i++)
        {
            foreach (Action action in actionsToRepeat)
            {
                yield return new WaitUntil(() => !player.runningRoutine);
                action.PerformAction();
            }
        }
        yield return new WaitUntil(() => !player.runningRoutine);
        running = false;
    }
}
