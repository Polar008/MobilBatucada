using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    [SerializeField] Song song1;
    float timeSpent;

    private void Awake()
    {
        timeSpent = 0f;
    }

    private void FixedUpdate()
    {
        timeSpent += Time.deltaTime;
    }
    private void OnMouseDown()
    {
        song1.drumBeats.Add(timeSpent);
    }
}
