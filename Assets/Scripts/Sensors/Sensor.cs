using UnityEngine;

public abstract class Sensor : MonoBehaviour
{
    public abstract bool Evaluate();
    public Sprite icon;
}
