using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Scene3 : MonoBehaviour
{
    public Texture2D img01;
    public Texture2D img02;
    public Texture2D img03;
    public Texture2D img04;
    public Texture2D img05;
    public Texture2D img06;
    public Texture2D img07;
    public Texture2D img08;
    public SceneManagerScript sceneChange;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    private void Awake()
    {
        //einfach derweil mal ignorieren ###
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

        var artworkThumbnail = content.Q<VisualElement>("artwork_thumbnail");
        //###

        //also change Tips? 
        switch (PersistentManagerScript.Instance.artworkID)
        {
            case "art1":
                artworkThumbnail.style.backgroundImage = new StyleBackground(img01);
                break;
            case "art2":
                artworkThumbnail.style.backgroundImage = new StyleBackground(img02);
                break;
            case "art3":
                artworkThumbnail.style.backgroundImage = new StyleBackground(img03);
                break;
            case "art4":
                artworkThumbnail.style.backgroundImage = new StyleBackground(img04);
                break;
            case "art5":
                artworkThumbnail.style.backgroundImage = new StyleBackground(img05);
                break;
            case "art6":
                artworkThumbnail.style.backgroundImage = new StyleBackground(img06);
                break;
            case "art7":
                artworkThumbnail.style.backgroundImage = new StyleBackground(img07);
                break;
            case "art8":
                artworkThumbnail.style.backgroundImage = new StyleBackground(img08);
                break;
            default:
                Debug.Log("Error");
                break;
        }

        //zum Szene wechseln in Scene4 (QR-Code scanner)
        scanButton.clicked += () =>
        {
            sceneChange.goToFourth();
            Debug.Log("clicked");
        };




        //Zeigen Tipps an:
        hintButton1.clicked += () =>
        {
            Debug.Log("Hint button 1 clicked");
            segmentButtonTimer1.style.display = DisplayStyle.None;
            segmentHint1.style.display = DisplayStyle.Flex;
            artworkThumbnail.style.backgroundImage = new StyleBackground(img02);

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
