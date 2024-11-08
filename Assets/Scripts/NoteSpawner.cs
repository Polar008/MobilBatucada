using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] private GameObject note;
    [SerializeField] Song song;
    [SerializeField] Transform pointADrum;
    [SerializeField] Transform pointBDrum;
    [SerializeField] Transform correctDrum;
    [SerializeField] Transform pointADrumstick;
    [SerializeField] Transform pointBDrumstick;
    [SerializeField] Transform correctDrumstick;
    [SerializeField] Transform pointADrumSide;
    [SerializeField] Transform pointBDrumSide;
    [SerializeField] Transform correctDrumSide;
    List<Transform> drumNotes = new List<Transform>();
    List<Transform> drumstickNotes = new List<Transform>();
    List<Transform> drumSideNotes = new List<Transform>();
    public float margin;
    float timeSpent;
    int indexDrum;
    int indexDrumstick;
    int indexDrumSide;
    bool playing = true;
    private void Awake()
    {
        timeSpent = 0f;
        indexDrum = 0;
        indexDrumstick = 0;
        indexDrumSide = 0;
    }

    private void FixedUpdate()
    {
        timeSpent += Time.deltaTime;
        if ( playing && timeSpent >= song.drumBeats[indexDrum] )
        {
            GameObject go = Instantiate(note);
            go.GetComponent<NoteMover>().pointA = pointADrum;
            go.GetComponent<NoteMover>().pointB = pointBDrum;
            go.GetComponent<NoteMover>().correct = pointBDrum;
            drumNotes.Add(go.transform);
            indexDrum++;
            CheckEnd();
        }
        if (playing && timeSpent >= song.drumsticksBeats[indexDrumstick])
        {
            GameObject go = Instantiate(note);
            go.GetComponent<NoteMover>().pointA = pointADrumstick;
            go.GetComponent<NoteMover>().pointB = pointBDrumstick;
            go.GetComponent<NoteMover>().correct = pointBDrumstick;
            drumstickNotes.Add(go.transform);
            indexDrumstick++;
            CheckEnd();
        }
        if (playing && timeSpent >= song.drumSideBeats[indexDrumSide])
        {
            GameObject go = Instantiate(note);
            go.GetComponent<NoteMover>().pointA = pointADrumSide;
            go.GetComponent<NoteMover>().pointB = pointBDrumSide;
            go.GetComponent<NoteMover>().correct = pointBDrumSide;
            drumSideNotes.Add(go.transform);
            indexDrumSide++;
            CheckEnd();
        }
    }

    void CheckEnd()
    {
        if (indexDrumstick >= song.drumsticksBeats.Count && indexDrum >= song.drumBeats.Count && indexDrumSide >= song.drumSideBeats.Count)
        {
            playing = false;
        }
    }

    public void PlayDrum()
    {
        Debug.Log("Drum");
        if (Vector2.Distance(drumNotes[0].position, correctDrum.position) <= margin)
        {
            Destroy(drumNotes[0].gameObject);
            drumNotes.RemoveAt(0);
        }
    }

    public void PlayDrumstick()
    {
        Debug.Log("Stick");
        if (Vector2.Distance(drumstickNotes[0].position, correctDrumstick.position) <= margin)
        {
            Destroy(drumstickNotes[0].gameObject);
            drumstickNotes.RemoveAt(0);
        }
    }

    public void PlayDrumSide()
    {
        Debug.Log("Side");
        if (Vector2.Distance(drumSideNotes[0].position, correctDrumSide.position) <= margin)
        {
            Destroy(drumSideNotes[0].gameObject);
            drumSideNotes.RemoveAt(0);
        }
    }
}
