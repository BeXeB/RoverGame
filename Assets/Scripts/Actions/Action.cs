using UnityEngine;

public abstract class Action : MonoBehaviour
{
    public bool running;
    public abstract void PerformAction();
    public ActionType complexity;
}

public enum ActionType { Simple, Complex, Conditional }
