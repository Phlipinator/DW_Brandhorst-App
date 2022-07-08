using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;
using UnityEngine.SceneManagement;

public class MenuBar : MonoBehaviour
{
    public Texture2D scannerIcon;
    public SceneManagerScript sceneChange;

    void Awake()
    {
        //get Buttons of each Challenge
        var root = this.GetComponent<UIDocument>().rootVisualElement;
        Button back = root.Q<Button>("back");
        Button middle = root.Q<Button>("trophy");
        Button home = root.Q<Button>("home");

        Debug.Log(SceneManager.GetActiveScene().buildIndex);

        if (SceneManager.GetActiveScene().buildIndex >= 3)
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
        }
       
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
