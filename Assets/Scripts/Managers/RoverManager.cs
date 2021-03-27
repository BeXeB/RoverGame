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

    public UnityEngine.GameObject rover;
}
