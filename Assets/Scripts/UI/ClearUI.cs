using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearUI : MonoBehaviour
{
    public static ClearUI instance;
    [SerializeField] Transform ui;
    private void Awake()
    {
        instance = this;
    }

    public void SetActive()
    {
        ui.gameObject.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
