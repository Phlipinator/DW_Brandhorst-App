using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InfoScreenController : MonoBehaviour
{
    private void Awake()
    {
        int artID = PersistentManagerScript.Instance.artworkID;
        Art art = PersistentManagerScript.Instance.getArtByID(artID);

        var root = GetComponent<UIDocument>().rootVisualElement;
        VisualElement artImage = root.Q<VisualElement>("art_image");
        //Label artAuthor = root.Q<Label>("art_author");
        Label artDescription = root.Q<Label>("art_description");
        Texture2D sprite;
        sprite = Resources.Load<Texture2D>("Sprites/largeImages/" + artID.ToString());
        if (sprite == null)
        {
            sprite = Resources.Load<Texture2D>(PersistentManagerScript.Instance.pathToThumbnails + artID.ToString());

        }
        artImage.style.backgroundImage = sprite;

        //artAuthor.text = art.getAuthor() + ", " + art.getYear(); 
        sprite = Resources.Load<Texture2D>("Sprites/ArtTitle/" + artID.ToString());
        if (sprite != null)
        {
            VisualElement header = root.Q<VisualElement>("Header");
            header.style.backgroundImage = sprite;
        }

        artDescription.text = art.getDescription();
    }

}
