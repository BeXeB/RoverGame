using UnityEngine;
using TMPro;

public class MoveForwardActionUI : ActionUI
{
    [SerializeField] GameObject ActionPrefab;
    [SerializeField] TMP_InputField inputField;

    void UpdateAction()
    {
        int number;
        if (int.TryParse(inputField.text, out number) && inSlot)
        {
            ((MoveAction)action).amount = number;
        }
    }
    private void Start()
    {
        inputField.onEndEdit.AddListener(delegate { UpdateAction(); });
        GameObject go = Instantiate(ActionPrefab);
        action = go.GetComponent<MoveAction>();
    }
}
