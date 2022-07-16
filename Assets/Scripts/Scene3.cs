using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Scene3 : MonoBehaviour
{
    public SceneManagerScript sceneChange;

    private void Start()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }


    private void Awake()
    {
        float hintProgressDuration = PersistentManagerScript.Instance.hintProgressDuration;
        float hintProgressDelay = 0;

        var root = this.GetComponent<UIDocument>().rootVisualElement;

        var artworkThumbnail = root.Q<VisualElement>("artwork_thumbnail");
        var hintContainer = root.Q<VisualElement>("HintContainer");
        int artID = PersistentManagerScript.Instance.artworkID;
        Art art = PersistentManagerScript.Instance.getArtByID(artID);
        List<string> hintList = art.getTips();
        var sprite = Resources.Load<Texture2D>(PersistentManagerScript.Instance.pathToThumbnails + artID.ToString());
        artworkThumbnail.style.backgroundImage = sprite;

        sprite = Resources.Load<Texture2D>("Sprites/ArtTitle/" + artID.ToString() + "_blur");
        if (sprite != null)
        {
            VisualElement header = root.Q<VisualElement>("Header");
            header.style.backgroundImage = sprite;
        }

        List<string> hintSprite = new List<string> { "hint-left", "hint-right" };
        int hintSpritePointer = 0;




        var hintVisualTree = Resources.Load<VisualTreeAsset>("Templates/Hint");


        VisualElement HintTemplate;
        
        for (var i = 0; i < hintList.Count; i++)
        {
            HintTemplate = hintVisualTree.CloneTree();
            VisualElement progressBar = HintTemplate.Q<VisualElement>("progressBar");
            VisualElement hintContent = HintTemplate.Q<VisualElement>("HintContent");
            Button hintButton = HintTemplate.Q<Button>("button");
            hintButton.RemoveFromClassList("unity-button");
            HintTemplate.name = "hintTemplate" + i.ToString();

            Label elem = new Label();
            elem.name = "hint" + i.ToString();
            elem.text = hintList[i].ToString();
            //switch between left and right background
            elem.AddToClassList(hintSprite[hintSpritePointer]);
            hintSpritePointer = (hintSpritePointer + 1) % 2;

            hintContent.Add(elem);
            /*
            progressBar.style.transitionDuration = new List<TimeValue>()
            {
                new TimeValue(hintProgressDuration, TimeUnit.Second)
            };
            progressBar.style.transitionDelay = new List<TimeValue>()
            {
                new TimeValue(hintProgressDelay, TimeUnit.Second)
            };
            */
            
            StartCoroutine(startHintProgressBar(0.01f + hintProgressDelay, progressBar));
            hintProgressDelay += hintProgressDuration;
            StartCoroutine(registerButtonClick(0.01f + hintProgressDelay, hintButton, i));
            hintContainer.Add(HintTemplate);
            //progressBar.AddToClassList("progress-active");
        }
        

    }
    private void OnSceneUnloaded(Scene current)
    {

        Debug.Log("OnSceneUnloaded: " + current);
    }

    private IEnumerator startHintProgressBar(float delay, VisualElement bar)
    {
        yield return new WaitForSeconds(delay);
        //dont't use transitions, app crashes almost always on scene change
        //bar.AddToClassList("progress-active");
        float endWidth = bar.parent.worldBound.width;
        DOTween.To(() => bar.worldBound.width, x =>
        bar.style.width = x, endWidth, PersistentManagerScript.Instance.hintProgressDuration).SetEase(Ease.Linear);
    }

    private IEnumerator registerButtonClick(float delay, Button button, int i)
    {
        yield return new WaitForSeconds(delay);
        button.RegisterCallback<PointerUpEvent, string>(hintClicked, i.ToString());
    }


    private void hintClicked(PointerUpEvent _, string hintID)
    {
        int id = Int32.Parse(hintID);
        var root = this.GetComponent<UIDocument>().rootVisualElement;
        var hintTemplate = root.Q<VisualElement>("hintTemplate" + id.ToString());
        var hintButton = hintTemplate.Q<VisualElement>("ButtonContainer");
        hintButton.style.display = DisplayStyle.None;
        var hintContent = hintTemplate.Q<VisualElement>("hint" + id.ToString());
        hintContent.style.display = DisplayStyle.Flex;
    }
}
