using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;

public class SelectChallenge : MonoBehaviour
{
    public SceneManagerScript sceneChange;
    void Awake()
    {
        //get Buttons of each Challenge
        var root = this.GetComponent<UIDocument>().rootVisualElement;
        Button art1 = root.Q<Button>("Art1");
        Button art2 = root.Q<Button>("Art2");
        Button art3 = root.Q<Button>("Art3");
        Button art4 = root.Q<Button>("Art4");
        Button art5 = root.Q<Button>("Art5");
        Button art6 = root.Q<Button>("Art6");
        Button art7 = root.Q<Button>("Art7");
        Button art8 = root.Q<Button>("Art8");

        art1.clicked += () =>
        {
            //artID aktualisieren aus der Liste
            sceneChange.goToThird("art1");
            //Szene wechseln
            
            Debug.Log("1clicked");
        };

        art2.clicked += () =>
        {
            sceneChange.goToThird("art2");
            Debug.Log("2clicked");
        };

        art3.clicked += () =>
        {
            sceneChange.goToThird("art3");
            Debug.Log("3clicked");
        };

        art4.clicked += () =>
        {
            sceneChange.goToThird("art4");
            Debug.Log("4clicked");
        };

        art5.clicked += () =>
        {
            sceneChange.goToThird("art5");
            Debug.Log("5clicked");
        };

        art6.clicked += () =>
        {
            sceneChange.goToThird("art6");
            Debug.Log("6clicked");
        };

        art7.clicked += () =>
        {
            sceneChange.goToThird("art7");
            Debug.Log("7clicked");
        };

        art8.clicked += () =>
        {
            sceneChange.goToThird("art8");
            Debug.Log("8clicked");
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
