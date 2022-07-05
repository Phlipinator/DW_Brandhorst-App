using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentManagerScript : MonoBehaviour
{
    public static PersistentManagerScript Instance { get; private set;}

    public int artworkID;
    private List<string> sceneHistory;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void addSceneToHistory(string name)
    {
        sceneHistory.Add(name);
    }

    public string getSceneName()
    {
        string lastScene = sceneHistory[sceneHistory.Count - 1];

        sceneHistory.RemoveAt(sceneHistory.Count - 1);

        return lastScene;
    }
}
