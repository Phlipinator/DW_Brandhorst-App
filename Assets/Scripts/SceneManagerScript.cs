using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    //THIS SCRIPT NEEDS TO BE ADDED TO A EMPTY GAMEOBJECT IN EVERY SCENE
    public void goBack()
    {

        SceneManager.LoadScene(PersistentManagerScript.Instance.getSceneName());
        
    }
    public void goToFirst()
    {
        // The next Line needs to be copied exactly like this to every new SceneSwitch-Function
        PersistentManagerScript.Instance.addSceneToHistory(SceneManager.GetActiveScene().name);
        // The next line needs to be adapted with the new Scene name
        SceneManager.LoadScene("Test1");
    }

    public void goToSecond()
    {
        PersistentManagerScript.Instance.addSceneToHistory(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Test2");
    }

    //For questions ask Philipp Thalhammer
}
