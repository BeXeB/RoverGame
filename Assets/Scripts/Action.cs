using UnityEngine;

public abstract class Action : MonoBehaviour
{
    public bool running;
    public abstract void PerformAction();
}
