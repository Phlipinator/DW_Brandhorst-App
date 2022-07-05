using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Scene3 : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       

    }

    private void Awake()
    {
        var root = this.GetComponent<UIDocument>().rootVisualElement;
        var view = root.Q<VisualElement>("view");
        Button scanButton = view.Q<Button>("button_scan");
        var content = view.Q<VisualElement>("content");

        var segmentButtonTimer1 = content.Q("Hint1").Q("root").Q<VisualElement>("segment_button_timer");
        var segmentHint1 = content.Q("Hint1").Q("root").Q<VisualElement>("segment_hint");

        Button hintButton1 = segmentButtonTimer1.Q<Button>("button");

        var segmentButtonTimer2 = content.Q("Hint2").Q("root").Q<VisualElement>("segment_button_timer");
        var segmentHint2 = content.Q("Hint2").Q("root").Q<VisualElement>("segment_hint");

        Button hintButton2 = segmentButtonTimer2.Q<Button>("button");

        scanButton.clicked += () =>
        {
            Debug.Log("clicked");
        };

        hintButton1.clicked += () =>
        {
            Debug.Log("Hint button 1 clicked");
            segmentButtonTimer1.style.display = DisplayStyle.None;
            segmentHint1.style.display = DisplayStyle.Flex;
        };

        hintButton2.clicked += () =>
        {
            Debug.Log("Hint button 2 clicked");
            segmentButtonTimer2.style.display = DisplayStyle.None;
            segmentHint2.style.display = DisplayStyle.Flex;
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
