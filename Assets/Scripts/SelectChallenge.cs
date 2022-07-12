using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SelectChallenge : MonoBehaviour
{
    public SceneManagerScript sceneChange;
    void Awake()
    {
        Room room = PersistentManagerScript.Instance.roomID;

        var root = GetComponent<UIDocument>().rootVisualElement;
        VisualElement roomName = root.Q<VisualElement>("RoomName");
        VisualElement challangeList = root.Q<VisualElement>("challangeView");
        Texture2D sprite;
        int id;

        sprite = Resources.Load<Texture2D>("Sprites/title/" + room.ToString());
        roomName.style.backgroundImage = sprite;

        List<Art> artInRoom = PersistentManagerScript.Instance.getArtByRoom(room);

        for (var i = 0; i < artInRoom.Count; i++)
        {
            id = artInRoom[i].getID();
            ArtButton elem = new ArtButton();
            elem.name = "art" + id.ToString();
            elem.setArtID(id.ToString());
            elem.RemoveFromClassList("unity-button");
            elem.AddToClassList("image-list-element");
            sprite = Resources.Load<Texture2D>(PersistentManagerScript.Instance.pathToThumbnails + id.ToString());
            elem.style.backgroundImage = sprite;

            elem.RegisterCallback<PointerUpEvent, string>(artClicked, elem.getArtID());

            challangeList.Add(elem);
        }
    }

    private void artClicked(PointerUpEvent _, string artID)
    {
        int id = Int32.Parse(artID);
        PersistentManagerScript.Instance.artworkID = id;
        sceneChange.goToThird(id);
    }
}
