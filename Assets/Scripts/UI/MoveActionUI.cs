using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveActionUI : ActionUI
{
    [SerializeField] GameObject ActionPrefab;
    [SerializeField] TMP_InputField inputField;

    void UpdateActionManager()
    {
        int number;
        if (int.TryParse(inputField.text, out number) && inSlot)
        {
            ((MoveAction)action).amount = number;
            ActionManager.instance.AddAction(action);
        }
    }
    private void Start()
    {
        inputField.onEndEdit.AddListener(delegate { UpdateActionManager(); });
        GameObject go = Instantiate(ActionPrefab);
        action = go.GetComponent<MoveAction>();
    }
}
