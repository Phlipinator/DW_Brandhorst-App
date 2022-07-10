using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;

public class Start_Next : MonoBehaviour
{
    public SceneManagerScript sceneChange;
    
    void Awake()
    {
        //get Buttons of each Challenge
        var root = this.GetComponent<UIDocument>().rootVisualElement;
        Button next = root.Q<Button>("weiterButton");

        next.clicked += () =>
        {
            //Szene wechseln
            sceneChange.goToFirst();
            Debug.Log("Next clicked");
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
