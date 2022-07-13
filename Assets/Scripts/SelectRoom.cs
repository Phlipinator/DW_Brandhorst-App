using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class SelectRoom : MonoBehaviour
{
    public SceneManagerScript sceneChange;
    void Awake()
    {
        var root = this.GetComponent<UIDocument>().rootVisualElement;
        VisualElement roomView = root.Q<VisualElement>("RoomView");

        //var roomVisualTree = Resources.Load<VisualTreeAsset>("RoomTemplate");
        var roomVisualTree = Resources.Load<VisualTreeAsset>("Templates/RoomTemplate");


        VisualElement roomTemplate;
        Button roomButton;
        Label roomName;
        VisualElement roomChallenges;
        Texture2D sprite;
        int id;
        List<Art> artInRoom;
        VisualElement elem;

        foreach (Room currentRoom in Enum.GetValues(typeof(Room)))
        {
            roomTemplate = roomVisualTree.CloneTree();

            roomName = roomTemplate.Q<Label>("RoomName");
            roomName.text = currentRoom.ToString();

            roomButton = roomTemplate.Q<Button>("RoomButton");
            roomButton.RegisterCallback<PointerUpEvent, string>(roomClicked, currentRoom.ToString());
            roomName.RegisterCallback<PointerUpEvent, string>(roomClicked, currentRoom.ToString());

            roomChallenges = roomTemplate.Q<VisualElement>("RoomChallenges");
            artInRoom = PersistentManagerScript.Instance.getArtByRoom(currentRoom);

            for (var i = 0; i < artInRoom.Count; i++)
            {
                id = artInRoom[i].getID();
                elem = new VisualElement();
                elem.name = "art" + id.ToString();
                elem.AddToClassList("room-challenges");
                sprite = Resources.Load<Texture2D>(PersistentManagerScript.Instance.pathToThumbnails + id.ToString());
                elem.style.backgroundImage = sprite;

                roomChallenges.Add(elem);
            }

            roomView.Add(roomTemplate);
        }

    }

    private void roomClicked(PointerUpEvent _, string roomID)
    {
        Enum.TryParse(roomID, out Room room);
        PersistentManagerScript.Instance.roomID = room;
        sceneChange.goToSecond(room);
    }
}
