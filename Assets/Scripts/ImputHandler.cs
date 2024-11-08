using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImputHandler : MonoBehaviour
{
    [SerializeField] NoteSpawner ns;

    private void Start()
    {
        
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
                ns.PlayDrum();
            }
            else if (hit.transform.CompareTag("Drumstick"))
            {
                ns.PlayDrumstick();
            }
            else if (hit.transform.CompareTag("DrumSide"))
            {
                ns.PlayDrumSide();
            }
        }
    }
}
