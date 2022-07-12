using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public enum Room
{
    Erdgeschoss,
    Untergeschoss
}

public class PersistentManagerScript : MonoBehaviour
{
    //THIS SCRIPT ONLY NEEDS TO EXIST IN THE FIRST SCENE
    public static PersistentManagerScript Instance { get; private set;}

    public int artworkID;
    public Room roomID;
    public List<string> sceneHistory;
    public bool doScanning;
    public WebCamTexture _cameraTexture;
    public List<int> unlockedArtworks;
    public List<Art> exhibition;

    public string pathToThumbnails = "Sprites/thumbnails/";
    //do we have large images?
    public string pathToLargeImages = "Sprites/thumbnails/";

    //Set all art pieces of the exhibition
    public void defineExhibition()
    {
        exhibition = new List<Art>
        {
            new Art(2, "Testautor", "2005", Room.Erdgeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            new Art(3, "Testautor", "2005", Room.Erdgeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            new Art(4, "Testautor", "2005", Room.Erdgeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            new Art(5, "Testautor", "2005", Room.Erdgeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            new Art(6, "Testautor", "2005", Room.Erdgeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            new Art(7, "Testautor", "2005", Room.Erdgeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            new Art(8, "Testautor", "2005", Room.Erdgeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            new Art(9, "Testautor", "2005", Room.Erdgeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            new Art(10, "Testautor", "2005", Room.Untergeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            new Art(11, "Testautor", "2005", Room.Untergeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            new Art(12, "Testautor", "2005", Room.Untergeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            new Art(13, "Testautor", "2005", Room.Untergeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            new Art(14, "Testautor", "2005", Room.Untergeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            new Art(15, "Testautor", "2005", Room.Untergeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            new Art(16, "Testautor", "2005", Room.Untergeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" })
        };
    }

    private void Start()
    {
        //initialises the Scanning process
        doScanning = true;
    }

    //Singleton behaviour, do not touch!
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            defineExhibition();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Adds the current Scene to the List
    public void addSceneToHistory(string name)
    {
        sceneHistory.Add(name);
    }

    //returns a Scene name (if history is not empty) and removes it from the list
    public string getSceneName()
    {
        string lastScene;

        //Checks if there are Scenes in the History
        if (sceneHistory.Count > 0)
        {
            //Returns the last Scene and removes it from the list
            lastScene = sceneHistory[sceneHistory.Count - 1];
            sceneHistory.RemoveAt(sceneHistory.Count - 1);
        }
        else
        {
            //Returns the current scene if the history is empty
            lastScene = SceneManager.GetActiveScene().name;
        }

        return lastScene;

        
    }

    public Art getArtByID(int id)
    {
        if (exhibition == null)
        {
            defineExhibition();
        }
        return exhibition.Find(item => item.getID() == id);
    }

    public List<Art> getArtByRoom(Room room)
    {
        if (exhibition == null)
        {
            defineExhibition();
        }
        return exhibition.Where(item => item.getRoom() == room).ToList();
    }

    //For questions ask Philipp Thalhammer
}
