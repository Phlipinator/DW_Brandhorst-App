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
            new Art(2, "Testautor", "2005", Room.Untergeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            //"2 Heads on Base #1"
            new Art(3, "Bruce Nauman", "1998", Room.Erdgeschoss,
                "Die Skulputur zeigt zwei Köpfe und sie stammen aus den" +
                "bayerischen Staatsgemäldesammlungen und stehen aktuell im Museum Brandhorst" +
                "Dies hier ist ein Lückenfüllertext, da mehr Infos derzeit nicht vorliegen.",
                new List<string> { "Mehr als die Köpfe sind bei diesem Werk nicht zu sehen",
                    "Eines weiteren Tipps bedarf es hier nicht." }),
            new Art(4, "Testautor", "2005", Room.Untergeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            new Art(5, "Testautor", "2005", Room.Erdgeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            //"großes, silbernes Monstrum"
            new Art(6, "Joachim Bandau", "1971", Room.Erdgeschoss,
                "Kleiderpuppensegmente, glasfaserverstärkter Polyester, verschiedene Materialien," +
                "Lack, Aluminium, C-Schlauchkupplungen, mit oder ohne Vacuflex-Schlauch, Rollen",
                new List<string> { "Das gezeigte Gewinde befindet sich am Objekt im oberen Bereich",
                    "Der Schlauch liegt am Boden rum" }),
            //"New Model Army"
            new Art(7, "Alexandra Bricken", "2016", Room.Erdgeschoss,
                "Vier kopflose Schaufensterpuppen sind in Reih und Glied hintereinander aufgestellt. " +
                "Der Titel verspricht eine „New Model Army“, doch die Figuren erinnern eher an eine Lumpenarmee: " +
                "Teile gebrauchter Motorradbekleidung wurden mit Füllwatte und Seidenstrumpfhosen direkt auf den " +
                "Plastikkörpern zu Monturen vernäht. Der Abrieb von Unfällen auf der Motorradbekleidung, aber auch " +
                "die händischen Nähte, welche die Materialien zusammenhalten, wirken wie Narben auf dieser zweiten, " +
                "eigentlich schützenden Haut. Das Recyceln bereits benutzter Materialien ist eine Konstante in Birckens " +
                "Œuvre, die als Modedesignerin arbeitete, bevor sie sich Anfang der 2000er-Jahre der bildenden Kunst " +
                "zuwandte. Und so spielt Bekleidung und ihre Bedeutung für unser Selbstverständnis nach wie vor eine große " +
                "Rolle im Schaffen der Künstlerin. Birckens „Armee“ wird zum Sinnbild des „beschädigten“ und doch " +
                "wehrhaften Subjekts, das eben nicht in makelloser Perfektion erstrahlt, sondern die Spuren des Erlebten " +
                "für alle sichtbar zur Schau trägt.",
                new List<string> { "Es gibt 4 davon", "Es handelt sich hier um ein Hosenbein" }),
            new Art(8, "Testautor", "2005", Room.Erdgeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            //"UniAddDumThs "Tier""
            new Art(9, "Mark Leckey", "2005", Room.Untergeschoss,
                "Die raumgreifende Installation von Mark Leckey bietet einen ungewöhnlichen Blick auf die Technikgeschichte. " +
                "2013 war der britische Künstler eingeladen, eine Ausstellung zu kuratieren. Entlang von übergeordneten " +
                "Begriffen – „Mensch“, „Maschine“, „Tier“ – wählte er Kunstwerke und Gegenstände mit Bezügen zu Technologie, " +
                "Popkultur und Menschheitsgeschichte aus. Er arrangierte sie dicht an dicht in großen Displays. Hier kreuzten " +
                "sich Gegenstände (aber auch das technologische Imaginäre) verschiedener Zeiten und Zusammenhänge. Zum Ende der " +
                "Ausstellung entschied Leckey, die Objekte für sich zu bewahren, indem er mit analogen und digitalen Mitteln – " +
                "durch 3-D-Drucke, Fotografien oder auch Pappaufsteller – (autorisierte) Kopien und Reproduktionen davon schuf. " +
                "So entstand „UniAddDumThs“. Ausgangspunkt seiner Auswahl war die Beobachtung, dass die Technologie unsere " +
                "Beziehung zu den Dingen verändert hat. Denn unsere hoch digitalisierte Umgebung ist zunehmend von „belebten“ " +
                "und „vernetzten“ Gegenständen bevölkert: Computer sprechen mit uns, unser Kühlschrank weiß, was wir gerne essen. " +
                "Der Glaube an das Eigenleben der vermeintlich „dummen Dinge“ wird immer normaler. Dies verbindet unsere " +
                "technologisierte Welt mit dem animistischen Denken aus vormodernen Zeiten, als Gegenstände noch als lebendig oder " +
                "gar beseelt wahrgenommen wurden.",
                new List<string> { "Dies ist teil der großen, raumübergreifenden Installation", "Wuff!" }),
            new Art(10, "Testautor", "2005", Room.Untergeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            new Art(11, "Testautor", "2005", Room.Erdgeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            new Art(12, "Testautor", "2005", Room.Erdgeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            //"Sexbesessenheit"
            new Art(13, "Yayoi Kuama", "1929", Room.Erdgeschoss,
                "Hemd, gefüllter Stoff, Kleiderbügel, Farbe," +
                "Silbersprühfarbe \n Sammlung Goetz, München",
                new List<string> { "Es handelt sich hier um ein Stoff-Konstrukt", "Man könnte es anziehen" }),
            //"little sister"
            new Art(14, "Aleksandra Domanović", "2013", Room.Erdgeschoss,
                "Die Skulpturengruppe der in Novi Sad, im ehemaligen Jugoslawien geborenen und in Berlin lebendenKünstlerin Aleksandra " +
                "Domanović kreist um die Belgrade Hand, die weltweit erste, mit fünf Fingern und Tastsinn ausgestattete bionische " +
                "Handprothese. Der jugoslawische Ingenieur Rajko Tomović erfand sie 1963 für Soldat:innen, die im Zweiten Weltkrieg ihre " +
                "Hände verloren hatten, und sie galt bald als wichtige Wegmarke für Entwicklungen in der Robotik. Für ihre Skulpturen hat " +
                "Domanović die Form der Belgrade Hand in einer Software nachgebildet, per 3-D-Druck aus den Kunststoffen Polyamid und Polyurethan " +
                "produzieren sowie mit Messing, Aluminium und einer Soft-Touch-Oberfläche beschichten lassen. Die Fingerhaltungen von „Fatima“, " +
                "„Mayura Mudra“ und „Little Sister“ verweisen auf symbolische Gesten aus verschiedenen kulturellen Traditionen und Zeiten. " +
                "Gleichermaßen sind die Werke Chiffren für Domanovićs Auseinandersetzung mit der maßgeblichen, aber meist übersehenen Rolle, " +
                "die Frauen bei technologischen Entwicklungen gespielt haben. Die zuden Skulpturen gehörende Timeline reflektiert diese Geschichte " +
                "der Technologie und ihre genderspezifischen Missverhältnisse.",
                new List<string> { "Hier bedarf es Fingerspitzengefühl.", "Im selben Raum befinden sich noch weitere Hände." }),
            new Art(15, "Testautor", "2005", Room.Erdgeschoss, "Beschreibung", new List<string> { "Tipp1", "Tipp2" }),
            //"Vaginablätter (zweite Gegenwart)"
            new Art(16, "Genpei Akasegawa", "1961/1994", Room.Erdgeschoss,
                "Das Relief des japanischen Künstlers Genpei Akasegawa " +
                "beeindruckt gleichermaßen durch seine Größe wie durch " +
                "seine Materialität. Aus aufgeschnittenen und neu vernähten " +
                "rotbraunen Lkw-Schläuchen, auf die eine Radkappe " +
                "sowie Elektronenröhren appliziert sind, schuf er ein Objekt " +
                "von geradezu überwältigender Körperlichkeit. Der Titel " +
                "„Sheets of Vagina (Second Present)“ stellt explizit den Bezug " +
                "zum weiblichen Geschlechtsorgan her. Ursprünglich " +
                "tropfte aus einer langen Pipette, die in die Arbeit integriert " +
                "war, Salzsäure auf ein darunterliegendes Objekt. Das " +
                "weibliche Sexualorgan - die Kontaktstelle zwischen innen " +
                "und außen-war ersetzt worden durch leckende Maschinenteile." +
                "„Sheets of Vagina“ besteht aus Abfallprodukten, " +
                "dem Überschuss der wirtschaftlichen Expansion Japans " +
                "in den 1950er- und 1960er-Jahren. Bei aller Veränderung " +
                "in der japanischen Gesellschaft wurden Themen wie freie " +
                "Sexualität und Fortpflanzung jedoch weiterhin unter- " +
                "drückt. Abstrakt genug, um nicht zur Zensur aufzufordern, " +
                "sind die fleischigen Materialien und Formen umso aufgeladener" +
                "und zeugen von einer fremdartigen " +
                "maschinischen Produktivität.",
                new List<string> { "Das Kunstwerk ist überwiegend rötlich.", "Es hängt an der Wand." })
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
