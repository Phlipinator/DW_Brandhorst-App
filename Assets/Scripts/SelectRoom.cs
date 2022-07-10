using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;

public class SelectRoom : MonoBehaviour
{
    public SceneManagerScript sceneChange;
    void Awake()
    {
        //get Buttons of each Challenge
        var root = this.GetComponent<UIDocument>().rootVisualElement;
        Button room1 = root.Q<Button>("ScrollContent");

        room1.clicked += () =>
        {
            //Szene wechseln, update RoomID
            sceneChange.goToSecond("room1");
            Debug.Log("room1 clicked");
        };

        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
