using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InfoScreenController : MonoBehaviour
{
    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        
        //Element by Name
        VisualElement desc = root.Q<VisualElement>("text");
        //Element by Class
        //VisualElement desc = root.Query(className: "label-art-description");

        var myButton = new Button() { text = "My Button" };
        // Give it some style.
        myButton.style.width = 800;
        myButton.style.height = 300;

        // Adds it to the root.
        //desc.Add(myButton);

        myButton.clickable.clicked += () =>
        {
            Debug.Log("Clicked");
        };
    }
}
