using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ForActionUI : ActionUI
{
    [SerializeField] GameObject ActionPrefab;
    [SerializeField] TMP_InputField inputField;

    void UpdateAction()
    {
        int number;
        if (int.TryParse(inputField.text, out number) && inSlot)
        {
            ((ForAction)action).times = number;
        }
    }
    private void Start()
    {
        inputField.onEndEdit.AddListener(delegate { UpdateAction(); });
        GameObject go = Instantiate(ActionPrefab);
        action = go.GetComponent<ForAction>();
    }
}
