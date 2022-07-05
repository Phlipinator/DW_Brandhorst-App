using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    public void Start()
    {
        
    }

    public void goBack()
    {
        SceneManager.LoadScene(PersistentManagerScript.Instance.getSceneName());
        Debug.Log(PersistentManagerScript.Instance.getSceneName());
    }
    public void goToFirst()
    {
        // The next Line needs to be copied exactly like this to every new SceneSwitch-Function
        string sceneName = SceneManager.GetActiveScene().name;
        PersistentManagerScript.Instance.addSceneToHistory(sceneName);
        Debug.Log("Added " + SceneManager.GetActiveScene().name);
        // The next line needs to be adapted withz the new Scene name
        SceneManager.LoadScene("Test1");
    }

    public void goToSecond()
    {
        PersistentManagerScript.Instance.addSceneToHistory(SceneManager.GetActiveScene().name);
        Debug.Log("Added " + SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Test2");
    }

    public void Test()
    {
        PersistentManagerScript.Instance.artworkID = 1;
    }
}
