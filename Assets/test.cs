using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    
    [SerializeField] GameObject pathPrefab;
    [SerializeField] GameObject[,] gameObjects;

    private void Start() {
        gameObjects = new GameObject[2,2];
        gameObjects[1,1] = Instantiate(pathPrefab, new Vector3(1f, 0f, 1f), Quaternion.LookRotation(Vector3.forward));
    }
}
