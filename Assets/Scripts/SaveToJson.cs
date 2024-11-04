using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveToJson : MonoBehaviour
{
    public Song song;

    void Start()
    {
        // Serialize the ScriptableObject to JSON
        string json = JsonUtility.ToJson(song);
        Debug.Log("Serialized JSON: " + json);

        // Optionally, save the JSON to a file
        System.IO.File.WriteAllText(Application.persistentDataPath + "/MyData.json", json);
    }
}
