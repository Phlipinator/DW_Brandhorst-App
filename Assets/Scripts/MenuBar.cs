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

        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                //Start Screen
                break;
            case 1:
                //Raum Übersicht
                home.style.backgroundImage = new StyleBackground(exchangeIcon);
                middle.clicked += () =>
                {
                    //Go to Trophy
                    sceneChange.goToSixt();
                };
                break;
            case 2:
                //Challenges Übersicht
                middle.clicked += () =>
                {
                    //Go to Trophy
                    sceneChange.goToSixt();
                };
                break;
            case 3:
                //Detail Challenges
                middle.style.backgroundImage = new StyleBackground(exchangeIcon);
                middle.clicked += () =>
                {
                    sceneChange.goToFourth();
                };
                break;
            case 4:
                //QR-Code Scanner
                middle.style.backgroundImage = new StyleBackground(exchangeIcon);
                break;
            case 5:
                //Info Text
                //middle.style.backgroundImage = new StyleBackground(exchangeIcon); //has to be removed when scene5 is merged!!!
                middle.clicked += () =>
                {
                    //Go to Trophy
                    sceneChange.goToSixt();
                };
                break;
            case 6:
                //Trophy Übersicht
                middle.style.backgroundImage = new StyleBackground(exchangeIcon);
                break;
            default:
                Debug.Log("Error");
                break;
        }

        /**if (SceneManager.GetActiveScene().buildIndex >= 3)
        {
            middle.style.backgroundImage = new StyleBackground(scannerIcon);
            middle.clicked += () =>
            {
                sceneChange.goToFourth();
                //Entweder Scanner öffnet sich oder man kommt zur Trophy Übersicht
                Debug.Log("Middle");
            };
        }
        else
        {
            middle.clicked += () =>
            {
                
                //Entweder Scanner öffnet sich oder man kommt zur Trophy Übersicht
                Debug.Log("Middle");
            };
        }**/
       
        back.clicked += () =>
        {
            if(SceneManager.GetActiveScene().name == "4_QR-Scanner")
            {
                PersistentManagerScript.Instance._cameraTexture.Stop();
            }
            sceneChange.goBack();
            Debug.Log("zurück");
        };

        home.clicked += () =>
        {
            if (SceneManager.GetActiveScene().name == "4_QR-Scanner")
            {
                PersistentManagerScript.Instance._cameraTexture.Stop();
            }
            Debug.Log("Zurück zur Raumübersicht");
            sceneChange.goToFirst();
        };

    }

}
