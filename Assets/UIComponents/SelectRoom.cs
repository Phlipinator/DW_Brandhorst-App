using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;

public class SelectRoom : MonoBehaviour
{
    void Awake()
    {
        //get Buttons of each Challenge
        var root = this.GetComponent<UIDocument>().rootVisualElement;
        Button room = root.Q<Button>("ScrollContent");

        room.clicked += () =>
        {
            //artID aktualisieren aus der Liste

            //Szene wechseln
            Debug.Log("room1 clicked");
        };

        
    }
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hi");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
