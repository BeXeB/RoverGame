using UnityEngine;
using TMPro;

public class RotateActionUI : ActionUI
{
    [SerializeField] GameObject ActionPrefab;
    [SerializeField] TMP_InputField inputField;

    void UpdateAction()
    {
        int number;
        if (int.TryParse(inputField.text, out number) && inSlot)
        {
            number = (number / 90) * 90;
            inputField.text = number.ToString();
            ((RotateAction)action).amount = number;
        }
    }
    private void Start()
    {
        inputField.onEndEdit.AddListener(delegate { UpdateAction(); });
        GameObject go = Instantiate(ActionPrefab);
        action = go.GetComponent<RotateAction>();
    }
}
