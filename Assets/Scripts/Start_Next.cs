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
            sceneChange.startTutorial();
        };

        
    }
    
}
