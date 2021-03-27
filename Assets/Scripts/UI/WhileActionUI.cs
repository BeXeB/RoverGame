using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileActionUI : ActionUI
{
    [SerializeField] GameObject ActionPrefab;
    private void Start()
    {
        GameObject go = Instantiate(ActionPrefab);
        action = go.GetComponent<WhileAction>();
    }
}
