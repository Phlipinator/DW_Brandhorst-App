using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;

public class MenuBar : MonoBehaviour
{
    void Awake()
    {
        //get Buttons of each Challenge
        var root = this.GetComponent<UIDocument>().rootVisualElement;
        Button back = root.Q<Button>("back");
        Button middle = root.Q<Button>("trophy");
        Button home = root.Q<Button>("home");

        back.clicked += () =>
        {
            //Szene zurück
            Debug.Log("zurück");
        };

        middle.clicked += () =>
        {
            //Entweder Scanner öffnet sich oder man kommt zur Trophy Übersicht
            Debug.Log("Middle");
        };

        home.clicked += () =>
        {
            Debug.Log("Zurück zur Raumübersicht");
            //man kommt zur RaumÜbersicht (Szene1_Room)
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
