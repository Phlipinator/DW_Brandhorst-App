using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;
using UnityEngine.SceneManagement;

public class MenuBar : MonoBehaviour
{
    public Texture2D exchangeIcon;
    public SceneManagerScript sceneChange;

    void Awake()
    {
        //get Buttons of each Challenge
        var root = this.GetComponent<UIDocument>().rootVisualElement;
        Button back = root.Q<Button>("back");
        Button middle = root.Q<Button>("trophy");
        Button home = root.Q<Button>("home");

        //Depending on which current Screen, there are different Actions for the Buttons
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                //Start Screen
                break;
            case 3:
                //Raum Übersicht
                home.style.backgroundImage = new StyleBackground(exchangeIcon);
                middle.clicked += () =>
                {
                    //Go to Trophy
                    sceneChange.goToSixt();
                };
                break;
            case 4:
                //Challenges Übersicht
                middle.clicked += () =>
                {
                    //Go to Trophy
                    sceneChange.goToSixt();
                };
                break;
            case 5:
                //Detail Challenges
                middle.style.backgroundImage = new StyleBackground(exchangeIcon);
                middle.clicked += () =>
                {
                    sceneChange.goToFourth();
                };
                break;
            case 6:
                //QR-Code Scanner
                middle.style.display = DisplayStyle.None;
                break;
            case 7:
                //Info Text
                middle.clicked += () =>
                {
                    //Go to Trophy
                    sceneChange.goToSixt();
                };
                break;
            case 8:
                //Trophy Übersicht
                middle.style.backgroundImage = new StyleBackground(exchangeIcon);
                break;
            default:
                Debug.Log("Error");
                break;
        }

        //Zurück Button ist immer gleich
        back.clicked += () =>
        {
            if(SceneManager.GetActiveScene().name == "4_QR-Scanner")
            {
                PersistentManagerScript.Instance._cameraTexture.Stop();
            }
            sceneChange.goBack();
        };

        //Home Button geht immer direkt zur Raumübersicht
        home.clicked += () =>
        {
            if (SceneManager.GetActiveScene().name == "4_QR-Scanner")
            {
                PersistentManagerScript.Instance._cameraTexture.Stop();
            }
            sceneChange.goToFirst();
        };

    }

}
