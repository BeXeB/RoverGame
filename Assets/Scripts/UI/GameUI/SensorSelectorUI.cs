using UnityEngine;

public class SensorSelectorUI : MonoBehaviour
{
    [SerializeField] GameObject sensorSelectorUI;
    public static SensorSelectorUI instance;


    private void Awake()
    {
        instance = this;
    }

    public void EnableUI()
    {
        sensorSelectorUI.SetActive(true);
    }

    public void SelectSensor(GameObject sensorPrefab)
    {   
        GameObject go = Instantiate(sensorPrefab);
        ActionOptionsUI.instance.SetSensor(go.GetComponent<Sensor>());
        DisableUI();
    }

    public void DisableUI()
    {
        sensorSelectorUI.SetActive(false);
    }
}
