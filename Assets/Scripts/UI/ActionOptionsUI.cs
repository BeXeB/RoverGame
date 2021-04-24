using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionOptionsUI : MonoBehaviour
{
    public static ActionOptionsUI instance;

    [SerializeField] GameObject amountOptionsUI;
    [SerializeField] GameObject sensorOptionsUI;
    [SerializeField] TMP_Text actionTypeText;
    [SerializeField] TMP_InputField amountInput;
    [SerializeField] Toggle invertSensorToggle;
    bool invertAmount;
    Action currentAction;

    private void Awake()
    {
        instance = this;
    }


    public void OpenOptions(Action action)
    {
        currentAction = action;
        switch (currentAction.type)
        {
            case ActionType.MoveF:
                SetUpMoveForward();
                break;
            case ActionType.MoveB:
                SetUpMoveBackward();
                break;
            case ActionType.RotateL:
                SetUpRotateLeft();
                break;
            case ActionType.RotateR:
                SetUpRotateRight();
                break;
            case ActionType.If:
                SetUpIf();
                break;
            case ActionType.For:
                SetUpFor();
                break;
            case ActionType.While:
                SetUpWhile();
                break;
        }
    }

    void SetUpMoveForward()
    {
        actionTypeText.text = "Move Forward";
        invertAmount = false;
        amountOptionsUI.SetActive(true);
        sensorOptionsUI.SetActive(false);
    }
    void SetUpMoveBackward()
    {
        actionTypeText.text = "Move Backwards";
        invertAmount = true;
        amountOptionsUI.SetActive(true);
        sensorOptionsUI.SetActive(false);
    }
    void SetUpRotateLeft()
    {
        actionTypeText.text = "Rotate Left";
        invertAmount = true;
        amountOptionsUI.SetActive(true);
        sensorOptionsUI.SetActive(false);
    }
    void SetUpRotateRight()
    {
        actionTypeText.text = "Rotate Right";
        invertAmount = false;
        amountOptionsUI.SetActive(true);
        sensorOptionsUI.SetActive(false);
    }
    void SetUpIf()
    {
        actionTypeText.text = "If";
        amountOptionsUI.SetActive(false);
        sensorOptionsUI.SetActive(true);
    }
    void SetUpFor()
    {
        actionTypeText.text = "For";
        invertAmount = false;
        amountOptionsUI.SetActive(true);
        sensorOptionsUI.SetActive(false);
    }
    void SetUpWhile()
    {
        actionTypeText.text = "While";
        amountOptionsUI.SetActive(false);
        sensorOptionsUI.SetActive(true);
    }

    public void SetSensor(Sensor sensor)
    {
        if (currentAction.type == ActionType.If)
        {
            ((IfAction)currentAction).sensor = sensor;
        }
        if (currentAction.type == ActionType.While)
        {
            ((WhileAction)currentAction).sensor = sensor;
        }
    }
}
