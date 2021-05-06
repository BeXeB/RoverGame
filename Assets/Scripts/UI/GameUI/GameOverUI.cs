using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI instance;

    [SerializeField] Transform ui;

    private void Awake()
    {
        instance = this;
    }

    public void SetActive()
    {
        ui.gameObject.SetActive(true);
    }

    public void Retry()
    {
        MapManager.instance.ResetMap();
        RoverManager.instance.ended = false;
        ButtonsUI.instance.ResetButtons();
        ui.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
