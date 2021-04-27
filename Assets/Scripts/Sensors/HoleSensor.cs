using System;
using UnityEngine;

public class HoleSensor : Sensor
{
    int[,] currentMap;
    Transform rover;
    private void Start()
    {
        rover = RoverManager.instance.rover.transform;
        currentMap = MapManager.instance.selectedMap.GetMap();
    }
    public override bool Evaluate()
    {
        Vector3 coordinatesVector3 = rover.position + rover.forward * 1;
        int x = Convert.ToInt32(Math.Round(coordinatesVector3.x));
        int z = Convert.ToInt32(Math.Round(coordinatesVector3.z));
        if (currentMap[z , x] == 4)
        {
            return true;
        }
        return false;
    }
}
