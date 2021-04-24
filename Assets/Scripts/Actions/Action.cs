using UnityEngine;

public abstract class Action : MonoBehaviour
{
    public Sprite icon;
    public ActionType type;
    public bool running;
    public abstract void PerformAction();
}

public enum ActionType { MoveF, MoveB, RotateL, RotateR, If, For, While}
