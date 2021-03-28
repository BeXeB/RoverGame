using UnityEngine;
using TMPro;

public class MoveForwardActionUI : ActionUI
{
    [SerializeField] GameObject ActionPrefab;
    private void Start()
    {
        GameObject go = Instantiate(ActionPrefab);
        action = go.GetComponent<MoveAction>();
        ((MoveAction)action).amount = 1;
    }
}
