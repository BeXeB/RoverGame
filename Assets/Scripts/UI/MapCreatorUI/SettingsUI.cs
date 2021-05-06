using UnityEngine;
using TMPro;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] TMP_InputField roverRotInput;
    [SerializeField] TMP_InputField alienRotInput;
    [SerializeField] TMP_InputField actionLimitIput;
    MapCreatorUI mapCreator;

    private void Awake()
    {
        mapCreator = MapCreatorUI.instance;
        roverRotInput.onEndEdit.RemoveAllListeners();
        roverRotInput.onEndEdit.AddListener(delegate { RoverRotInputProcess(roverRotInput); });
        alienRotInput.onEndEdit.RemoveAllListeners();
        alienRotInput.onEndEdit.AddListener(delegate { AlienRotInputProcess(alienRotInput); });
        actionLimitIput.onEndEdit.RemoveAllListeners();
        actionLimitIput.onEndEdit.AddListener(delegate { ActionLimitInputProcess(actionLimitIput); });
    }

    private void RoverRotInputProcess(TMP_InputField inputField)
    {
        bool intNumber = int.TryParse(inputField.text, out int result);
        if (intNumber && result >= 0)
        {
            mapCreator.roverRot = result;
        }
        else
        {
            mapCreator.roverRot = 0;
            inputField.text = "0";
        }
    }

    private void AlienRotInputProcess(TMP_InputField inputField)
    {
        bool intNumber = int.TryParse(inputField.text, out int result);
        if (intNumber && result >= 0)
        {
            mapCreator.alienRot = result;
        }
        else
        {
            mapCreator.alienRot = 0;
            inputField.text = "0";
        }
    }

    private void ActionLimitInputProcess(TMP_InputField inputField)
    {
        bool intNumber = int.TryParse(inputField.text, out int result);
        if (intNumber && result > 0)
        {
            mapCreator.maxActions = result;
        }
        else
        {
            mapCreator.maxActions = 1;
            inputField.text = "1";
        }
    }

    public void OnOKButton()
    {
        gameObject.SetActive(false);
    }
}
