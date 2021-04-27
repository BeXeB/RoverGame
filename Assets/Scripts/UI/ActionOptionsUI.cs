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
    [SerializeField] Image sensorIcon;
    [SerializeField] Sprite defaultSensorIcon;
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
        amountOptionsUI.SetActive(true);
        sensorOptionsUI.SetActive(false);
        amountInput.text = Mathf.Abs(((MoveAction)currentAction).amount).ToString();
        amountInput.onEndEdit.RemoveAllListeners();
        amountInput.onEndEdit.AddListener(delegate { MoveForwardInputProcess(amountInput); });
    }

    void MoveForwardInputProcess(TMP_InputField input)
    {
        bool intNumber = int.TryParse(input.text, out int result);
        if (intNumber && result > 0)
        {
            ((MoveAction)currentAction).amount = result;
        }
        else
        {
            ((MoveAction)currentAction).amount = 1;
            input.text = "1";
        }
    }

    void SetUpMoveBackward()
    {
        actionTypeText.text = "Move Backwards";
        amountOptionsUI.SetActive(true);
        sensorOptionsUI.SetActive(false);
        amountInput.text = Mathf.Abs(((MoveAction)currentAction).amount).ToString();
        amountInput.onEndEdit.RemoveAllListeners();
        amountInput.onEndEdit.AddListener(delegate { MoveBackwardInputProcess(amountInput); });
    }

    void MoveBackwardInputProcess(TMP_InputField input)
    {
        bool intNumber = int.TryParse(input.text, out int result);
        if (intNumber && result > 0)
        {
            ((MoveAction)currentAction).amount = result * -1;
        }
        else
        {
            ((MoveAction)currentAction).amount = -1;
            input.text = "1";
        }
    }

    void SetUpRotateLeft()
    {
        actionTypeText.text = "Rotate Left";
        amountOptionsUI.SetActive(true);
        sensorOptionsUI.SetActive(false);
        amountInput.text = Mathf.Abs(((RotateAction)currentAction).amount).ToString();
        amountInput.onEndEdit.RemoveAllListeners();
        amountInput.onEndEdit.AddListener(delegate { RotateLeftInputProcess(amountInput); });
    }

    void RotateLeftInputProcess(TMP_InputField input)
    {
        bool intNumber = int.TryParse(input.text, out int result);
        if (intNumber)
        {
            result = Mathf.Clamp(result, 90, int.MaxValue);
            result = Mathf.RoundToInt(result / 90f) * 90;
            ((RotateAction)currentAction).amount = result * -1;
            input.text = result.ToString();
        }
        else
        {
            ((RotateAction)currentAction).amount = 90;
            input.text = "90";
        }
    }

    void SetUpRotateRight()
    {
        actionTypeText.text = "Rotate Right";
        amountOptionsUI.SetActive(true);
        sensorOptionsUI.SetActive(false);
        amountInput.text = Mathf.Abs(((RotateAction)currentAction).amount).ToString();
        amountInput.onEndEdit.RemoveAllListeners();
        amountInput.onEndEdit.AddListener(delegate { RotateRightInputProcess(amountInput); });
    }

    void RotateRightInputProcess(TMP_InputField input)
    {
        bool intNumber = int.TryParse(input.text, out int result);
        if (intNumber)
        {
            result = Mathf.Clamp(result, 90, int.MaxValue);
            result = Mathf.RoundToInt(result / 90f) * 90;
            ((RotateAction)currentAction).amount = result;
            input.text = result.ToString();
        }
        else
        {
            ((RotateAction)currentAction).amount = -90;
            input.text = "90";
        }
    }

    void SetUpIf()
    {
        actionTypeText.text = "If";
        amountOptionsUI.SetActive(false);
        sensorOptionsUI.SetActive(true);
        Sprite currentSensorIcon = ((WhileAction)currentAction).sensor?.icon;
        sensorIcon.sprite = currentSensorIcon ? currentSensorIcon : defaultSensorIcon;
        invertSensorToggle.onValueChanged.RemoveAllListeners();
        invertSensorToggle.onValueChanged.AddListener(delegate { IfToggleProcess(invertSensorToggle); });
    }

    void IfToggleProcess(Toggle toggle)
    {
        ((IfAction)currentAction).invertSensor = toggle.isOn;
    }

    void SetUpFor()
    {
        actionTypeText.text = "For";
        amountOptionsUI.SetActive(true);
        sensorOptionsUI.SetActive(false);
        amountInput.text = Mathf.Abs(((ForAction)currentAction).times).ToString();
        amountInput.onEndEdit.RemoveAllListeners();
        amountInput.onEndEdit.AddListener(delegate { ForInputProcess(amountInput); });
    }

    void ForInputProcess(TMP_InputField input)
    {
        bool intNumber = int.TryParse(input.text, out int result);
        if (intNumber)
        {
            ((ForAction)currentAction).times = Mathf.Abs(result);
        }
        else
        {
            ((ForAction)currentAction).times = 1;
            input.text = "1";
        }
    }

    void SetUpWhile()
    {
        actionTypeText.text = "While";
        amountOptionsUI.SetActive(false);
        sensorOptionsUI.SetActive(true);
        Sprite currentSensorIcon = ((WhileAction)currentAction).sensor?.icon;
        sensorIcon.sprite = currentSensorIcon ? currentSensorIcon : defaultSensorIcon;
        invertSensorToggle.onValueChanged.RemoveAllListeners();
        invertSensorToggle.onValueChanged.AddListener(delegate { WhileToggleProcess(invertSensorToggle); });
    }

    void WhileToggleProcess(Toggle toggle)
    {
        ((WhileAction)currentAction).invertSensor = toggle.isOn;
    }

    public void SetSensor(Sensor sensor)
    {
        sensorIcon.sprite = sensor.icon;
        if (currentAction.type == ActionType.If)
        {
            ((IfAction)currentAction).sensor = sensor;
        }
        else if (currentAction.type == ActionType.While)
        {
            ((WhileAction)currentAction).sensor = sensor;
        }
    }
}
