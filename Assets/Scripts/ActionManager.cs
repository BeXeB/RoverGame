using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public static ActionManager instance;
    [SerializeField] List<Action> actionsToPerform;
    RoverMovement player;
    bool performing;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        player = RoverManager.instance.player.GetComponent<RoverMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformActions();
        }
    }

    //rewrite these two with indexes
    public void AddAction(Action action)
    {
        actionsToPerform.Add(action);
    }

    public void RemoveAction(Action action)
    {
        actionsToPerform.Remove(action);
    }

    public void PerformActions()
    {
        if (!performing)
        {
            StartCoroutine(PerformActionsBehaviour());
        }
    }

    IEnumerator PerformActionsBehaviour()
    {
        performing = true;
        yield return new WaitUntil(() => !player.runningRoutine);
        foreach (Action action in actionsToPerform)
        {
            action.PerformAction();
            yield return new WaitUntil(() => !action.running);
        }
        performing = false;
    }
}
