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

    void Update()
    {
        // Cache the main camera once for efficiency

        // Handle touch input
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Began)
            {
                HandleInput(touch.position);
            }
        }

        // Handle mouse input for non-touch devices
        if (Input.GetMouseButtonDown(0))
        {
            HandleInput(Input.mousePosition);
        }
    }

    // Method to handle both touch and mouse input
    void HandleInput(Vector3 inputPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("Drum"))
            {
                song1.drumBeats.Add(timeSpent);
            }
            else if (hit.transform.CompareTag("Drumstick"))
            {
                song1.drumsticksBeats.Add(timeSpent);
            }
            else if (hit.transform.CompareTag("DrumSide"))
            {
                song1.drumSideBeats.Add(timeSpent);
            }
        }
    }

    private void FixedUpdate()
    {
        timeSpent += Time.deltaTime;
    }
}
