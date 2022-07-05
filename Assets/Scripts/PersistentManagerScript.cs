using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentManagerScript : MonoBehaviour
{
    //THIS SCRIPT NEEDS SHOULD NOT BE TOUCHED; AS IT ONLY NEEDS TO EXIST IN THE FIRST SCENE
    public static PersistentManagerScript Instance { get; private set;}

    public string artworkID;
    public string roomID;
    public List<string> sceneHistory;

    //Singleton behaviour, do not touch!
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

    //Adds the current Scene to the List
    public void addSceneToHistory(string name)
    {
        sceneHistory.Add(name);
    }

    //returns a Scene name (if history is not empty) and removes it from the list
    public string getSceneName()
    {
        string lastScene;

        //Checks if there are Scenes in the History
        if (sceneHistory.Count > 0)
        {
            //Returns the last Scene and removes it from the list
            lastScene = sceneHistory[sceneHistory.Count - 1];
            sceneHistory.RemoveAt(sceneHistory.Count - 1);
        }
        else
        {
            //Returns the current scene if the history is empty
            lastScene = SceneManager.GetActiveScene().name;
        }

        return lastScene;

        
    }

    //For questions ask Philipp Thalhammer
}
