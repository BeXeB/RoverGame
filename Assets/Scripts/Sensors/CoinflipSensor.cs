using UnityEngine;

public class CoinflipSensor : Sensor
{
    public override bool Evaluate()
    {
        return Random.Range(0, 2) < 0.5;
    }
}
