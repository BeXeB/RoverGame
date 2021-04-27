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

    public GameObject rover;

    public void GameOver()
    {
        if (!ended)
        {
            ended = true;
            GameOverUI.instance.SetActive();
        }
    }

    public void Complete()
    {
        if (!ended)
        {
            ended = true;
            ClearUI.instance.SetActive();
        }
    }
}
