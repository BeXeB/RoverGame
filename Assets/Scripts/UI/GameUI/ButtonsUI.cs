using UnityEngine;
using UnityEngine.UI;

public class ButtonsUI : MonoBehaviour
{
    public static ButtonsUI instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] GameObject playButton;
    [SerializeField] GameObject resetButton;

    public void ResetButtons()
    {
        playButton.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(false);
    }

    public void OnPlayButton()
    {
        CodeUI.instance.Play();
        playButton.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(true);
    }

    public void OnResetButton()
    {
        ActionManager.instance.Stop();
        MapManager.instance.ResetMap();
        playButton.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(false);
    }
}
