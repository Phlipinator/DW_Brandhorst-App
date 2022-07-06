using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrophyViewController : MonoBehaviour
{
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        VisualElement trophyList = root.Q<VisualElement>("trophyList");

        for (var i = 1; i < 9; i++) {
            VisualElement elem = new VisualElement();
            elem.name = "Element" + i;
            elem.AddToClassList("image-list-element");
            var sprite = Resources.Load<Texture2D>("Sprites/thumbnails/" + i);
            elem.style.backgroundImage = sprite;

            trophyList.Add(elem);
        }
    }
}
