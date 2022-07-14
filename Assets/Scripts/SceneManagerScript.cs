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
        if (SceneManager.GetActiveScene().name != "4_QR-Scanner")
        {
            PersistentManagerScript.Instance.addSceneToHistory(SceneManager.GetActiveScene().name);
        }
        // The next line needs to be adapted with the new Scene name
        SceneManager.LoadScene("1_RoomOverview");
    }

    //Ask User if he wants the Tutorial
    public void startTutorial()
    {
        SceneManager.LoadScene("1_2_Tutorial");
    }

    //load Tutorial
    public void Tutorial()
    {
        SceneManager.LoadScene("1_3_Tutorial");
    }

    //roomID can be passed with this function to make sure the right artwork is displayed
    public void goToSecond(Room roomID)
    {
        PersistentManagerScript.Instance.roomID = roomID;
        if (SceneManager.GetActiveScene().name != "4_QR-Scanner")
        {
            PersistentManagerScript.Instance.addSceneToHistory(SceneManager.GetActiveScene().name);
        }
        
        SceneManager.LoadScene("2_Challenges");
    }

    //artworkID can be passed with this function to make sure the right artwork is displayed
    public void goToThird(int artworkID)
    {
        PersistentManagerScript.Instance.artworkID = artworkID;
        if (SceneManager.GetActiveScene().name != "4_QR-Scanner")
        {
            PersistentManagerScript.Instance.addSceneToHistory(SceneManager.GetActiveScene().name);
        }
        SceneManager.LoadScene("3_Detail-Challenges");
    }

    public void goToFourth()
    {
        PersistentManagerScript.Instance.doScanning = true;
        if (SceneManager.GetActiveScene().name != "4_QR-Scanner")
        {
            PersistentManagerScript.Instance.addSceneToHistory(SceneManager.GetActiveScene().name);
        }
        SceneManager.LoadScene("4_QR-Scanner");
    }

    public void goToFifth(int artID)
    {
        PersistentManagerScript.Instance.artworkID = artID;
        if (SceneManager.GetActiveScene().name != "4_QR-Scanner")
        {
            PersistentManagerScript.Instance.addSceneToHistory(SceneManager.GetActiveScene().name);
        }
        SceneManager.LoadScene("5_Info-Screens");
    }

    public void goToSixt()
    {
        if (SceneManager.GetActiveScene().name != "4_QR-Scanner")
        {
            PersistentManagerScript.Instance.addSceneToHistory(SceneManager.GetActiveScene().name);
        }
        SceneManager.LoadScene("6_Trophies");
    }

    //For questions ask Philipp Thalhammer
}
