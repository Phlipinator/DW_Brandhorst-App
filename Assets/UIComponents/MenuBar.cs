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
            //Szene zurück
            Debug.Log("zurück");
        };

        home.clicked += () =>
        {
            Debug.Log("Zurück zur Raumübersicht");
            sceneChange.goToFirst();
        };

    }

    // Start is called before the first frame update
    void Start()
    {
        //Checke ob in Szene3, wenn ja tausche den Middle Button aus (Trophy durch Scanner)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
