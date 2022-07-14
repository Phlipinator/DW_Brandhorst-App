using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;
using UnityEngine.SceneManagement;

public class StartApp : MonoBehaviour
{
    public SceneManagerScript sceneChange;

    void Awake()
    {
        //get Elements of UIDocument
        var root = this.GetComponent<UIDocument>().rootVisualElement;

        //get Buttons
        Button continueButton = root.Q<Button>("start");

        continueButton.clicked += () =>
        {
            sceneChange.goToFirst();
        };

    }

}
