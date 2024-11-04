using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImputHandler : MonoBehaviour
{
    [SerializeField] NoteSpawner ns;
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            // Check if the current touch just began
            if (touch.phase == TouchPhase.Began)
            {
                // Create a ray from the touch position
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Check if the ray hits the GameObject's collider
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Drum")
                    {
                        ns.PlayDrum();
                    }
                    if (hit.transform.tag == "Drumstick")
                    {
                        ns.PlayDrumstick();
                    }
                    if (hit.transform.tag == "DrumSide")
                    {
                        ns.PlayDrumSide();
                    }
                }
            }
        }
    }
}
