using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMover : MonoBehaviour
{
    public Transform pointA; // Starting point
    public Transform pointB; // Ending point
    public Transform correct;
    public float duration = 3f;
    public float proximity;

    private float elapsedTime = 0f;
    private bool isMoving = true;

    void Start()
    {
        this.transform.position = pointA.position;
    }

    void Update()
    {
        if (isMoving)
        {
            elapsedTime += Time.deltaTime;
            float fraction = elapsedTime / duration;
            transform.position = Vector3.Lerp(pointA.position, pointB.position, fraction);
            if (fraction >= 1f)
            {
                isMoving = false;
            }
        }
    }

    void CheckProximity()
    {
        if (Vector2.Distance(transform.position, correct.position) >= proximity)
        {
            Debug.Log("good");
        }
        else
        {
            Debug.Log("Bad");
        }
    }
}
