using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public SceneManagerScript sceneChange;

    void Awake()
    {
        //get Elements of UIDocument
        var root = this.GetComponent<UIDocument>().rootVisualElement;

        //get Buttons
        Button continueButton = root.Q<Button>("continueButton");
        Button skipButton = root.Q<Button>("skipButton");

        //continue Button pressed, start Tutorial
        continueButton.clicked += () =>
        {
            sceneChange.Tutorial();
        };

        //pressed Überspringen, start App, i.e. go to Room Overview
        skipButton.clicked += () =>
        {
            sceneChange.goToFirst();
        };

    }

}
