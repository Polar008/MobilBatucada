using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Song", menuName = "ScriptableObjects/Song", order = 1)]
public class Song : ScriptableObject
{
    public string name;
    public List<float> drumBeats = new List<float>();
    public List<float> drumSideBeats = new List<float>();
    public List<float> drumsticksBeats = new List<float>();
}
