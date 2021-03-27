using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForAction : Action
{
    public int times;
    [SerializeField] List<Action> actionsToRepeat;
    RoverMovement player;

    private void Start()
    {
        player = RoverManager.instance.player.GetComponent<RoverMovement>();
    }

    public void AddAction(Action action)
    {
        actionsToRepeat.Add(action);
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
                action.PerformAction();
                yield return new WaitUntil(() => !action.running);
            }
        }
        running = false;
    }
}
