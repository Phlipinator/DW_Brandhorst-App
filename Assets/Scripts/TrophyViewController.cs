using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrophyViewController : MonoBehaviour
{

    public SceneManagerScript sceneChanger;
    void Start()
    {
        List<int> unlockedArtworks = PersistentManagerScript.Instance.unlockedArtworks;

        var root = GetComponent<UIDocument>().rootVisualElement;
        VisualElement trophyList = root.Q<VisualElement>("trophyList");
        Texture2D sprite;
        int id;

        for (var i = 0; i < unlockedArtworks.Count; i++) {
            id = unlockedArtworks[i];
            ArtButton elem = new ArtButton();
            elem.name = "art" + id.ToString();
            elem.setArtID(id.ToString());
            elem.RemoveFromClassList("unity-button");
            elem.AddToClassList("image-list-element");
            sprite = Resources.Load<Texture2D>(PersistentManagerScript.Instance.pathToThumbnails + id.ToString());
            elem.style.backgroundImage = sprite;

            elem.RegisterCallback<PointerUpEvent, string>(artClicked, elem.getArtID());

            /*
            elem.clicked += () =>
             {
                 PersistentManagerScript.Instance.artworkID = id;
                 sceneChanger.goToFifth(id);
             };
            */

            trophyList.Add(elem);
        }
    }

    private void artClicked(PointerUpEvent _, string artID)
    {
        int id = Int32.Parse(artID);
        PersistentManagerScript.Instance.artworkID = id;
        sceneChanger.goToFifth(id);
    }
}
