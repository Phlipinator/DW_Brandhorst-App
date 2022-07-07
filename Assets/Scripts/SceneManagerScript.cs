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
        SceneManager.LoadScene("1_RoomOverview");
    }

    //roomID can be passed with this function to make sure the right artwork is displayed
    public void goToSecond(string roomID)
    {
        PersistentManagerScript.Instance.roomID = roomID;
        PersistentManagerScript.Instance.addSceneToHistory(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("2_Challenges");
    }

    //artworkID can be passed with this function to make sure the right artwork is displayed
    public void goToThird(string artworkID)
    {
        PersistentManagerScript.Instance.artworkID = artworkID;
        PersistentManagerScript.Instance.addSceneToHistory(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("3_Detail-Challenges");
    }

    public void goToFourth()
    {
        PersistentManagerScript.Instance.addSceneToHistory(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("4_QR-Scanner");
    }

    public void goToSixt()
    {
        PersistentManagerScript.Instance.addSceneToHistory(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Test2");
    }

    //For questions ask Philipp Thalhammer
}
