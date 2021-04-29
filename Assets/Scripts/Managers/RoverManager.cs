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

    public bool ended;

    public GameObject rover;

    public void GameOver()
    {
        if (!ended)
        {
            ended = true;
            GameOverUI.instance.SetActive();
            ActionManager.instance.Stop();
        }
    }

    public void Complete()
    {
        if (!ended)
        {
            ended = true;
            ClearUI.instance.SetActive();
            ActionManager.instance.Stop();
        }
    }
}
