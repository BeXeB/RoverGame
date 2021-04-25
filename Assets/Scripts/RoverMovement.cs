using System;
using System.Collections;
using UnityEngine;

public class RoverMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float rotateSpeed = 1f;
    public bool runningRoutine;
    int[,] map;

    public void Move(int amount)
    {
        if (!runningRoutine)
        {
            StartCoroutine(MovementBehaviour(amount));
        }
    }

    public void Rotate(float ammount)
    {
        if (!runningRoutine)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(Quaternion.AngleAxis(ammount, transform.up) * transform.forward);
            StartCoroutine(RotateBehaviour(desiredRotation));
        }
    }

    IEnumerator MovementBehaviour(int amount)
    {
        runningRoutine = true;
        Vector3 finalDest = transform.position + transform.forward * amount;
        while (transform.position != finalDest)
        {
            Vector3 dest = transform.position + transform.forward * (amount / Mathf.Abs(amount));
            int x = Convert.ToInt32(Math.Round(dest.x));
            int z = Convert.ToInt32(Math.Round(dest.z));

            map = MapManager.instance.selectedMap.getMap();
            RoverManager roverManager = RoverManager.instance;
            if (!(map.GetLength(0) <= z || map.GetLength(1) <= x || z < 0 || x < 0 || map[z, x] == 2))
            {
                while (transform.position != dest)
                {
                    transform.position = Vector3.MoveTowards(transform.position, dest, Time.deltaTime * moveSpeed);
                    yield return null;
                }
                if (map[z, x] == 3)
                {
                    roverManager.GameOver();
                }
                else if (map[z, x] == 4)
                {
                    roverManager.Complete();
                }
            }
            else
            {
                break;
            }
        }
        runningRoutine = false;
    }

    IEnumerator RotateBehaviour(Quaternion desiredRotation)
    {
        runningRoutine = true;
        while (transform.rotation.eulerAngles != desiredRotation.eulerAngles)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotateSpeed * Time.deltaTime);
            yield return null;
        }
        runningRoutine = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // here we can handle colliding with terrain good (goal) or bad
    }
}
