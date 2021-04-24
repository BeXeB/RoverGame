using UnityEngine;

public class CoinflipSensor : Sensor
{
    public override bool evaluate()
    {
        return Random.Range(0, 2) < 0.5;
    }
}
