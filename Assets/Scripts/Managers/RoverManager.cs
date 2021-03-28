using UnityEngine;

public class RoverManager : MonoBehaviour
{
    public static RoverManager instance;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    bool ended;
    public GameObject gameOverUI;
    public GameObject clearUI;

    public GameObject rover;

    public void GameOver()
    {
        if (!ended)
        {
            ended = true;
            gameOverUI.SetActive(true);
        }
    }

    public void Complete()
    {
        if (!ended)
        {
            ended = true;
            clearUI.SetActive(true);
        }
    }
}
