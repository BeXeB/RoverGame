using System.Collections;
using UnityEngine;

public class RoverMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    public bool runningRoutine;

    public void Move(int amount)
    {
        if (!runningRoutine)
        {
            Vector3 dest = transform.position + transform.forward * amount;
            print(dest);
            StartCoroutine(MovementBehaviour(dest));
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Move(1);
        }
    }

    IEnumerator MovementBehaviour(Vector3 dest)
    {
        runningRoutine = true;
        while (transform.position != dest)
        {
            transform.position = Vector3.MoveTowards(transform.position, dest, Time.deltaTime * moveSpeed);
            yield return null;
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
}
